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
		Frame.setTitle("������-�ŵ���");
		Frame.getContentPane().setBackground(Color.CYAN);
		Frame.setBounds(new Rectangle(100, 100, 386, 523));
		Frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Frame.getContentPane().setLayout(null);

		lbl_expression = new JLabel("");
		lbl_expression.setFont(new Font("����", Font.BOLD, 16));
		lbl_expression.setToolTipText("���ʽ");
		lbl_expression.setHorizontalAlignment(SwingConstants.RIGHT);
		lbl_expression.setBorder(new LineBorder(Color.BLUE, 1, true));
		lbl_expression.setBounds(10, 24, 349, 39);
		Frame.getContentPane().add(lbl_expression);

		lbl_operand = new JLabel("0");
		lbl_operand.setToolTipText("����������");
		lbl_operand.setFont(new Font("����", Font.PLAIN, 30));
		lbl_operand.setHorizontalAlignment(SwingConstants.RIGHT);
		lbl_operand.setBorder(new LineBorder(Color.BLUE, 1, true));
		lbl_operand.setBounds(10, 73, 349, 39);
		Frame.getContentPane().add(lbl_operand);

		panel = new JPanel();
		panel.setBackground(Color.CYAN);
		panel.setBounds(10, 122, 349, 357);
		Frame.getContentPane().add(panel);
		panel.setLayout(new GridLayout(6, 4, 2, 2));

		// ------------------------------------------------------------------���
		JButton btnNewButton_clear = new JButton("���");
		btnNewButton_clear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				lbl_expression.setText("");
				lbl_operand.setText("0");
				barket_tag = 0;
			}
		});
		btnNewButton_clear.setToolTipText("���");
		btnNewButton_clear.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_clear);

		// ------------------------------------------------------------------������
		JButton btnNewButton_left_bracket = new JButton("(");
		btnNewButton_left_bracket.addActionListener(this);
		btnNewButton_left_bracket.setToolTipText("������");
		btnNewButton_left_bracket.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_left_bracket);

		// ------------------------------------------------------------------������
		JButton btnNewButton_right_bracket = new JButton(")");
		btnNewButton_right_bracket.addActionListener(this);
		btnNewButton_right_bracket.setToolTipText("������");
		btnNewButton_right_bracket.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_right_bracket);

		// ------------------------------------------------------------------�˸�
		JButton btnNewButton_backspace = new JButton("�˸�");
		btnNewButton_backspace.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				lbl_operand.setText(lbl_operand.getText().replaceAll(".$", ""));
				if (lbl_operand.getText().isEmpty())
					lbl_operand.setText("0");
			}
		});
		btnNewButton_backspace.setToolTipText("�˸�");
		btnNewButton_backspace.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_backspace);

		// ------------------------------------------------------------------��
		JButton btnNewButton_pow = new JButton("^");
		btnNewButton_pow.addActionListener(this);
		btnNewButton_pow.setToolTipText("��");
		btnNewButton_pow.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_pow);

		// ------------------------------------------------------------------����
		JButton btnNewButton_sqrt = new JButton("��");
		btnNewButton_sqrt.addActionListener(this);
		btnNewButton_sqrt.setToolTipText("����");
		btnNewButton_sqrt.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_sqrt);

		// ------------------------------------------------------------------ģ
		JButton btnNewButton_mod = new JButton("%");
		btnNewButton_mod.addActionListener(this);
		btnNewButton_mod.setToolTipText("ģ����");
		btnNewButton_mod.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_mod);

		// ------------------------------------------------------------------��
		JButton btnNewButton_divide = new JButton("��");
		btnNewButton_divide.addActionListener(this);
		btnNewButton_divide.setToolTipText("��");
		btnNewButton_divide.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_divide);

		// ------------------------------------------------------------------7
		JButton btnNewButton_7 = new JButton("7");
		btnNewButton_7.addActionListener(this);
		btnNewButton_7.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_7);

		// ------------------------------------------------------------------8
		JButton btnNewButton_8 = new JButton("8");
		btnNewButton_8.addActionListener(this);
		btnNewButton_8.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_8);

		// ------------------------------------------------------------------9
		JButton btnNewButton_9 = new JButton("9");
		btnNewButton_9.addActionListener(this);
		btnNewButton_9.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_9);

		// ------------------------------------------------------------------��
		JButton btnNewButton_multiply = new JButton("��");
		btnNewButton_multiply.addActionListener(this);
		btnNewButton_multiply.setToolTipText("��");
		btnNewButton_multiply.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_multiply);

		// ------------------------------------------------------------------4
		JButton btnNewButton_4 = new JButton("4");
		btnNewButton_4.addActionListener(this);
		btnNewButton_4.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_4);

		// ------------------------------------------------------------------5
		JButton btnNewButton_5 = new JButton("5");
		btnNewButton_5.addActionListener(this);
		btnNewButton_5.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_5);

		// ------------------------------------------------------------------6
		JButton btnNewButton_6 = new JButton("6");
		btnNewButton_6.addActionListener(this);
		btnNewButton_6.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_6);

		// ------------------------------------------------------------------��
		JButton btnNewButton_subtract = new JButton("��");
		btnNewButton_subtract.addActionListener(this);
		btnNewButton_subtract.setToolTipText("��");
		btnNewButton_subtract.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_subtract);

		// ------------------------------------------------------------------1
		JButton btnNewButton_1 = new JButton("1");
		btnNewButton_1.addActionListener(this);
		btnNewButton_1.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_1);

		// ------------------------------------------------------------------2
		JButton btnNewButton_2 = new JButton("2");
		btnNewButton_2.addActionListener(this);
		btnNewButton_2.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_2);

		// ------------------------------------------------------------------3
		JButton btnNewButton_3 = new JButton("3");
		btnNewButton_3.addActionListener(this);
		btnNewButton_3.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_3);

		// ------------------------------------------------------------------��
		JButton btnNewButton_add = new JButton("��");
		btnNewButton_add.addActionListener(this);
		btnNewButton_add.setToolTipText("��");
		btnNewButton_add.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_add);

		// ------------------------------------------------------------------С����
		JButton btnNewButton_dot = new JButton(".");
		btnNewButton_dot.addActionListener(this);
		btnNewButton_dot.setToolTipText("С����");
		btnNewButton_dot.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_dot);

		// ------------------------------------------------------------------0
		JButton btnNewButton_0 = new JButton("0");
		btnNewButton_0.addActionListener(this);
		btnNewButton_0.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_0);

		// ------------------------------------------------------------------����
		JButton btnNewButton_negative = new JButton("��");
		btnNewButton_negative.addActionListener(this);
		btnNewButton_negative.setToolTipText("������");
		btnNewButton_negative.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_negative);

		// ------------------------------------------------------------------����
		JButton btnNewButton_calculate = new JButton("��");
		btnNewButton_calculate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnNewButton_calculate.setToolTipText("����");
		btnNewButton_calculate.setFont(new Font("����", Font.BOLD, 18));
		panel.add(btnNewButton_calculate);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub

		System.out.println(e.getActionCommand());

		if (e.getActionCommand().matches("[0-9]")) {// 0-9
			if (lbl_operand.getText().matches("0"))// Java String ���
													// matches��������Ϊ������ʽ�ַ����������������ʽҪ��ȫƥ��String����Ĭ�϶�λ��ͷ��β��
				lbl_operand.setText(e.getActionCommand());
			else
				lbl_operand.setText(lbl_operand.getText()
						+ e.getActionCommand());
		} else if (e.getActionCommand().matches("\\.")) {// .
			if (!lbl_operand.getText().matches("\\d+\\.\\d*"))
				lbl_operand.setText(lbl_operand.getText()
						+ e.getActionCommand());
		} else if (e.getActionCommand().matches("��")
				&& !lbl_operand.getText().matches("0")) {// ��
			if (lbl_operand.getText().matches("-[0-9.]+"))// ������и������滻��
				lbl_operand.setText(lbl_operand.getText().replaceAll("-", ""));
			else
				lbl_operand.setText("-" + lbl_operand.getText());
		} else if (e.getActionCommand().matches("[��������^%]")) {// ��������^%
			if (lbl_expression.getText().matches(".+?)"))
				lbl_expression.setText(lbl_expression.getText()
						+ e.getActionCommand());
			else {
				lbl_expression.setText(lbl_expression.getText()
						+ lbl_operand.getText() + e.getActionCommand());
				lbl_operand.setText("0");
			}
		} else if (e.getActionCommand().matches("��")) {// ����
			if (!lbl_expression.getText().isEmpty()) {
				if (lbl_expression.getText().matches(".*?)")) {
				} else
					lbl_expression.setText(lbl_expression.getText()
							+ e.getActionCommand());
			} else if (e.getActionCommand().matches("(")) {// ������
				if (lbl_expression.getText().matches(".*?)")) {
				} else {
					lbl_expression.setText(lbl_expression.getText()
							+ e.getActionCommand());
					barket_tag++;
				}
			} else
				lbl_expression.setText(lbl_expression.getText()
						+ e.getActionCommand());
		} else if (e.getActionCommand().matches(")")) {// ������
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
		} else if (e.getActionCommand().matches("��")) {// ����
		}
	}
}