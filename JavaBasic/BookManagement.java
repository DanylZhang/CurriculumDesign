package bookmanagement;

import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.border.TitledBorder;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.JButton;
import javax.swing.SwingConstants;
import javax.swing.UIManager;

import java.sql.DriverManager;
import java.sql.Connection;
import java.sql.Statement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class BookManagement extends JFrame {

	private JPanel contentPane;
	private JTextField textField_bookname;
	private JTextField textField_bookprice;
	private JTextField textField_bookpress;
	private JTextField textField_SearchName;
	private JLabel lblNewLabel_Result1;
	private JLabel lblNewLabel_Result2;
	private JLabel lblNewLabel_Result3;
	private ResultSet result = null;
	private Boolean flag = false;// 当查询的结果集有记录时为true

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					UIManager
							.setLookAndFeel("com.sun.java.swing.plaf.nimbus.NimbusLookAndFeel");
					BookManagement frame = new BookManagement();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public BookManagement() {
		setTitle("图书管理系统-张丹玉");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 725, 505);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);

		JPanel panel_insert = new JPanel();
		panel_insert.setForeground(Color.BLACK);
		panel_insert.setBorder(new TitledBorder(null, "添加图书",
				TitledBorder.LEADING, TitledBorder.TOP, null, null));
		panel_insert.setBounds(28, 30, 310, 411);
		contentPane.add(panel_insert);
		panel_insert.setLayout(null);

		JLabel label = new JLabel("书名：");
		label.setFont(new Font("宋体", Font.BOLD, 16));
		label.setHorizontalAlignment(SwingConstants.RIGHT);
		label.setBounds(10, 63, 87, 15);
		panel_insert.add(label);

		JLabel label_1 = new JLabel("定价：");
		label_1.setFont(new Font("宋体", Font.BOLD, 16));
		label_1.setHorizontalAlignment(SwingConstants.RIGHT);
		label_1.setBounds(10, 132, 87, 15);
		panel_insert.add(label_1);

		JLabel label_2 = new JLabel("出版社：");
		label_2.setFont(new Font("宋体", Font.BOLD, 16));
		label_2.setHorizontalAlignment(SwingConstants.RIGHT);
		label_2.setBounds(20, 200, 87, 15);
		panel_insert.add(label_2);

		textField_bookname = new JTextField();
		textField_bookname.setToolTipText("请输入书名");
		textField_bookname.setBounds(118, 56, 165, 25);
		panel_insert.add(textField_bookname);
		textField_bookname.setColumns(10);

		textField_bookprice = new JTextField();
		textField_bookprice.setToolTipText("请输入定价");
		textField_bookprice.setText("");
		textField_bookprice.setBounds(118, 125, 165, 25);
		panel_insert.add(textField_bookprice);
		textField_bookprice.setColumns(10);

		textField_bookpress = new JTextField();
		textField_bookpress.setToolTipText("请输入出版社");
		textField_bookpress.setText("");
		textField_bookpress.setBounds(118, 193, 165, 25);
		panel_insert.add(textField_bookpress);
		textField_bookpress.setColumns(10);

		// --------------------------------------------------------------添加按钮
		JButton btnNewButton_AddBook = new JButton("添  加");
		btnNewButton_AddBook.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				float price = 0;
				try {
					price = new Float(textField_bookprice.getText());
				} catch (Exception e1) {
					e1.getStackTrace();
				}
				if (textField_bookname.getText().isEmpty() || price == 0
						|| textField_bookpress.getText().isEmpty())
					JOptionPane.showMessageDialog(BookManagement.this,
							"请输入书名、合法的定价格式、出版社！", "提示",
							JOptionPane.INFORMATION_MESSAGE);
				else {
					if (addBook(textField_bookname.getText(), price,
							textField_bookpress.getText())) {
						JOptionPane.showMessageDialog(BookManagement.this,
								"添加成功！", "提示", JOptionPane.INFORMATION_MESSAGE);
						textField_bookname.setText("");
						textField_bookprice.setText("");
						textField_bookpress.setText("");
					}
				}
			}
		});
		btnNewButton_AddBook.setFont(new Font("宋体", Font.BOLD, 16));
		btnNewButton_AddBook.setBounds(100, 304, 112, 34);
		panel_insert.add(btnNewButton_AddBook);

		JPanel panel_select = new JPanel();
		panel_select.setBorder(new TitledBorder(null, "查询图书",
				TitledBorder.LEADING, TitledBorder.TOP, null, null));
		panel_select.setBounds(343, 30, 340, 411);
		contentPane.add(panel_select);
		panel_select.setLayout(null);

		textField_SearchName = new JTextField();
		textField_SearchName.setToolTipText("请输入要查询的书名");
		textField_SearchName.setText("请输入要查询的书名");
		textField_SearchName.setBounds(77, 56, 192, 25);
		panel_select.add(textField_SearchName);
		textField_SearchName.setColumns(10);

		// --------------------------------------------------------------查询按钮
		JButton btnNewButton_Search = new JButton("查  询");
		btnNewButton_Search.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (textField_SearchName.getText().isEmpty())
					JOptionPane
							.showMessageDialog(BookManagement.this,
									"请输入要查询的书名！", "提醒",
									JOptionPane.INFORMATION_MESSAGE);
				else {
					flag = false;// 标志复位为false
					try {
						result = searchBook(textField_SearchName.getText());
						if (!result.isLast() && result.next()) {// 判断结果集是否还有记录
							lblNewLabel_Result1.setText(result
									.getString("name")
									+ "    "
									+ result.getFloat("price")
									+ "元"
									+ "    "
									+ result.getString("press"));
							if (!result.isLast() && result.next()) {
								lblNewLabel_Result2.setText(result
										.getString("name")
										+ "    "
										+ result.getFloat("price")
										+ "元"
										+ "    " + result.getString("press"));
								if (!result.isLast() && result.next()) {
									lblNewLabel_Result3.setText(result
											.getString("name")
											+ "    "
											+ result.getFloat("price")
											+ "元"
											+ "    "
											+ result.getString("press"));
									flag = true;// 此时为true
								} else
									lblNewLabel_Result3.setText("已是最后一页！");
							} else {
								lblNewLabel_Result2.setText("");
								lblNewLabel_Result3.setText("已是最后一页！");
							}
						} else {
							lblNewLabel_Result1.setText("");
							lblNewLabel_Result2.setText("");
							lblNewLabel_Result3.setText("没有符合条件的书目！");
						}
					} catch (SQLException e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		btnNewButton_Search.setFont(new Font("宋体", Font.BOLD, 16));
		btnNewButton_Search.setBounds(115, 101, 109, 32);
		panel_select.add(btnNewButton_Search);

		// --------------------------------------------------------------显示查询结果
		lblNewLabel_Result1 = new JLabel();
		lblNewLabel_Result1.setBounds(30, 166, 300, 32);
		panel_select.add(lblNewLabel_Result1);

		lblNewLabel_Result2 = new JLabel();
		lblNewLabel_Result2.setBounds(30, 222, 300, 32);
		panel_select.add(lblNewLabel_Result2);

		lblNewLabel_Result3 = new JLabel();
		lblNewLabel_Result3.setBounds(30, 274, 300, 32);
		panel_select.add(lblNewLabel_Result3);

		// --------------------------------------------------------------上一页
		JButton btnNewButton_PrePage = new JButton("上一页");
		btnNewButton_PrePage.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (flag) {
					try {
						if (!result.isBeforeFirst()) {
							lblNewLabel_Result3.setText(result
									.getString("name")
									+ "    "
									+ result.getFloat("price")
									+ "元"
									+ "    "
									+ result.getString("press"));
							if (result.previous() && !result.isBeforeFirst()) {
								lblNewLabel_Result2.setText(result
										.getString("name")
										+ "    "
										+ result.getFloat("price")
										+ "元"
										+ "    " + result.getString("press"));
								if (result.previous()
										&& !result.isBeforeFirst())
									lblNewLabel_Result1.setText(result
											.getString("name")
											+ "    "
											+ result.getFloat("price")
											+ "元"
											+ "    "
											+ result.getString("press"));
								else
									lblNewLabel_Result1.setText("已是第一页！");
							} else {
								lblNewLabel_Result1.setText("已是第一页！");
								lblNewLabel_Result2.setText("");
							}
						} else
							lblNewLabel_Result1.setText("已是第一页！");
					} catch (SQLException e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		btnNewButton_PrePage.setBounds(77, 338, 93, 23);
		panel_select.add(btnNewButton_PrePage);

		// --------------------------------------------------------------下一页
		JButton btnNewButton_NextPage = new JButton("下一页");
		btnNewButton_NextPage.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (flag) {
					try {
						if (!result.isLast() && result.next()) {
							lblNewLabel_Result1.setText(result
									.getString("name")
									+ "    "
									+ result.getFloat("price")
									+ "元"
									+ "    "
									+ result.getString("press"));
							if (!result.isLast() && result.next()) {
								lblNewLabel_Result2.setText(result
										.getString("name")
										+ "    "
										+ result.getFloat("price")
										+ "元"
										+ "    " + result.getString("press"));
								if (!result.isLast() && result.next())
									lblNewLabel_Result3.setText(result
											.getString("name")
											+ "    "
											+ result.getFloat("price")
											+ "元"
											+ "    "
											+ result.getString("press"));
								else
									lblNewLabel_Result3.setText("已是最后一页！");
							} else {
								lblNewLabel_Result2.setText("");
								lblNewLabel_Result3.setText("已是最后一页！");
							}
						} else {
							lblNewLabel_Result1.setText("");
							lblNewLabel_Result2.setText("");
							lblNewLabel_Result3.setText("已是最后一页！");
						}
					} catch (SQLException e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		btnNewButton_NextPage.setBounds(176, 338, 93, 23);
		panel_select.add(btnNewButton_NextPage);
	}

	// --------------------------------------------------------------添加图书方法
	public boolean addBook(String name, float price, String press) {
		String driver = "com.mysql.jdbc.Driver";
		String url = "jdbc:mysql://localhost:3306/snnu";
		String user = "root";
		String password = "123";
		String sql_insert = "insert into book(name,price,press) values('"
				+ name + "'," + price + ",'" + press + "')";
		Connection con = null;
		Statement stmt = null;
		Boolean bool = false;
		try {
			Class.forName(driver);
			con = DriverManager.getConnection(url, user, password);
			stmt = con.createStatement();
			stmt.executeUpdate(sql_insert);
			bool = true;
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
			System.out.println(e.getMessage());
		} catch (SQLException e) {
			e.printStackTrace();
			System.out.println(e.getMessage());
		} finally {
			if (stmt != null) {
				try {
					stmt.close();
				} catch (SQLException sqlEx) {
				}
				stmt = null;
			}
			if (con != null) {
				try {
					con.close();
				} catch (SQLException sqlEx) {
				}
				con = null;
			}
		}
		return bool;
	}

	// --------------------------------------------------------------查询图书方法
	public ResultSet searchBook(String name) {
		String driver = "com.mysql.jdbc.Driver";
		String url = "jdbc:mysql://localhost:3306/snnu";
		String user = "root";
		String password = "123";
		String sql_query = "select * from book where name like '%" + name
				+ "%'";
		Connection con = null;
		Statement stmt = null;
		ResultSet result = null;
		try {
			Class.forName(driver);
			con = DriverManager.getConnection(url, user, password);
			stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE,
					ResultSet.CONCUR_READ_ONLY);
			result = stmt.executeQuery(sql_query);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
			System.out.println(e.getMessage());
		} catch (SQLException e) {
			e.printStackTrace();
			System.out.println(e.getMessage());
		} /*
		 * finally { if (stmt != null) { try { stmt.close(); } catch
		 * (SQLException sqlEx) { } stmt = null; } if (con != null) try {
		 * con.close(); } catch (SQLException sqlEx) { } con = null; }
		 */
		return result;
	}
}