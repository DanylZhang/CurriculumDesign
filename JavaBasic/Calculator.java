package calculator;

import java.awt.EventQueue;
import java.awt.GridLayout;
import java.awt.Font;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.border.LineBorder;
import javax.swing.border.EmptyBorder;
import javax.swing.JOptionPane;
import javax.swing.SwingConstants;
import javax.swing.UIManager;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.JButton;

public class Calculator extends JFrame {

	private JPanel contentPane;
	private JLabel lblNewLabel;
	private StringBuffer expression;
	private int bracket_tag;// 标记括号数量

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					UIManager
							.setLookAndFeel("com.sun.java.swing.plaf.nimbus.NimbusLookAndFeel");
					Calculator frame = new Calculator();
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
	public Calculator() {

		setTitle("计算器-张丹玉");
		setBackground(Color.WHITE);
		setBounds(100, 100, 379, 532);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		contentPane = new JPanel();
		contentPane.setBackground(Color.CYAN);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);

		lblNewLabel = new JLabel("0");
		lblNewLabel.setForeground(Color.BLACK);
		lblNewLabel.setBorder(new LineBorder(Color.BLUE, 1, true));
		lblNewLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		lblNewLabel.setFont(new Font("宋体", Font.BOLD, 18));
		lblNewLabel.setBounds(10, 35, 343, 39);
		contentPane.add(lblNewLabel);

		JPanel panel = new JPanel();
		panel.setForeground(Color.BLACK);
		panel.setBackground(Color.CYAN);
		panel.setBounds(10, 108, 343, 378);
		panel.setLayout(new GridLayout(6, 4, 2, 2));
		contentPane.add(panel);

		expression = new StringBuffer();
		bracket_tag = 0;

		// ------------------------------------------------------------------------清空
		JButton btnNewButton_clear = new JButton("清空");
		btnNewButton_clear.setToolTipText("清空");
		btnNewButton_clear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				bracket_tag = 0;
				expression.setLength(0);
				lblNewLabel.setText("0");
			}
		});
		btnNewButton_clear.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_clear);

		// ------------------------------------------------------------------------左括号
		JButton btnNewButton_left_bracket = new JButton("(");
		btnNewButton_left_bracket.setToolTipText("左括号");
		btnNewButton_left_bracket.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && (expression
								.charAt(expression.length() - 1) == '('
								|| expression.charAt(expression.length() - 1) == '+'
								|| expression.charAt(expression.length() - 1) == '-'
								|| expression.charAt(expression.length() - 1) == '*'
								|| expression.charAt(expression.length() - 1) == '÷'
								|| expression.charAt(expression.length() - 1) == '^' || expression
								.charAt(expression.length() - 1) == '√'))) {
					bracket_tag++;
					expression.append('(');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_left_bracket.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_left_bracket);

		// ------------------------------------------------------------------------右括号
		JButton btnNewButton_right_bracket = new JButton(")");
		btnNewButton_right_bracket.setToolTipText("右括号");
		btnNewButton_right_bracket.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')
						&& bracket_tag > 0) {
					bracket_tag--;
					expression.append(')');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_right_bracket.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_right_bracket);

		// ------------------------------------------------------------------------退格
		JButton btnNewButton_backspace = new JButton("退格");
		btnNewButton_backspace.setToolTipText("退格");
		btnNewButton_backspace.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() > 0
						&& expression.charAt(expression.length() - 1) == '(')
					bracket_tag--;
				else if (expression.length() > 0
						&& expression.charAt(expression.length() - 1) == ')')
					bracket_tag++;
				expression.setLength(expression.length() > 0 ? expression
						.length() - 1 : 0);
				if (expression.length() == 0)
					lblNewLabel.setText("0");
				else
					lblNewLabel.setText(expression.toString());
			}
		});
		btnNewButton_backspace.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_backspace);

		// ------------------------------------------------------------------------负号
		JButton btnNewButton_negative = new JButton("﹣");
		btnNewButton_negative.setToolTipText("负号");
		btnNewButton_negative.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0
								&& expression.charAt(expression.length() - 1) != '√' && (expression
								.charAt(expression.length() - 1) == '('
								|| expression.charAt(expression.length() - 1) == '+'
								|| expression.charAt(expression.length() - 1) == '-'
								|| expression.charAt(expression.length() - 1) == '*'
								|| expression.charAt(expression.length() - 1) == '÷' || expression
								.charAt(expression.length() - 1) == '√'))) {
					expression.append('﹣');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_negative.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_negative);

		// ------------------------------------------------------------------------开方
		JButton btnNewButton_sqrt = new JButton("√");
		btnNewButton_sqrt.setToolTipText("开方");
		btnNewButton_sqrt.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && (expression
								.charAt(expression.length() - 1) == '('
								|| expression.charAt(expression.length() - 1) == '+'
								|| expression.charAt(expression.length() - 1) == '-'
								|| expression.charAt(expression.length() - 1) == '*'
								|| expression.charAt(expression.length() - 1) == '÷' || expression
								.charAt(expression.length() - 1) == '^'))) {
					expression.append('√');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_sqrt.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_sqrt);

		// ------------------------------------------------------------------------幂
		JButton btnNewButton_pow = new JButton("^");
		btnNewButton_pow.setToolTipText("幂");
		btnNewButton_pow.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')) {
					expression.append('^');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		panel.add(btnNewButton_pow);

		// ------------------------------------------------------------------------模运算
		JButton btnNewButton_mod = new JButton("%");
		btnNewButton_mod.setToolTipText("模运算求余");
		btnNewButton_mod.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')) {
					expression.append('%');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		panel.add(btnNewButton_mod);

		// ------------------------------------------------------------------------7
		JButton btnNewButton_7 = new JButton("7");
		btnNewButton_7.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('7');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_7.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_7);

		// ------------------------------------------------------------------------8
		JButton btnNewButton_8 = new JButton("8");
		btnNewButton_8.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('8');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_8.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_8);

		// ------------------------------------------------------------------------9
		JButton btnNewButton_9 = new JButton("9");
		btnNewButton_9.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('9');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_9.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_9);

		// ------------------------------------------------------------------------除
		JButton btnNewButton_divide = new JButton("÷");
		btnNewButton_divide.setToolTipText("除");
		btnNewButton_divide.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')) {
					expression.append('÷');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_divide.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_divide);

		// ------------------------------------------------------------------------4
		JButton btnNewButton_4 = new JButton("4");
		btnNewButton_4.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('4');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_4.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_4);

		// ------------------------------------------------------------------------5
		JButton btnNewButton_5 = new JButton("5");
		btnNewButton_5.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('5');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_5.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_5);

		// ------------------------------------------------------------------------6
		JButton btnNewButton_6 = new JButton("6");
		btnNewButton_6.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('6');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_6.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_6);

		// ------------------------------------------------------------------------乘
		JButton btnNewButton_multiply = new JButton("×");
		btnNewButton_multiply.setToolTipText("乘");
		btnNewButton_multiply.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')) {
					expression.append('*');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_multiply.setFont(new Font("Arial", Font.BOLD, 18));
		panel.add(btnNewButton_multiply);

		// ------------------------------------------------------------------------1
		JButton btnNewButton_1 = new JButton("1");
		btnNewButton_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('1');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_1.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_1);

		// ------------------------------------------------------------------------2
		JButton btnNewButton_2 = new JButton("2");
		btnNewButton_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('2');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_2.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_2);

		// ------------------------------------------------------------------------3
		JButton btnNewButton_3 = new JButton("3");
		btnNewButton_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('3');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_3.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_3);

		// ------------------------------------------------------------------------减
		JButton btnNewButton_subtract = new JButton("－");
		btnNewButton_subtract.setToolTipText("减");
		btnNewButton_subtract.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')) {
					expression.append('-');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_subtract.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_subtract);

		// ------------------------------------------------------------------------小数点
		JButton btnNewButton_dot = new JButton(".");
		btnNewButton_dot.setToolTipText("小数点");
		btnNewButton_dot.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9'))) {
					expression.append('.');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_dot.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_dot);

		// ------------------------------------------------------------------------0
		JButton btnNewButton_0 = new JButton("0");
		btnNewButton_0.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() == 0
						|| (expression.length() != 0 && expression
								.charAt(expression.length() - 1) != ')')) {
					expression.append('0');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_0.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_0);

		// ------------------------------------------------------------------------计算
		JButton btnNewButton_calculate = new JButton("＝");
		btnNewButton_calculate.setToolTipText("计算");
		btnNewButton_calculate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')
						&& bracket_tag == 0) {
					expression.append('=');
					try {
						String temp;
						lblNewLabel.setText(expression.append(
								temp = (Calculate.Main(expression.toString()))
										.toString()).toString());
						expression.setLength(0);
						if (temp.charAt(0) == '-') {
							temp = temp.substring(1);
							expression.append('﹣');
						}
						expression.append(temp);
					} catch (Exception e1) {
						e1.printStackTrace();
						JOptionPane.showMessageDialog(Calculator.this,
								e1.getMessage(), "错误提示",
								JOptionPane.ERROR_MESSAGE);
					}
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的运算！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_calculate.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_calculate);

		// ------------------------------------------------------------------------加
		JButton btnNewButton_add = new JButton("＋");
		btnNewButton_add.setToolTipText("加");
		btnNewButton_add.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (expression.length() != 0
						&& (('0' <= expression.charAt(expression.length() - 1) && expression
								.charAt(expression.length() - 1) <= '9') || expression
								.charAt(expression.length() - 1) == ')')) {
					expression.append('+');
					lblNewLabel.setText(expression.toString());
				} else
					JOptionPane.showMessageDialog(Calculator.this, "不合法的输入！",
							"错误提示", JOptionPane.ERROR_MESSAGE);
			}
		});
		btnNewButton_add.setFont(new Font("宋体", Font.BOLD, 18));
		panel.add(btnNewButton_add);
	}
}