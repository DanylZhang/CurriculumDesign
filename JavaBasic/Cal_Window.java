package new_calculator;

import java.awt.Font;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.GridLayout;
import java.awt.Rectangle;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.UIManager;
import javax.swing.SwingConstants;
import javax.swing.border.LineBorder;

public class Cal_Window implements ActionListener {

	private JFrame Frame;
	private JPanel panel;
	private JLabel lbl_expression;
	private JLabel lbl_operand;
	private int barket_tag = 0;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					UIManager
							.setLookAndFeel("com.sun.java.swing.plaf.nimbus.NimbusLookAndFeel");
					Cal_Window window = new Cal_Window();
					window.Frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public Cal_Window() {
		Frame = new JFrame();
		Frame.setTitle("计算器-张丹玉");
		Frame.getContentPane().setBackground(Color.CYAN);
		Frame.setBounds(new Rectangle(100, 100, 386, 523));
		Frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Frame.getContentPane().setLayout(null);

		lbl_expression = new JLabel("");
		lbl_expression.setFont(new Font("楷体", Font.BOLD, 16));
		lbl_expression.setToolTipText("表达式");
		lbl_expression.setHorizontalAlignment(SwingConstants.RIGHT);
		lbl_expression.setBorder(new LineBorder(Color.BLUE, 1, true));
		lbl_expression.setBounds(10, 24, 349, 39);
		Frame.getContentPane().add(lbl_expression);

		lbl_operand = new JLabel("0");
		lbl_operand.setToolTipText("运算数或结果");
		lbl_operand.setFont(new Font("宋体", Font.PLAIN, 30));
		lbl_operand.setHorizontalAlignment(SwingConstants.RIGHT);
		lbl_operand.setBorder(new LineBorder(Color.BLUE, 1, true));
		lbl_operand.setBounds(10, 73, 349, 39);
		Frame.getContentPane().add(lbl_operand);

		panel = new JPanel();
		panel.setBackground(Color.CYAN);
		panel.setBounds(10, 122, 349, 357);
		Frame.getContentPane().add(panel);
		panel.setLayout(new GridLayout(6, 4, 2, 2));

		// ------------------------------------------------------------------清空
		JButton btnNewButton_clear = new JButton("清空");
		btnNewButton_clear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				lbl_expression.setText("");
				lbl_operand.setText("0");
				barket_tag = 0;
			}
		});
		btnNewButton_clear.setToolTipText("清空");
		btnNewButton_clear.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_clear);

		// ------------------------------------------------------------------左括号
		JButton btnNewButton_left_bracket = new JButton("(");
		btnNewButton_left_bracket.addActionListener(this);
		btnNewButton_left_bracket.setToolTipText("左括号");
		btnNewButton_left_bracket.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_left_bracket);

		// ------------------------------------------------------------------右括号
		JButton btnNewButton_right_bracket = new JButton(")");
		btnNewButton_right_bracket.addActionListener(this);
		btnNewButton_right_bracket.setToolTipText("右括号");
		btnNewButton_right_bracket.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_right_bracket);

		// ------------------------------------------------------------------退格
		JButton btnNewButton_backspace = new JButton("退格");
		btnNewButton_backspace.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				lbl_operand.setText(lbl_operand.getText().replaceAll(".$", ""));
				if (lbl_operand.getText().isEmpty())
					lbl_operand.setText("0");
			}
		});
		btnNewButton_backspace.setToolTipText("退格");
		btnNewButton_backspace.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_backspace);

		// ------------------------------------------------------------------幂
		JButton btnNewButton_pow = new JButton("^");
		btnNewButton_pow.addActionListener(this);
		btnNewButton_pow.setToolTipText("幂");
		btnNewButton_pow.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_pow);

		// ------------------------------------------------------------------开方
		JButton btnNewButton_sqrt = new JButton("√");
		btnNewButton_sqrt.addActionListener(this);
		btnNewButton_sqrt.setToolTipText("开方");
		btnNewButton_sqrt.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_sqrt);

		// ------------------------------------------------------------------模
		JButton btnNewButton_mod = new JButton("%");
		btnNewButton_mod.addActionListener(this);
		btnNewButton_mod.setToolTipText("模运算");
		btnNewButton_mod.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_mod);

		// ------------------------------------------------------------------除
		JButton btnNewButton_divide = new JButton("÷");
		btnNewButton_divide.addActionListener(this);
		btnNewButton_divide.setToolTipText("除");
		btnNewButton_divide.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_divide);

		// ------------------------------------------------------------------7
		JButton btnNewButton_7 = new JButton("7");
		btnNewButton_7.addActionListener(this);
		btnNewButton_7.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_7);

		// ------------------------------------------------------------------8
		JButton btnNewButton_8 = new JButton("8");
		btnNewButton_8.addActionListener(this);
		btnNewButton_8.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_8);

		// ------------------------------------------------------------------9
		JButton btnNewButton_9 = new JButton("9");
		btnNewButton_9.addActionListener(this);
		btnNewButton_9.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_9);

		// ------------------------------------------------------------------乘
		JButton btnNewButton_multiply = new JButton("×");
		btnNewButton_multiply.addActionListener(this);
		btnNewButton_multiply.setToolTipText("乘");
		btnNewButton_multiply.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_multiply);

		// ------------------------------------------------------------------4
		JButton btnNewButton_4 = new JButton("4");
		btnNewButton_4.addActionListener(this);
		btnNewButton_4.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_4);

		// ------------------------------------------------------------------5
		JButton btnNewButton_5 = new JButton("5");
		btnNewButton_5.addActionListener(this);
		btnNewButton_5.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_5);

		// ------------------------------------------------------------------6
		JButton btnNewButton_6 = new JButton("6");
		btnNewButton_6.addActionListener(this);
		btnNewButton_6.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_6);

		// ------------------------------------------------------------------减
		JButton btnNewButton_subtract = new JButton("－");
		btnNewButton_subtract.addActionListener(this);
		btnNewButton_subtract.setToolTipText("减");
		btnNewButton_subtract.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_subtract);

		// ------------------------------------------------------------------1
		JButton btnNewButton_1 = new JButton("1");
		btnNewButton_1.addActionListener(this);
		btnNewButton_1.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_1);

		// ------------------------------------------------------------------2
		JButton btnNewButton_2 = new JButton("2");
		btnNewButton_2.addActionListener(this);
		btnNewButton_2.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_2);

		// ------------------------------------------------------------------3
		JButton btnNewButton_3 = new JButton("3");
		btnNewButton_3.addActionListener(this);
		btnNewButton_3.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_3);

		// ------------------------------------------------------------------加
		JButton btnNewButton_add = new JButton("＋");
		btnNewButton_add.addActionListener(this);
		btnNewButton_add.setToolTipText("加");
		btnNewButton_add.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_add);

		// ------------------------------------------------------------------小数点
		JButton btnNewButton_dot = new JButton(".");
		btnNewButton_dot.addActionListener(this);
		btnNewButton_dot.setToolTipText("小数点");
		btnNewButton_dot.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_dot);

		// ------------------------------------------------------------------0
		JButton btnNewButton_0 = new JButton("0");
		btnNewButton_0.addActionListener(this);
		btnNewButton_0.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_0);

		// ------------------------------------------------------------------负号
		JButton btnNewButton_negative = new JButton("±");
		btnNewButton_negative.addActionListener(this);
		btnNewButton_negative.setToolTipText("正负号");
		btnNewButton_negative.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_negative);

		// ------------------------------------------------------------------计算
		JButton btnNewButton_calculate = new JButton("＝");
		btnNewButton_calculate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnNewButton_calculate.setToolTipText("计算");
		btnNewButton_calculate.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_calculate);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub

		System.out.println(e.getActionCommand());

		if (e.getActionCommand().matches("[0-9]")) {// 0-9
			if (lbl_operand.getText().matches("0"))// Java String 类的
													// matches方法参数为正则表达式字符串，这里的正则表达式要完全匹配String，即默认定位从头到尾。
				lbl_operand.setText(e.getActionCommand());
			else
				lbl_operand.setText(lbl_operand.getText()
						+ e.getActionCommand());
		} else if (e.getActionCommand().matches("\\.")) {// .
			if (!lbl_operand.getText().matches("\\d+\\.\\d*"))
				lbl_operand.setText(lbl_operand.getText()
						+ e.getActionCommand());
		} else if (e.getActionCommand().matches("±")
				&& !lbl_operand.getText().matches("0")) {// ±
			if (lbl_operand.getText().matches("-[0-9.]+"))// 如果已有负号则替换掉
				lbl_operand.setText(lbl_operand.getText().replaceAll("-", ""));
			else
				lbl_operand.setText("-" + lbl_operand.getText());
		} else if (e.getActionCommand().matches("[＋－×÷^%]")) {// ＋－×÷^%
			if (lbl_expression.getText().matches(".+?)"))
				lbl_expression.setText(lbl_expression.getText()
						+ e.getActionCommand());
			else {
				lbl_expression.setText(lbl_expression.getText()
						+ lbl_operand.getText() + e.getActionCommand());
				lbl_operand.setText("0");
			}
		} else if (e.getActionCommand().matches("√")) {// 开方
			if (!lbl_expression.getText().isEmpty()) {
				if (lbl_expression.getText().matches(".*?)")) {
				} else
					lbl_expression.setText(lbl_expression.getText()
							+ e.getActionCommand());
			} else if (e.getActionCommand().matches("(")) {// 左括号
				if (lbl_expression.getText().matches(".*?)")) {
				} else {
					lbl_expression.setText(lbl_expression.getText()
							+ e.getActionCommand());
					barket_tag++;
				}
			} else
				lbl_expression.setText(lbl_expression.getText()
						+ e.getActionCommand());
		} else if (e.getActionCommand().matches(")")) {// 右括号
			if (!lbl_expression.getText().isEmpty()) {
				if (lbl_expression.getText().matches(".*?)") && barket_tag > 0) {
					lbl_expression.setText(lbl_expression.getText()
							+ e.getActionCommand());
					barket_tag--;
				} else if (barket_tag > 0) {
					lbl_expression.setText(lbl_expression.getText()
							+ lbl_operand.getText() + e.getActionCommand());
					lbl_operand.setText("0");
					barket_tag--;
				}
			}
		} else if (e.getActionCommand().matches("＝")) {// 计算
		}
	}
}