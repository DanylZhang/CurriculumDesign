import java.awt.*;
import java.awt.event.*;
import java.awt.geom.AffineTransform;
import javax.swing.*;
import javax.swing.event.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Random;
import java.util.Stack;

/**
 * Created by 张丹玉 on 2016-1-06.
 * E-mail: 1475811550@qq.com
 *
 * 本软件解决了机器人在二维砖块型迷宫上的移动规划问题并将其可视化，
 * 主要通过实现以下几种算法：广度优先搜索、深度优先搜索、
 * A*算法以及贪婪算法作为一种A*算法的特例。
 *
 * 本软件也实现了Dijkstra算法，就如同在维基百科的相关文章中描述的那样。
 * http://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
 *
 * A*算法和 Dijkstra算法与其余三个算法相比有着明显的优越性。
 *
 * 用户可以随意改变网格的数量，即可任意指定行数和列数。
 *
 * 用户可以添加尽可能多的障碍物，因为他可由绘图程序画任意曲线。
 *
 * 任意障碍单元可通过单击它们将其移除。
 *
 * 机器人以及目标的位置可通过拖拽鼠标改变。
 *
 * 从“单步”的方式切换到“动画模式”的方式，反之亦然是按相应的按钮，即使在搜索过程进展的同时。
 *
 * 可以在搜索进行时改变搜索的速度
 * 可以将滑块拖放到新的位置，然后再按“动画模式”按钮。
 *
 * 系统假定机器人本身具有一定的体积。
 * 因此，机器人不能通过相邻的两个对角顶点之间的障碍物。
 *
 * 当'单步'或'动画模式'搜索正在进行中，将不能再改变障碍单元，机器人和目标的位置，以及搜索算法。
 *
 * 当“实时模式”搜索正在进行中，障碍单元，机器人和目标的位置均可以改变。
 */

public class AIPathFinding {
    public static JFrame mazeFrame;  // 程序的主窗体

    public static void main(String[] args) {
        int width  = 693;
        int height = 545;
        mazeFrame = new JFrame("AIPathFinding");
        mazeFrame.setContentPane(new MazePanel(width,height));
        mazeFrame.pack();
        mazeFrame.setResizable(false);

        // 在屏幕中央显示窗体
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
        double screenWidth = screenSize.getWidth();
        double ScreenHeight = screenSize.getHeight();
        int x = ((int)screenWidth-width)/2;
        int y = ((int)ScreenHeight-height)/2;

        mazeFrame.setLocation(x,y);
        mazeFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        mazeFrame.setVisible(true);
    } // 主函数

    /**
     * 定义一个内部类作为扩展内容的主窗体
     * 并且包含程序的所有功能.
     */
    public static class MazePanel extends JPanel {
        /**
         * 单元格类
         */
        private class Cell {
            int row;   // 单元格的行数(第0行代表顶行)
            int col;   // 单元格的列数(第0行代表左第一列)
            int g;     // A*和贪婪算法的g函数值
            int h;     // A*和贪婪算法的h函数值
            int f;     // A*和贪婪算法的f函数值
            int dist;  // 单元格与起始点的初始位置之间的距离
            Cell prev; // 每一个状态对应一个单元格，每个状态都有一个存储在该变量中的前驱

            public Cell(int row, int col) {
                this.row = row;
                this.col = col;
            }
        }

        /**
         * 辅助类使单元格具有排序的特性，根据 'f' 字段
         */
        private class CellComparatorByF implements Comparator<Cell> {
            @Override
            public int compare(Cell cell1, Cell cell2) {
                return cell1.f - cell2.f;
            }
        }

        /**
         * 辅助类使单元格具有排序的特性，根据 'dist' 字段
         */
        private class CellComparatorByDist implements Comparator<Cell> {
            @Override
            public int compare(Cell cell1, Cell cell2) {
                return cell1.dist - cell2.dist;
            }
        }

        /**
         * 处理鼠标移动绘制，包括障碍单元以及机器人和目标
         */
        private class MouseHandler implements MouseListener, MouseMotionListener {
            private int cur_row, cur_col, cur_val;

            @Override
            public void mousePressed(MouseEvent evt) {
                int row = (evt.getY() - 10) / squareSize;
                int col = (evt.getX() - 10) / squareSize;
                if (row >= 0 && row < rows && col >= 0 && col < columns) {
                    if (realTime ? true : !found && !searching) {

                        if (realTime) {
                            searching = true;
                            fillGrid();
                        }
                        cur_row = row;
                        cur_col = col;
                        cur_val = grid[row][col];
                        if (cur_val == EMPTY) {
                            grid[row][col] = OBST;
                        }
                        if (cur_val == OBST) {
                            grid[row][col] = EMPTY;
                        }
                        if (realTime) {
                            if (dijkstra.isSelected()) {
                                initializeDijkstra();
                            }
                        }
                    }
                }
                if (realTime) {
                    timer.setDelay(0);
                    timer.start();
                    checkTermination();
                } else {
                    repaint();
                }
            }

            @Override
            public void mouseDragged(MouseEvent evt) {
                int row = (evt.getY() - 10) / squareSize;
                int col = (evt.getX() - 10) / squareSize;
                if (row >= 0 && row < rows && col >= 0 && col < columns) {
                    if (realTime ? true : !found && !searching) {
                        if (realTime) {
                            searching = true;
                            fillGrid();
                        }
                        if ((row * columns + col != cur_row * columns + cur_col) && (cur_val == ROBOT || cur_val == TARGET)) {
                            int new_val = grid[row][col];
                            if (new_val == EMPTY) {
                                grid[row][col] = cur_val;
                                if (cur_val == ROBOT) {
                                    robotStart.row = row;
                                    robotStart.col = col;
                                } else {
                                    targetPos.row = row;
                                    targetPos.col = col;
                                }
                                grid[cur_row][cur_col] = new_val;
                                cur_row = row;
                                cur_col = col;
                                if (cur_val == ROBOT) {
                                    robotStart.row = cur_row;
                                    robotStart.col = cur_col;
                                } else {
                                    targetPos.row = cur_row;
                                    targetPos.col = cur_col;
                                }
                                cur_val = grid[row][col];
                            }
                        } else if (grid[row][col] != ROBOT && grid[row][col] != TARGET) {
                            grid[row][col] = OBST;
                        }
                        if (realTime) {
                            if (dijkstra.isSelected()) {
                                initializeDijkstra();
                            }
                        }
                    }
                }
                if (realTime) {
                    timer.setDelay(0);
                    timer.start();
                    checkTermination();
                } else {
                    repaint();
                }
            }

            @Override
            public void mouseReleased(MouseEvent evt) {
            }

            @Override
            public void mouseEntered(MouseEvent evt) {
            }

            @Override
            public void mouseExited(MouseEvent evt) {
            }

            @Override
            public void mouseMoved(MouseEvent evt) {
            }

            @Override
            public void mouseClicked(MouseEvent evt) {
            }

        }

        /**
         * 当用户按下一个按钮执行相应的功能
         */
        private class ActionHandler implements ActionListener {
            @Override
            public void actionPerformed(ActionEvent evt) {
                String cmd = evt.getActionCommand();
                if (cmd.equals("清除")) {
                    fillGrid();
                    realTime = false;
                    realTimeButton.setEnabled(true);
                    realTimeButton.setForeground(Color.black);
                    stepButton.setEnabled(true);
                    animationButton.setEnabled(true);
                    slider.setEnabled(true);
                    dfs.setEnabled(true);
                    bfs.setEnabled(true);
                    aStar.setEnabled(true);
                    greedy.setEnabled(true);
                    dijkstra.setEnabled(true);
                    diagonal.setEnabled(true);
                    drawArrows.setEnabled(true);
                } else if (cmd.equals("实时模式") && !realTime) {
                    realTime = true;
                    searching = true;
                    realTimeButton.setForeground(Color.red);
                    stepButton.setEnabled(false);
                    animationButton.setEnabled(false);
                    slider.setEnabled(false);
                    dfs.setEnabled(false);
                    bfs.setEnabled(false);
                    aStar.setEnabled(false);
                    greedy.setEnabled(false);
                    dijkstra.setEnabled(false);
                    diagonal.setEnabled(false);
                    drawArrows.setEnabled(false);
                    timer.setDelay(0);
                    timer.start();
                    if (dijkstra.isSelected()) {
                        initializeDijkstra();
                    }
                    checkTermination();
                } else if (cmd.equals("单步") && !found && !endOfSearch) {
                    realTime = false;
                    // Dijkstra 算法初始化工作需在搜索工作开始前完成,因为障碍物必须在里面。
                    if (!searching && dijkstra.isSelected()) {
                        initializeDijkstra();
                    }
                    searching = true;
                    message.setText(msgSelectStepByStepEtc);
                    realTimeButton.setEnabled(false);
                    dfs.setEnabled(false);
                    bfs.setEnabled(false);
                    aStar.setEnabled(false);
                    greedy.setEnabled(false);
                    dijkstra.setEnabled(false);
                    diagonal.setEnabled(false);
                    drawArrows.setEnabled(false);
                    timer.stop();
                    // 这里决定是否可以继续以“步进”模式来进行搜索。
                    // 如果是DFS,BFS,A*,Greedy算法，执行第2步:
                    // 2.如果 OPEN 集 = []，那么结束，没有可达路径。
                    checkTermination();
                    repaint();
                } else if (cmd.equals("动画模式") && !endOfSearch) {
                    realTime = false;
                    if (!searching && dijkstra.isSelected()) {
                        initializeDijkstra();
                    }
                    searching = true;
                    message.setText(msgSelectStepByStepEtc);
                    realTimeButton.setEnabled(false);
                    dfs.setEnabled(false);
                    bfs.setEnabled(false);
                    aStar.setEnabled(false);
                    greedy.setEnabled(false);
                    dijkstra.setEnabled(false);
                    diagonal.setEnabled(false);
                    drawArrows.setEnabled(false);
                    timer.setDelay(delay);
                    timer.start();
                } else if (cmd.equals("关于")) {
                    AboutBox aboutBox = new AboutBox(mazeFrame, true);
                    aboutBox.setVisible(true);
                }
            }
        }

        /**
         * 负责动画的类
         */
        private class RepaintAction implements ActionListener {
            @Override
            public void actionPerformed(ActionEvent evt) {
                // 这里决定是否可以继续以“动画”模式来进行搜索。
                // 如果是DFS,BFS,A*,Greedy算法，执行第2步:
                // 2.如果 OPEN 集 = []，那么结束，没有可达路径。
                checkTermination();
                if (found) {
                    timer.stop();
                }
                if (!realTime) {
                    repaint();
                }
            }
        }

        public void checkTermination() {
            if ((dijkstra.isSelected() && graph.isEmpty()) ||
                    (!dijkstra.isSelected() && openSet.isEmpty())) {
                endOfSearch = true;
                grid[robotStart.row][robotStart.col] = ROBOT;
                message.setText(msgNoSolution);
                stepButton.setEnabled(false);
                animationButton.setEnabled(false);
                slider.setEnabled(false);
                repaint();
            } else {
                expandNode();
                if (found) {
                    endOfSearch = true;
                    plotRoute();
                    stepButton.setEnabled(false);
                    animationButton.setEnabled(false);
                    slider.setEnabled(false);
                    repaint();
                }
            }
        }

        /**
         * AboutBox类
         */
        private class AboutBox extends JDialog {

            public AboutBox(Frame parent, boolean modal) {
                super(parent, modal);
                // 指定在屏幕中央显示
                Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
                double screenWidth = screenSize.getWidth();
                double ScreenHeight = screenSize.getHeight();
                int width = 350;
                int height = 190;
                int x = ((int) screenWidth - width) / 2;
                int y = ((int) ScreenHeight - height) / 2;
                setSize(width, height);
                setLocation(x, y);

                setResizable(false);
                setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);

                JLabel title = new JLabel("AI-PathFinding", JLabel.CENTER);
                title.setFont(new Font("Helvetica", Font.PLAIN, 24));
                title.setForeground(new java.awt.Color(255, 153, 102));

                JLabel version = new JLabel("Version: 1.0", JLabel.CENTER);
                version.setFont(new Font("Helvetica", Font.BOLD, 14));

                JLabel programmer = new JLabel("Designer: 张丹玉", JLabel.CENTER);
                programmer.setFont(new Font("Helvetica", Font.PLAIN, 16));

                JLabel email = new JLabel("E-mail: 1475811550@qq.com", JLabel.CENTER);
                email.setFont(new Font("Helvetica", Font.PLAIN, 14));

                JLabel dummy = new JLabel("");

                add(title);
                add(version);
                add(programmer);
                add(email);
                add(dummy);

                title.setBounds(5, 20, 330, 30);
                version.setBounds(5, 50, 330, 20);
                programmer.setBounds(5, 75, 330, 20);
                email.setBounds(5, 100, 330, 20);
                dummy.setBounds(5, 125, 330, 20);
            }
        } // 嵌套类 AboutBox

        /**
         * 创建一个随机的完美(无回路)迷宫
         * 这个类的代码根据stackoverflow上的原始评论改编：
         * http://stackoverflow.com/questions/18396364/maze-generation-arrayindexoutofboundsexception
         */
        private class MyMaze {
            private int dimensionX, dimensionY; // 迷宫的规格大小
            private int gridDimensionX, gridDimensionY; // 输出的网格大小
            private char[][] mazeGrid; // 输出网格
            private Cell[][] cells; // 单元格二维数组
            private Random random = new Random(); // 随机对象

            // 以相同的x,y值初始化
            public MyMaze(int aDimension) {
                // Initialize
                this(aDimension, aDimension);
            }

            // 构造函数
            public MyMaze(int xDimension, int yDimension) {
                dimensionX = xDimension;
                dimensionY = yDimension;
                gridDimensionX = xDimension * 2 + 1;
                gridDimensionY = yDimension * 2 + 1;
                mazeGrid = new char[gridDimensionX][gridDimensionY];
                init();
                generateMaze();
            }

            private void init() {
                // 创建单元格
                cells = new Cell[dimensionX][dimensionY];
                for (int x = 0; x < dimensionX; x++) {
                    for (int y = 0; y < dimensionY; y++) {
                        cells[x][y] = new Cell(x, y, false); // 创建单元格 (见Cell的构造函数)
                    }
                }
            }

            // 内部类 定义Cell
            private class Cell {
                int x, y; // 坐标
                // 与此单元格相邻的单元格数组
                ArrayList<Cell> neighbors = new ArrayList<>();
                // 是否为墙
                boolean wall = true;
                // 如果是true，还没有被生成
                boolean open = true;

                Cell(int x, int y) {
                    this(x, y, true);
                }

                Cell(int x, int y, boolean isWall) {
                    this.x = x;
                    this.y = y;
                    this.wall = isWall;
                }

                // 给这个单元格添加一个邻居，并且这个单元格也被添加为other单元格的邻居
                void addNeighbor(Cell other) {
                    if (!this.neighbors.contains(other)) { // 避免重复
                        this.neighbors.add(other);
                    }
                    if (!other.neighbors.contains(this)) { // 避免重复
                        other.neighbors.add(this);
                    }
                }

                // 用于 updateGrid()
                boolean isCellBelowNeighbor() {
                    return this.neighbors.contains(new Cell(this.x, this.y + 1));
                }

                // 用于 updateGrid()
                boolean isCellRightNeighbor() {
                    return this.neighbors.contains(new Cell(this.x + 1, this.y));
                }

                // 重写equals判断单元格相等
                @Override
                public boolean equals(Object other) {
                    if (!(other instanceof Cell)) return false;
                    Cell otherCell = (Cell) other;
                    return (this.x == otherCell.x && this.y == otherCell.y);
                }

                // 重写hashCode
                @Override
                public int hashCode() {
                    // 设计的随机哈希码方法通常是独一无二的
                    return this.x + this.y * 256;
                }

            }

            // 从左上角生成迷宫(在计算时，y值通常会增加)
            private void generateMaze() {
                generateMaze(0, 0);
            }

            // 从(x,y)处生成迷宫
            private void generateMaze(int x, int y) {
                generateMaze(getCell(x, y)); // 从单元格生成
            }

            private void generateMaze(Cell startAt) {
                // 不要从这些地方生成迷宫
                if (startAt == null) return;
                startAt.open = false; // 表示不用于生成迷宫
                ArrayList<Cell> cellsList = new ArrayList<>();
                cellsList.add(startAt);

                while (!cellsList.isEmpty()) {
                    Cell cell;
                    // 这是为了减少但仍不能完全消除较长且扭曲的迷宫路径的数量，在简单迷宫中简短的去探测分支数
                    if (random.nextInt(10) == 0)
                        cell = cellsList.remove(random.nextInt(cellsList.size()));
                    else cell = cellsList.remove(cellsList.size() - 1);
                    // 加入收藏
                    ArrayList<Cell> neighbors = new ArrayList<>();
                    // 可能是邻居的单元格
                    Cell[] potentialNeighbors = new Cell[]{
                            getCell(cell.x + 1, cell.y),
                            getCell(cell.x, cell.y + 1),
                            getCell(cell.x - 1, cell.y),
                            getCell(cell.x, cell.y - 1)
                    };
                    for (Cell other : potentialNeighbors) {
                        // 如果在外，该单元格是一堵墙或是不开
                        if (other == null || other.wall || !other.open) continue;
                        neighbors.add(other);
                    }
                    if (neighbors.isEmpty()) continue;
                    // 得到随机单元格
                    Cell selected = neighbors.get(random.nextInt(neighbors.size()));
                    // 添加为邻居
                    selected.open = false; // 表明单元格对生成关闭
                    cell.addNeighbor(selected);
                    cellsList.add(cell);
                    cellsList.add(selected);
                }
                updateGrid();
            }

            // 由(x,y)获得一个单元格;越界返回null
            public Cell getCell(int x, int y) {
                try {
                    return cells[x][y];
                } catch (ArrayIndexOutOfBoundsException e) {
                    return null;
                }
            }

            // 画迷宫
            public void updateGrid() {
                char backChar = ' ', wallChar = 'X', cellChar = ' ';
                // 填充背景
                for (int x = 0; x < gridDimensionX; x++) {
                    for (int y = 0; y < gridDimensionY; y++) {
                        mazeGrid[x][y] = backChar;
                    }
                }
                // 建墙
                for (int x = 0; x < gridDimensionX; x++) {
                    for (int y = 0; y < gridDimensionY; y++) {
                        if (x % 2 == 0 || y % 2 == 0)
                            mazeGrid[x][y] = wallChar;
                    }
                }
                // 进行有意义的表达
                for (int x = 0; x < dimensionX; x++) {
                    for (int y = 0; y < dimensionY; y++) {
                        Cell current = getCell(x, y);
                        int gridX = x * 2 + 1, gridY = y * 2 + 1;
                        mazeGrid[gridX][gridY] = cellChar;
                        if (current.isCellBelowNeighbor()) {
                            mazeGrid[gridX][gridY + 1] = cellChar;
                        }
                        if (current.isCellRightNeighbor()) {
                            mazeGrid[gridX + 1][gridY] = cellChar;
                        }
                    }
                }

                // 创建一张干净的网格
                searching = false;
                endOfSearch = false;
                fillGrid();
                // ... 将迷宫构建算法生成的障碍物复制到其位置上
                for (int x = 0; x < gridDimensionX; x++) {
                    for (int y = 0; y < gridDimensionY; y++) {
                        if (mazeGrid[x][y] == wallChar && grid[x][y] != ROBOT && grid[x][y] != TARGET) {
                            grid[x][y] = OBST;
                        }
                    }
                }
            }
        } // 嵌套类 MyMaze

        /*
         **********************************************************
         *          MazePanel类的常量
         **********************************************************
         */

        private final static int
                INFINITY = Integer.MAX_VALUE, // 无穷大
                EMPTY = 0,  // 空单元
                OBST = 1,  // 阻塞单元
                ROBOT = 2,  // 机器人的位置
                TARGET = 3,  // 目标的位置
                FRONTIER = 4,  // 首个单元格（Open表）
                CLOSED = 5,  // Closed表单元格
                ROUTE = 6;  // 机器人到目标的路径

        // 给用户的消息
        private final static String
                msgDrawAndSelect =
                "画障碍物, 然后点击 '实时模式' 或 '单步' 或 '动画模式'",
                msgSelectStepByStepEtc =
                        "点击 '单步' 或 '动画模式' 或 '清除'",
                msgNoSolution =
                        "没有路径可以到达目标!!!";

        /*
         **********************************************************
         *          MazePanel类的成员变量
         **********************************************************
         */

        JSpinner rowsSpinner, columnsSpinner; // 输入 # 行和列

        int rows = 45,           // 网格的默认行数
                columns = 45,           // 网格的默认列数
                squareSize = 500 / rows;  // 单元格的像素大小


        int arrowSize = squareSize / 2; // 提示箭头的大小,指向前驱单元格
        ArrayList<Cell> openSet = new ArrayList();// Open集
        ArrayList<Cell> closedSet = new ArrayList();// Closed集
        ArrayList<Cell> graph = new ArrayList();// 图的顶点集
        //由Dijkstra算法探索

        Cell robotStart; // 机器人的初始位置
        Cell targetPos;  // 目标的位置

        JLabel message;  // 展示给用户的消息

        // 基本按钮
        JButton resetButton, mazeButton, clearButton, realTimeButton, stepButton, animationButton;

        // 选取算法的按钮
        JRadioButton dfs, bfs, aStar, greedy, dijkstra;

        // 滑块用于调整动画速度
        JSlider slider;

        // 是否允许对角移动
        JCheckBox diagonal;
        // 向前驱画箭头
        JCheckBox drawArrows;

        int[][] grid;        // 网格
        boolean realTime;    // 立即显示解决方案
        boolean found;       // 目标被发现的标志
        boolean searching;   // 搜索正在进行中的标志
        boolean endOfSearch; // 搜索结束的标志
        int delay;           // 动画的延迟时间（毫秒）
        int expanded;        // 已扩展的节点数

        // 控制动画的对象
        RepaintAction action = new RepaintAction();

        // 控制动画执行速度的计时器
        Timer timer;

        /**
         * MazePanel构造函数
         */
        public MazePanel(int width, int height) {

            setLayout(null);

            MouseHandler listener = new MouseHandler();
            addMouseListener(listener);
            addMouseMotionListener(listener);

            setBorder(BorderFactory.createMatteBorder(2, 2, 2, 2, Color.blue));

            setPreferredSize(new Dimension(width, height));

            grid = new int[rows][columns];

            // 创建面板的内容

            message = new JLabel(msgDrawAndSelect, JLabel.CENTER);
            message.setForeground(Color.blue);
            message.setFont(new Font("Helvetica", Font.PLAIN, 16));

            JLabel rowsLbl = new JLabel("# 行数 (5-100):", JLabel.RIGHT);
            rowsLbl.setFont(new Font("Helvetica", Font.PLAIN, 13));

            SpinnerModel rowModel = new SpinnerNumberModel(45, // 初始化值
                    5,  // 最小范围
                    100, // 最大范围
                    1); // 步进
            rowsSpinner = new JSpinner(rowModel);

            JLabel columnsLbl = new JLabel("# 列数 (5-100):", JLabel.RIGHT);
            columnsLbl.setFont(new Font("Helvetica", Font.PLAIN, 13));

            SpinnerModel colModel = new SpinnerNumberModel(45, // 初始化值
                    5,  // 最小范围
                    100, // 最大范围
                    1); // 步进
            columnsSpinner = new JSpinner(colModel);

            resetButton = new JButton("复位");
            resetButton.addActionListener(new ActionHandler());
            resetButton.setBackground(Color.lightGray);
            resetButton.setToolTipText
                    ("根据给定的行和列清除和重绘网格地图");
            resetButton.addActionListener(this::resetButtonActionPerformed);

            mazeButton = new JButton("迷宫");
            mazeButton.addActionListener(new ActionHandler());
            mazeButton.setBackground(Color.lightGray);
            mazeButton.setToolTipText
                    ("随机生成一个完美迷宫");
            mazeButton.addActionListener(this::mazeButtonActionPerformed);

            clearButton = new JButton("清除");
            clearButton.addActionListener(new ActionHandler());
            clearButton.setBackground(Color.lightGray);
            clearButton.setToolTipText
                    ("第一次点击: 清除搜索结果, 第二次点击: 清除障碍物");

            realTimeButton = new JButton("实时模式");
            realTimeButton.addActionListener(new ActionHandler());
            realTimeButton.setBackground(Color.lightGray);
            realTimeButton.setToolTipText
                    ("当搜索正在进行时，障碍物、机器人和目标的位置均可以改变");

            stepButton = new JButton("单步");

            stepButton.addActionListener(new ActionHandler());
            stepButton.setBackground(Color.lightGray);
            stepButton.setToolTipText
                    ("每一次点击，搜索是一步一步进行的");

            animationButton = new JButton("动画模式");
            animationButton.addActionListener(new ActionHandler());
            animationButton.setBackground(Color.lightGray);
            animationButton.setToolTipText
                    ("自动执行搜索");

            JLabel velocity = new JLabel("动画速度", JLabel.CENTER);
            velocity.setFont(new Font("Helvetica", Font.PLAIN, 10));

            slider = new JSlider(0, 1000, 500); // 初始值是延迟500毫秒
            slider.setToolTipText
                    ("调节每一步的延迟（0至1秒）");

            delay = 1000 - slider.getValue();
            slider.addChangeListener((ChangeEvent evt) -> {
                JSlider source = (JSlider) evt.getSource();
                if (!source.getValueIsAdjusting()) {
                    delay = 1000 - source.getValue();
                }
            });

            // 五个算法选择按钮，只能选中其中一个
            ButtonGroup algoGroup = new ButtonGroup();

            dfs = new JRadioButton("DFS");
            dfs.setToolTipText("深度优先搜索算法");
            algoGroup.add(dfs);
            dfs.addActionListener(new ActionHandler());

            bfs = new JRadioButton("BFS");
            bfs.setToolTipText("广度优先搜索算法");
            algoGroup.add(bfs);
            bfs.addActionListener(new ActionHandler());

            aStar = new JRadioButton("A*");
            aStar.setToolTipText("A* 算法");
            algoGroup.add(aStar);
            aStar.addActionListener(new ActionHandler());

            greedy = new JRadioButton("Greedy");
            greedy.setToolTipText("贪婪搜索算法");
            algoGroup.add(greedy);
            greedy.addActionListener(new ActionHandler());

            dijkstra = new JRadioButton("Dijkstra");
            dijkstra.setToolTipText("Dijkstra 算法");
            algoGroup.add(dijkstra);
            dijkstra.addActionListener(new ActionHandler());

            JPanel algoPanel = new JPanel();
            algoPanel.setBorder(javax.swing.BorderFactory.
                    createTitledBorder(javax.swing.BorderFactory.createEtchedBorder(),
                            "算法", javax.swing.border.TitledBorder.DEFAULT_JUSTIFICATION,
                            javax.swing.border.TitledBorder.TOP, new java.awt.Font("Helvetica", 0, 14)));

            dfs.setSelected(true);  // 默认选择DFS算法

            diagonal = new
                    JCheckBox("八方向");
            diagonal.setToolTipText("允许对角线方向上的运动");

            drawArrows = new
                    JCheckBox("箭头指向前驱");
            drawArrows.setToolTipText("向前驱画箭头");

            JLabel robot = new JLabel("机器人", JLabel.CENTER);
            robot.setForeground(Color.red);
            robot.setFont(new Font("Helvetica", Font.PLAIN, 14));

            JLabel target = new JLabel("目标", JLabel.CENTER);
            target.setForeground(Color.GREEN);
            target.setFont(new Font("Helvetica", Font.PLAIN, 14));

            JLabel frontier = new JLabel("首端", JLabel.CENTER);
            frontier.setForeground(Color.blue);
            frontier.setFont(new Font("Helvetica", Font.PLAIN, 14));

            JLabel closed = new JLabel("Closed表", JLabel.CENTER);
            closed.setForeground(Color.CYAN);
            closed.setFont(new Font("Helvetica", Font.PLAIN, 14));

            JButton aboutButton = new JButton("关于");
            aboutButton.addActionListener(new ActionHandler());
            aboutButton.setBackground(Color.lightGray);

            // 向面板添加控件
            add(message);
            add(rowsLbl);
            add(rowsSpinner);
            add(columnsLbl);
            add(columnsSpinner);
            add(resetButton);
            add(mazeButton);
            add(clearButton);
            add(realTimeButton);
            add(stepButton);
            add(animationButton);
            add(velocity);
            add(slider);
            add(dfs);
            add(bfs);
            add(aStar);
            add(greedy);
            add(dijkstra);
            add(algoPanel);
            add(diagonal);
            add(drawArrows);
            add(robot);
            add(target);
            add(frontier);
            add(closed);
            add(aboutButton);

            // 指定控件的位置和大小
            message.setBounds(0, 515, 500, 23);
            rowsLbl.setBounds(520, 5, 130, 25);
            rowsSpinner.setBounds(655, 5, 35, 25);
            columnsLbl.setBounds(520, 35, 130, 25);
            columnsSpinner.setBounds(655, 35, 35, 25);
            resetButton.setBounds(520, 65, 170, 25);
            mazeButton.setBounds(520, 95, 170, 25);
            clearButton.setBounds(520, 125, 170, 25);
            realTimeButton.setBounds(520, 155, 170, 25);
            stepButton.setBounds(520, 185, 170, 25);
            animationButton.setBounds(520, 215, 170, 25);
            velocity.setBounds(520, 245, 170, 10);
            slider.setBounds(520, 255, 170, 25);
            dfs.setBounds(530, 300, 70, 25);
            bfs.setBounds(600, 300, 70, 25);
            aStar.setBounds(530, 325, 70, 25);
            greedy.setBounds(600, 325, 85, 25);
            dijkstra.setBounds(530, 350, 85, 25);
            algoPanel.setLocation(520, 280);
            algoPanel.setSize(170, 100);
            diagonal.setBounds(520, 385, 170, 25);
            drawArrows.setBounds(520, 410, 170, 25);
            robot.setBounds(520, 465, 80, 25);
            target.setBounds(605, 465, 80, 25);
            frontier.setBounds(520, 485, 80, 25);
            closed.setBounds(605, 485, 80, 25);
            aboutButton.setBounds(520, 515, 170, 25);

            // 创建计时器
            timer = new Timer(delay, action);

            // 将初始化值附加到网格中的单元格上，这是寻路算法的第一步
            fillGrid();

        }

        static protected JSpinner addLabeledSpinner(Container c,
                                                    String label,
                                                    SpinnerModel model) {
            JLabel l = new JLabel(label);
            c.add(l);

            JSpinner spinner = new JSpinner(model);
            l.setLabelFor(spinner);
            c.add(spinner);

            return spinner;
        }

        /**
         * 如果用户按“复位”按钮执行功能
         */
        private void resetButtonActionPerformed(java.awt.event.ActionEvent evt) {
            realTime = false;
            realTimeButton.setEnabled(true);
            realTimeButton.setForeground(Color.black);
            stepButton.setEnabled(true);
            animationButton.setEnabled(true);
            slider.setEnabled(true);
            initializeGrid(false);
        }

        /**
         * 如果用户按下按钮“迷宫”，执行功能
         */
        private void mazeButtonActionPerformed(java.awt.event.ActionEvent evt) {
            realTime = false;
            realTimeButton.setEnabled(true);
            realTimeButton.setForeground(Color.black);
            stepButton.setEnabled(true);
            animationButton.setEnabled(true);
            slider.setEnabled(true);
            initializeGrid(true);
        }

        /**
         * 创建一个新的干净的网格或一个新的迷宫
         */
        private void initializeGrid(Boolean makeMaze) {
            rows = (int) (rowsSpinner.getValue());
            columns = (int) (columnsSpinner.getValue());
            squareSize = 500 / (rows > columns ? rows : columns);
            arrowSize = squareSize / 2;
            // 迷宫必须有一个奇数行和列
            if (makeMaze && rows % 2 == 0) {
                rows -= 1;
            }
            if (makeMaze && columns % 2 == 0) {
                columns -= 1;
            }
            grid = new int[rows][columns];
            robotStart = new Cell(rows - 2, 1);
            targetPos = new Cell(1, columns - 2);
            dfs.setEnabled(true);
            dfs.setSelected(true);
            bfs.setEnabled(true);
            aStar.setEnabled(true);
            greedy.setEnabled(true);
            dijkstra.setEnabled(true);
            diagonal.setSelected(false);
            diagonal.setEnabled(true);
            drawArrows.setSelected(false);
            drawArrows.setEnabled(true);
            slider.setValue(500);
            if (makeMaze) {
                MyMaze maze = new MyMaze(rows / 2, columns / 2);
            } else {
                fillGrid();
            }
        }

        /**
         * 扩展一个节点并创建他的后继
         */
        private void expandNode() {
            // 分开处理Dijkstra算法
            if (dijkstra.isSelected()) {
                Cell u;
                // 11: 当图Q非空时:
                if (graph.isEmpty()) {
                    return;
                }
                // 12:  u:= dist[]里拥有最小dist值的图Q顶点
                // 13:  从图Q中移除u
                u = graph.remove(0);
                // 将顶点u加进closed集
                closedSet.add(u);
                // 如果发现目标...
                if (u.row == targetPos.row && u.col == targetPos.col) {
                    found = true;
                    return;
                }
                // 计算扩展的节点个数
                expanded++;
                // 更新单元格的颜色
                grid[u.row][u.col] = CLOSED;
                // 14: 如果 dist[u] = infinity
                if (u.dist == INFINITY) {
                    // ... 那么没有可路径可以到达目标
                    // 15: 返回;
                    return;
                    // 16: 判断结束
                }
                // 创建u的邻居
                ArrayList<Cell> neighbors = createSuccesors(u, false);
                // 18: 对节点 u 的每个邻居 v :
                neighbors.stream().forEach((v) -> {
                    // 20: alt := dist[u] + dist_between(u, v) ;
                    int alt = u.dist + distBetween(u, v);
                    // 21: 如果 alt < dist[v]:
                    if (alt < v.dist) {
                // 22: dist[v] := alt ;
                v.dist = alt;
                // 23: previous[v] := u ;
                v.prev = u;
                // 更新单元格颜色
                grid[v.row][v.col] = FRONTIER;
                // 24: 降序排列图 Q 中的顶点 v
                // (已根据dist值排好序的节点列表)
                Collections.sort(graph, new CellComparatorByDist());
            }
            });
        } else {
                Cell current;
                if (dfs.isSelected() || bfs.isSelected()) {
                    // 这是DFS和BFS算法的第3步：
                    // 3. 从OPEN集移除首节点Si
                    current = openSet.remove(0);
                } else {
                    // 这是A*和Greedy算法的第3步：
                    // 3. 从OPEN集移除首节点Si, f(Si) ≤ f(Sj),Sj是OPEN集中其他任意节点
                    // (提前根据'f'值排序好的OPEN集列表)
                    Collections.sort(openSet, new CellComparatorByF());
                    current = openSet.remove(0);
                }
                // ... 并将其移进CLOSED集
                closedSet.add(0, current);
                // 更新单元格颜色
                grid[current.row][current.col] = CLOSED;
                // 如果此节点是目标的话...
                if (current.row == targetPos.row && current.col == targetPos.col) {
                    // ... 即将终止搜索
                    Cell last = targetPos;
                    last.prev = current.prev;
                    closedSet.add(last);
                    found = true;
                    return;
                }
                // 对已扩展的节点计数
                expanded++;
                // 这里是算法的第四步：
                // 4. 创建Si的后继，可以根据Si的行动实现。
                //    每一个后继节点都有一个指向Si的指针，作为其前驱指针。
                //    在DFS和BFS算法的情况下，后继节点既不属于OPEN集也不属于CLOSED集
                ArrayList<Cell> succesors;
                succesors = createSuccesors(current, false);
                // 这里是算法的第5步：
                // 5. 对Si的每个后继节点, ...
                succesors.stream().forEach((cell) -> {
                    // ... 如果是在执行DFS...
                    if (dfs.isSelected()) {
                        // ... 深搜，将后继节点移进OPEN集的顶端
                        openSet.add(0, cell);
                        // 更新单元格颜色
                        grid[cell.row][cell.col] = FRONTIER;
                        // ... 如果是在执行BFS...
                    } else if (bfs.isSelected()) {
                        // ... 广搜，将后继节点添进OPEN集的末端
                        openSet.add(cell);
                        // 更新单元格的颜色
                        grid[cell.row][cell.col] = FRONTIER;
                        // ... 如果是在执行A*或Greedy算法(A*算法的第5步)
                    } else if (aStar.isSelected() || greedy.isSelected()) {
                        // ... 计算f(Sj)的值
                        int dxg = current.col - cell.col;
                        int dyg = current.row - cell.row;
                        int dxh = targetPos.col - cell.col;
                        int dyh = targetPos.row - cell.row;
                        if (diagonal.isSelected()) {
                            // 对角移动
                            // 计算1000倍的Euclidean距离
                            if (greedy.isSelected()) {
                                // 对于Greedy算法，将g估值置0
                                cell.g = 0;
                            } else {
                                cell.g = current.g + (int) ((double) 1000 * Math.sqrt(dxg * dxg + dyg * dyg));
                            }
                            cell.h = (int) ((double) 1000 * Math.sqrt(dxh * dxh + dyh * dyh));
                        } else {
                            // 非对角移动
                            // 计算Manhattan距离
                            if (greedy.isSelected()) {
                                // 对于Greedy算法，将g估值置为0
                                cell.g = 0;
                            } else {
                                cell.g = current.g + Math.abs(dxg) + Math.abs(dyg);
                            }
                            cell.h = Math.abs(dxh) + Math.abs(dyh);
                        }
                        cell.f = cell.g + cell.h;
                        // ... 如果Sj既不在OPEN集也不在CLOSED集 ...
                        int openIndex = isInList(openSet, cell);
                        int closedIndex = isInList(closedSet, cell);
                        if (openIndex == -1 && closedIndex == -1) {
                            // ... 那么将Sj移进OPEN集 ...
                            // ... 评估f(Sj)
                            openSet.add(cell);
                            // 更新单元格颜色
                            grid[cell.row][cell.col] = FRONTIER;
                        } else {
                            // ... 如果已经在OPEN集中，那么 ...
                            if (openIndex > -1) {
                                // ... 拿新估值与旧估值作比较
                                // 如果 old <= new ...
                                if (openSet.get(openIndex).f <= cell.f) {
                                    // ... 然后将新节点Sj弹出
                                    // (即不对此节点做任何操作).
                                    // 否则, ...
                                } else {
                                    // ... 从其所属的list移除元素(Sj,old)
                                    openSet.remove(openIndex);
                                    // ... 并且将(Sj,new)添进OPEN集
                                    openSet.add(cell);
                                    // 更新单元格颜色
                                    grid[cell.row][cell.col] = FRONTIER;
                                }
                                // ... 如果早就属于CLOSED集，那么...
                            } else {
                                // 拿新估值与旧估值作比较
                                // 如果 old <= new ...
                                if (closedSet.get(closedIndex).f <= cell.f) {
                                    // ... 然后将新节点Sj弹出
                                    // (即不对此节点做任何操作).
                                    // 否则, ...
                                } else {
                                    // ... 从其所属的list移除元素(Sj,old)
                                    closedSet.remove(closedIndex);
                                    // ... 并且将(Sj,new)添进OPEN集
                                    openSet.add(cell);
                                    // 更新单元格颜色
                                    grid[cell.row][cell.col] = FRONTIER;
                                }
                            }
                        }
                    }
                });
            }
        }

        /**
         * 创建一个状态/单元格的后继
         *
         * @param current       要找后继节点的单元格
         * @param makeConnected 该标志表示仅靠单元格的坐标而不需要'dist'标签(Dijkstra算法才需要)
         *
         * @return 返回单元格的后继节点列表
         */
        private ArrayList<Cell> createSuccesors(Cell current, boolean makeConnected) {
            int r = current.row;
            int c = current.col;
            // 为当前单元格的后继们创建一个空list
            ArrayList<Cell> temp = new ArrayList<>();
            // 对角移动的优先级是：
            // 1: 上 2: 右上 3: 右 4: 右下
            // 5: 下 6: 左下 7: 左 8: 左上

            // 四方向移动的优先级是：
            // 1: 上 2: 右 3: 下 4: 左

            // 如果不在网格的最顶端边界处，并且上边的单元格不是一个障碍物
            if (r > 0 && grid[r - 1][c] != OBST &&
                    // …（只有在本案例中，不属于A*或Greedy）既不属于OPEN集，也不属于CLOSED集
                    ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                            isInList(openSet, new Cell(r - 1, c)) == -1 &&
                                    isInList(closedSet, new Cell(r - 1, c)) == -1)) {
                Cell cell = new Cell(r - 1, c);
                // 在Dijkstra算法的情况下，不能将刚刚创建的"naked"单元格附加到后继列表。
                // 单元格必须附有'dist'标签，所以需要全程跟踪'graph'列表，然后将其复制到后继列表中。
                // 必须要有makeConnected标志，
                // 才能使目前的createSucdesors()方法与findConnectedComponent()结合，
                // 当Dijkstra算法初始化时创建连接组件
                if (dijkstra.isSelected()) {
                    if (makeConnected) {
                        temp.add(cell);
                    } else {
                        int graphIndex = isInList(graph, cell);
                        if (graphIndex > -1) {
                            temp.add(graph.get(graphIndex));
                        }
                    }
                } else {
                    // ... 更新上侧单元格的指针，让它指向当前的节点
                    cell.prev = current;
                    // ... 并且将上侧单元格添进当前结点的后继
                    temp.add(cell);
                }
            }
            if (diagonal.isSelected()) {
                // 如果不在网格的上边界也不在网格的右边界，并且右上角单元格不是障碍物…
                if (r > 0 && c < columns - 1 && grid[r - 1][c + 1] != OBST &&
                        // ... 并且上侧或右侧单元格不是障碍物 ...
                        // (因为允许机器人通过一个'slot'是不合理的)
                        (grid[r - 1][c] != OBST || grid[r][c + 1] != OBST) &&
                        // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                        ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                                isInList(openSet, new Cell(r - 1, c + 1)) == -1 &&
                                        isInList(closedSet, new Cell(r - 1, c + 1)) == -1)) {
                    Cell cell = new Cell(r - 1, c + 1);
                    if (dijkstra.isSelected()) {
                        if (makeConnected) {
                            temp.add(cell);
                        } else {
                            int graphIndex = isInList(graph, cell);
                            if (graphIndex > -1) {
                                temp.add(graph.get(graphIndex));
                            }
                        }
                    } else {
                        // ... 更新右上角单元格的指针，让它指向当前的节点
                        cell.prev = current;
                        // ... 并且将右上角单元格添进当前结点的后继
                        temp.add(cell);
                    }
                }
            }
            // 如果不在网格的右边界并且右侧单元格不是障碍物…
            if (c < columns - 1 && grid[r][c + 1] != OBST &&
                    // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                    ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                            isInList(openSet, new Cell(r, c + 1)) == -1 &&
                                    isInList(closedSet, new Cell(r, c + 1)) == -1)) {
                Cell cell = new Cell(r, c + 1);
                if (dijkstra.isSelected()) {
                    if (makeConnected) {
                        temp.add(cell);
                    } else {
                        int graphIndex = isInList(graph, cell);
                        if (graphIndex > -1) {
                            temp.add(graph.get(graphIndex));
                        }
                    }
                } else {
                    // ... 更新右侧单元格的指针，让它指向当前的节点
                    cell.prev = current;
                    // ... 并且将右侧单元格添进当前结点的后继
                    temp.add(cell);
                }
            }
            if (diagonal.isSelected()) {
                // 如果不在网格的下边界也不在网格的右边界，并且右下角单元格不是障碍物…
                if (r < rows - 1 && c < columns - 1 && grid[r + 1][c + 1] != OBST &&
                        // ... 并且下侧或右侧单元格不是障碍物 ...
                        // (因为允许机器人通过一个'slot'是不合理的)
                        (grid[r + 1][c] != OBST || grid[r][c + 1] != OBST) &&
                        // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                        ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                                isInList(openSet, new Cell(r + 1, c + 1)) == -1 &&
                                        isInList(closedSet, new Cell(r + 1, c + 1)) == -1)) {
                    Cell cell = new Cell(r + 1, c + 1);
                    if (dijkstra.isSelected()) {
                        if (makeConnected) {
                            temp.add(cell);
                        } else {
                            int graphIndex = isInList(graph, cell);
                            if (graphIndex > -1) {
                                temp.add(graph.get(graphIndex));
                            }
                        }
                    } else {
                        // ... 更新右下角单元格的指针，让它指向当前的节点
                        cell.prev = current;
                        // ... 并且将右下角单元格添进当前结点的后继
                        temp.add(cell);
                    }
                }
            }
            // 如果不在网格的下边界并且下侧单元格不是障碍物…
            if (r < rows - 1 && grid[r + 1][c] != OBST &&
                    // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                    ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                            isInList(openSet, new Cell(r + 1, c)) == -1 &&
                                    isInList(closedSet, new Cell(r + 1, c)) == -1)) {
                Cell cell = new Cell(r + 1, c);
                if (dijkstra.isSelected()) {
                    if (makeConnected) {
                        temp.add(cell);
                    } else {
                        int graphIndex = isInList(graph, cell);
                        if (graphIndex > -1) {
                            temp.add(graph.get(graphIndex));
                        }
                    }
                } else {
                    // ... 更新下侧单元格的指针，让它指向当前的节点
                    cell.prev = current;
                    // ... 并且将下侧单元格添进当前结点的后继
                    temp.add(cell);
                }
            }
            if (diagonal.isSelected()) {
                // 如果不在网格的下边界也不在网格的左边界，并且左下角单元格不是障碍物…
                if (r < rows - 1 && c > 0 && grid[r + 1][c - 1] != OBST &&
                        // ... 并且下侧或左侧单元格不是障碍物 ...
                        // (因为允许机器人通过一个'slot'是不合理的)
                        (grid[r + 1][c] != OBST || grid[r][c - 1] != OBST) &&
                        // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                        ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                                isInList(openSet, new Cell(r + 1, c - 1)) == -1 &&
                                        isInList(closedSet, new Cell(r + 1, c - 1)) == -1)) {
                    Cell cell = new Cell(r + 1, c - 1);
                    if (dijkstra.isSelected()) {
                        if (makeConnected) {
                            temp.add(cell);
                        } else {
                            int graphIndex = isInList(graph, cell);
                            if (graphIndex > -1) {
                                temp.add(graph.get(graphIndex));
                            }
                        }
                    } else {
                        // ... 更新左下角单元格的指针，让它指向当前的节点
                        cell.prev = current;
                        // ... 并且将左下角单元格添进当前结点的后继
                        temp.add(cell);
                    }
                }
            }
            // 如果不在网格的左边框并且左侧单元格不是障碍物…
            if (c > 0 && grid[r][c - 1] != OBST &&
                    // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                    ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                            isInList(openSet, new Cell(r, c - 1)) == -1 &&
                                    isInList(closedSet, new Cell(r, c - 1)) == -1)) {
                Cell cell = new Cell(r, c - 1);
                if (dijkstra.isSelected()) {
                    if (makeConnected) {
                        temp.add(cell);
                    } else {
                        int graphIndex = isInList(graph, cell);
                        if (graphIndex > -1) {
                            temp.add(graph.get(graphIndex));
                        }
                    }
                } else {
                    // ... 更新左侧单元格的指针，让它指向当前的节点
                    cell.prev = current;
                    // ... 并且将左侧单元格添进当前结点的后继
                    temp.add(cell);
                }
            }
            if (diagonal.isSelected()) {
                // 如果不在网格的上边界也不在网格的左边界，并且左上角单元格不是障碍物…
                if (r > 0 && c > 0 && grid[r - 1][c - 1] != OBST &&
                        // ... 并且上侧或左侧单元格不是障碍物 ...
                        // (因为允许机器人通过一个'slot'是不合理的)
                        (grid[r - 1][c] != OBST || grid[r][c - 1] != OBST) &&
                        // ... 并且(仅当没有执行A*或Greedy算法时)不属于OPEN集也不属于CLOSED集 ...
                        ((aStar.isSelected() || greedy.isSelected() || dijkstra.isSelected()) ? true :
                                isInList(openSet, new Cell(r - 1, c - 1)) == -1 &&
                                        isInList(closedSet, new Cell(r - 1, c - 1)) == -1)) {
                    Cell cell = new Cell(r - 1, c - 1);
                    if (dijkstra.isSelected()) {
                        if (makeConnected) {
                            temp.add(cell);
                        } else {
                            int graphIndex = isInList(graph, cell);
                            if (graphIndex > -1) {
                                temp.add(graph.get(graphIndex));
                            }
                        }
                    } else {
                        // ... 更新左上角单元格的指针，让它指向当前的节点
                        cell.prev = current;
                        // ... 并且将左上角单元格添进当前结点的后继
                        temp.add(cell);
                    }
                }
            }
            // 当使用DFS算法时，单元格会被一个一个移进Open栈顶。
            // 因此，必须将后继表逆序，所以，对应最高优先级的后继节点会被放置在表头。
            // 对于Greedy,A*,Dijkstra算法没有这个问题，
            // 因为open表在提取首元素前是根据'f'或'dist'值有序排列的。
            if (dfs.isSelected()) {
                Collections.reverse(temp);
            }
            return temp;
        }

        /**
         * 返回'current'单元格在'list'列表的索引号
         *
         * @param list    待搜索的列表
         * @param current 待搜索的单元格
         * @return 单元格在列表中的索引号
         * 如果没找到返回 -1
         */
        private int isInList(ArrayList<Cell> list, Cell current) {
            int index = -1;
            for (int i = 0; i < list.size(); i++) {
                if (current.row == list.get(i).row && current.col == list.get(i).col) {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /**
         * 返回'current'单元格的前驱节点
         *
         * @param list    待搜索的列表
         * @param current 待搜索的单元格
         * @return 'current'单元格的前驱
         */
        private Cell findPrev(ArrayList<Cell> list, Cell current) {
            int index = isInList(list, current);
            return list.get(index).prev;
        }

        /**
         * 返回两个单元格之间的距离
         *
         * @param u 首单元格
         * @param v 其余单元格
         * @return u 和 v 之间的距离
         */
        private int distBetween(Cell u, Cell v) {
            int dist;
            int dx = u.col - v.col;
            int dy = u.row - v.row;
            if (diagonal.isSelected()) {
                // 对角移动
                // 计算1000倍的Euclidean距离
                dist = (int) ((double) 1000 * Math.sqrt(dx * dx + dy * dy));
            } else {
                // 非对角移动
                // 计算manhattan距离
                dist = Math.abs(dx) + Math.abs(dy);
            }
            return dist;
        }

        /**
         * 计算从目标到机器人初始位置的路径，统计相应的步数并且测量旅行距离
         */
        private void plotRoute() {
            searching = false;
            endOfSearch = true;
            int steps = 0;
            double distance = 0;
            int index = isInList(closedSet, targetPos);
            Cell cur = closedSet.get(index);
            grid[cur.row][cur.col] = TARGET;
            do {
                steps++;
                if (diagonal.isSelected()) {
                    int dx = cur.col - cur.prev.col;
                    int dy = cur.row - cur.prev.row;
                    distance += Math.sqrt(dx * dx + dy * dy);
                } else {
                    distance++;
                }
                cur = cur.prev;
                grid[cur.row][cur.col] = ROUTE;
            } while (!(cur.row == robotStart.row && cur.col == robotStart.col));
            grid[robotStart.row][robotStart.col] = ROBOT;
            String msg;
            msg = String.format("搜索节点: %d, 步数: %d, 距离: %.3f",
                    expanded, steps, distance);
            message.setText(msg);

        }

        /**
         * 给网格中的单元格初始化值
         * 当第一次点击'清除'时清除刚进行过的搜索数据(Frontier,Closed集,Rout)
         * 并且彻底丢弃障碍物、机器人和目标的位置数据
         * 为了能够使用一些数据去执行另一个寻路算法
         * 当第二次点击时，清除迷宫面板上的障碍物
         */
        private void fillGrid() {
            if (searching || endOfSearch) {
                for (int r = 0; r < rows; r++) {
                    for (int c = 0; c < columns; c++) {
                        if (grid[r][c] == FRONTIER || grid[r][c] == CLOSED || grid[r][c] == ROUTE) {
                            grid[r][c] = EMPTY;
                        }
                        if (grid[r][c] == ROBOT) {
                            robotStart = new Cell(r, c);
                        }
                        if (grid[r][c] == TARGET) {
                            targetPos = new Cell(r, c);
                        }
                    }
                }
                searching = false;
            } else {
                for (int r = 0; r < rows; r++) {
                    for (int c = 0; c < columns; c++) {
                        grid[r][c] = EMPTY;
                    }
                }
                robotStart = new Cell(rows - 2, 1);
                targetPos = new Cell(1, columns - 2);
            }
            if (aStar.isSelected() || greedy.isSelected()) {
                robotStart.g = 0;
                robotStart.h = 0;
                robotStart.f = 0;
            }
            expanded = 0;
            found = false;
            searching = false;
            endOfSearch = false;

            // 这里是另外四种算法的第一步
            // 1. OPEN SET: = [So], CLOSED SET: = []
            openSet.removeAll(openSet);
            openSet.add(robotStart);
            closedSet.removeAll(closedSet);

            grid[targetPos.row][targetPos.col] = TARGET;
            grid[robotStart.row][robotStart.col] = ROBOT;
            message.setText(msgDrawAndSelect);
            timer.stop();
            repaint();
        }

        /**
         * 添加到含图节点的列表中，
         * 该图只有和节点v属于同一个连通分量的单元格。
         * 这是一个以节点v起始的图的广度优先搜索
         *
         * @param v 起始节点
         */
        private void findConnectedComponent(Cell v) {
            Stack<Cell> stack;
            stack = new Stack();
            ArrayList<Cell> succesors;
            stack.push(v);
            graph.add(v);
            while (!stack.isEmpty()) {
                v = stack.pop();
                succesors = createSuccesors(v, true);
                for (Cell c : succesors) {
                    if (isInList(graph, c) == -1) {
                        stack.push(c);
                        graph.add(c);
                    }
                }
            }
        }

        /**
         * Dijkstra算法的初始化
         */
        private void initializeDijkstra() {
            // 机器人所处的位置作为初始化位置，并建立连接组件
            graph.removeAll(graph);
            findConnectedComponent(robotStart);
            // 此处是 Dijkstra算法的初始化
            // 2: 对图中的每个顶点v做处理
            for (Cell v : graph) {
                // 3: dist[v] := infinity ;
                v.dist = INFINITY;
                // 5: previous[v] := undefined ;
                v.prev = null;
            }
            // 8: dist[source] := 0;
            graph.get(isInList(graph, robotStart)).dist = 0;
            // 9: Q := 图中所有节点的集合
            // 使用'graph'列表本身，而不是变量Q，因'graph'已经被初始化。

            // 以dist值对节点链表进行排序
            Collections.sort(graph, new CellComparatorByDist());
            // 初始化closed节点链表
            closedSet.removeAll(closedSet);
        }

        /**
         * 画网格
         */
        @Override
        public void paintComponent(Graphics g) {

            super.paintComponent(g);  // 填充背景色

            g.setColor(Color.DARK_GRAY);
            g.fillRect(10, 10, columns * squareSize + 1, rows * squareSize + 1);

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < columns; c++) {
                    if (grid[r][c] == EMPTY) {
                        g.setColor(Color.WHITE);
                    } else if (grid[r][c] == ROBOT) {
                        g.setColor(Color.RED);
                    } else if (grid[r][c] == TARGET) {
                        g.setColor(Color.GREEN);
                    } else if (grid[r][c] == OBST) {
                        g.setColor(Color.BLACK);
                    } else if (grid[r][c] == FRONTIER) {
                        g.setColor(Color.BLUE);
                    } else if (grid[r][c] == CLOSED) {
                        g.setColor(Color.CYAN);
                    } else if (grid[r][c] == ROUTE) {
                        g.setColor(Color.YELLOW);
                    }
                    g.fillRect(11 + c * squareSize, 11 + r * squareSize, squareSize - 1, squareSize - 1);
                }
            }


            if (drawArrows.isSelected()) {
                // 为每一个open集或closed集节点画指向前驱的箭头
                for (int r = 0; r < rows; r++) {
                    for (int c = 0; c < columns; c++) {
                        // 如果该单元格是目标并且找到路径，
                        // 或属于到达目标的路径节点，
                        // 或是一个open节点，
                        // 或是一个closed节点但不是机器人的初始化位置
                        if ((grid[r][c] == TARGET && found) || grid[r][c] == ROUTE ||
                                grid[r][c] == FRONTIER || (grid[r][c] == CLOSED &&
                                !(r == robotStart.row && c == robotStart.col))) {
                            // 箭头的尾巴是该节点，同时箭头的头部是前驱节点
                            Cell head;
                            if (grid[r][c] == FRONTIER) {
                                if (dijkstra.isSelected()) {
                                    head = findPrev(graph, new Cell(r, c));
                                } else {
                                    head = findPrev(openSet, new Cell(r, c));
                                }
                            } else {
                                head = findPrev(closedSet, new Cell(r, c));
                            }
                            // 现在所处单元格的中心坐标
                            int tailX = 11 + c * squareSize + squareSize / 2;
                            int tailY = 11 + r * squareSize + squareSize / 2;
                            // 前驱单元格的中心坐标
                            int headX = 11 + head.col * squareSize + squareSize / 2;
                            int headY = 11 + head.row * squareSize + squareSize / 2;
                            // 如果该单元格是目标节点，或者属于到达目标的路径…
                            if (grid[r][c] == TARGET || grid[r][c] == ROUTE) {
                                // ... 画一个红色箭头指向目标。
                                g.setColor(Color.RED);
                                drawArrow(g, tailX, tailY, headX, headY);
                            } else {
                                // ... 向前驱单元格画一个黑箭头
                                g.setColor(Color.BLACK);
                                drawArrow(g, headX, headY, tailX, tailY);
                            }
                        }
                    }
                }
            }
        }

        /**
         * 从点（x2，y2）到点（x1，y1）画箭头
         */
        private void drawArrow(Graphics g1, int x1, int y1, int x2, int y2) {
            Graphics2D g = (Graphics2D) g1.create();

            double dx = x2 - x1, dy = y2 - y1;
            double angle = Math.atan2(dy, dx);
            int len = (int) Math.sqrt(dx * dx + dy * dy);
            AffineTransform at = AffineTransform.getTranslateInstance(x1, y1);
            at.concatenate(AffineTransform.getRotateInstance(angle));
            g.transform(at);

            // 设计一个水平方向长度为'len'的箭头，
            // 在尾部(0,0)处，有两个长度小巧的“箭头尺寸”与箭头的中轴形成20度角。
            g.drawLine(0, 0, len, 0);
            g.drawLine(0, 0, (int) (arrowSize * Math.sin(70 * Math.PI / 180)), (int) (arrowSize * Math.cos(70 * Math.PI / 180)));
            g.drawLine(0, 0, (int) (arrowSize * Math.sin(70 * Math.PI / 180)), -(int) (arrowSize * Math.cos(70 * Math.PI / 180)));
            // ... AffineTransform类处理其余
        }
    }
}