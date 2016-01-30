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
	private Boolean flag = false;// ����ѯ�Ľ�����м�¼ʱΪtrue

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
		setTitle("ͼ�����ϵͳ-�ŵ���");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 725, 505);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);

		JPanel panel_insert = new JPanel();
		panel_insert.setForeground(Color.BLACK);
		panel_insert.setBorder(new TitledBorder(null, "���ͼ��",
				TitledBorder.LEADING, TitledBorder.TOP, null, null));
		panel_insert.setBounds(28, 30, 310, 411);
		contentPane.add(panel_insert);
		panel_insert.setLayout(null);

		JLabel label = new JLabel("������");
		label.setFont(new Font("����", Font.BOLD, 16));
		label.setHorizontalAlignment(SwingConstants.RIGHT);
		label.setBounds(10, 63, 87, 15);
		panel_insert.add(label);

		JLabel label_1 = new JLabel("���ۣ�");
		label_1.setFont(new Font("����", Font.BOLD, 16));
		label_1.setHorizontalAlignment(SwingConstants.RIGHT);
		label_1.setBounds(10, 132, 87, 15);
		panel_insert.add(label_1);

		JLabel label_2 = new JLabel("�����磺");
		label_2.setFont(new Font("����", Font.BOLD, 16));
		label_2.setHorizontalAlignment(SwingConstants.RIGHT);
		label_2.setBounds(20, 200, 87, 15);
		panel_insert.add(label_2);

		textField_bookname = new JTextField();
		textField_bookname.setToolTipText("����������");
		textField_bookname.setBounds(118, 56, 165, 25);
		panel_insert.add(textField_bookname);
		textField_bookname.setColumns(10);

		textField_bookprice = new JTextField();
		textField_bookprice.setToolTipText("�����붨��");
		textField_bookprice.setText("");
		textField_bookprice.setBounds(118, 125, 165, 25);
		panel_insert.add(textField_bookprice);
		textField_bookprice.setColumns(10);

		textField_bookpress = new JTextField();
		textField_bookpress.setToolTipText("�����������");
		textField_bookpress.setText("");
		textField_bookpress.setBounds(118, 193, 165, 25);
		panel_insert.add(textField_bookpress);
		textField_bookpress.setColumns(10);

		// --------------------------------------------------------------��Ӱ�ť
		JButton btnNewButton_AddBook = new JButton("��  ��");
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
							"�������������Ϸ��Ķ��۸�ʽ�������磡", "��ʾ",
							JOptionPane.INFORMATION_MESSAGE);
				else {
					if (addBook(textField_bookname.getText(), price,
							textField_bookpress.getText())) {
						JOptionPane.showMessageDialog(BookManagement.this,
								"��ӳɹ���", "��ʾ", JOptionPane.INFORMATION_MESSAGE);
						textField_bookname.setText("");
						textField_bookprice.setText("");
						textField_bookpress.setText("");
					}
				}
			}
		});
		btnNewButton_AddBook.setFont(new Font("����", Font.BOLD, 16));
		btnNewButton_AddBook.setBounds(100, 304, 112, 34);
		panel_insert.add(btnNewButton_AddBook);

		JPanel panel_select = new JPanel();
		panel_select.setBorder(new TitledBorder(null, "��ѯͼ��",
				TitledBorder.LEADING, TitledBorder.TOP, null, null));
		panel_select.setBounds(343, 30, 340, 411);
		contentPane.add(panel_select);
		panel_select.setLayout(null);

		textField_SearchName = new JTextField();
		textField_SearchName.setToolTipText("������Ҫ��ѯ������");
		textField_SearchName.setText("������Ҫ��ѯ������");
		textField_SearchName.setBounds(77, 56, 192, 25);
		panel_select.add(textField_SearchName);
		textField_SearchName.setColumns(10);

		// --------------------------------------------------------------��ѯ��ť
		JButton btnNewButton_Search = new JButton("��  ѯ");
		btnNewButton_Search.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (textField_SearchName.getText().isEmpty())
					JOptionPane
							.showMessageDialog(BookManagement.this,
									"������Ҫ��ѯ��������", "����",
									JOptionPane.INFORMATION_MESSAGE);
				else {
					flag = false;// ��־��λΪfalse
					try {
						result = searchBook(textField_SearchName.getText());
						if (!result.isLast() && result.next()) {// �жϽ�����Ƿ��м�¼
							lblNewLabel_Result1.setText(result
									.getString("name")
									+ "    "
									+ result.getFloat("price")
									+ "Ԫ"
									+ "    "
									+ result.getString("press"));
							if (!result.isLast() && result.next()) {
								lblNewLabel_Result2.setText(result
										.getString("name")
										+ "    "
										+ result.getFloat("price")
										+ "Ԫ"
										+ "    " + result.getString("press"));
								if (!result.isLast() && result.next()) {
									lblNewLabel_Result3.setText(result
											.getString("name")
											+ "    "
											+ result.getFloat("price")
											+ "Ԫ"
											+ "    "
											+ result.getString("press"));
									flag = true;// ��ʱΪtrue
								} else
									lblNewLabel_Result3.setText("�������һҳ��");
							} else {
								lblNewLabel_Result2.setText("");
								lblNewLabel_Result3.setText("�������һҳ��");
							}
						} else {
							lblNewLabel_Result1.setText("");
							lblNewLabel_Result2.setText("");
							lblNewLabel_Result3.setText("û�з�����������Ŀ��");
						}
					} catch (SQLException e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		btnNewButton_Search.setFont(new Font("����", Font.BOLD, 16));
		btnNewButton_Search.setBounds(115, 101, 109, 32);
		panel_select.add(btnNewButton_Search);

		// --------------------------------------------------------------��ʾ��ѯ���
		lblNewLabel_Result1 = new JLabel();
		lblNewLabel_Result1.setBounds(30, 166, 300, 32);
		panel_select.add(lblNewLabel_Result1);

		lblNewLabel_Result2 = new JLabel();
		lblNewLabel_Result2.setBounds(30, 222, 300, 32);
		panel_select.add(lblNewLabel_Result2);

		lblNewLabel_Result3 = new JLabel();
		lblNewLabel_Result3.setBounds(30, 274, 300, 32);
		panel_select.add(lblNewLabel_Result3);

		// --------------------------------------------------------------��һҳ
		JButton btnNewButton_PrePage = new JButton("��һҳ");
		btnNewButton_PrePage.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (flag) {
					try {
						if (!result.isBeforeFirst()) {
							lblNewLabel_Result3.setText(result
									.getString("name")
									+ "    "
									+ result.getFloat("price")
									+ "Ԫ"
									+ "    "
									+ result.getString("press"));
							if (result.previous() && !result.isBeforeFirst()) {
								lblNewLabel_Result2.setText(result
										.getString("name")
										+ "    "
										+ result.getFloat("price")
										+ "Ԫ"
										+ "    " + result.getString("press"));
								if (result.previous()
										&& !result.isBeforeFirst())
									lblNewLabel_Result1.setText(result
											.getString("name")
											+ "    "
											+ result.getFloat("price")
											+ "Ԫ"
											+ "    "
											+ result.getString("press"));
								else
									lblNewLabel_Result1.setText("���ǵ�һҳ��");
							} else {
								lblNewLabel_Result1.setText("���ǵ�һҳ��");
								lblNewLabel_Result2.setText("");
							}
						} else
							lblNewLabel_Result1.setText("���ǵ�һҳ��");
					} catch (SQLException e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		btnNewButton_PrePage.setBounds(77, 338, 93, 23);
		panel_select.add(btnNewButton_PrePage);

		// --------------------------------------------------------------��һҳ
		JButton btnNewButton_NextPage = new JButton("��һҳ");
		btnNewButton_NextPage.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (flag) {
					try {
						if (!result.isLast() && result.next()) {
							lblNewLabel_Result1.setText(result
									.getString("name")
									+ "    "
									+ result.getFloat("price")
									+ "Ԫ"
									+ "    "
									+ result.getString("press"));
							if (!result.isLast() && result.next()) {
								lblNewLabel_Result2.setText(result
										.getString("name")
										+ "    "
										+ result.getFloat("price")
										+ "Ԫ"
										+ "    " + result.getString("press"));
								if (!result.isLast() && result.next())
									lblNewLabel_Result3.setText(result
											.getString("name")
											+ "    "
											+ result.getFloat("price")
											+ "Ԫ"
											+ "    "
											+ result.getString("press"));
								else
									lblNewLabel_Result3.setText("�������һҳ��");
							} else {
								lblNewLabel_Result2.setText("");
								lblNewLabel_Result3.setText("�������һҳ��");
							}
						} else {
							lblNewLabel_Result1.setText("");
							lblNewLabel_Result2.setText("");
							lblNewLabel_Result3.setText("�������һҳ��");
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

	// --------------------------------------------------------------���ͼ�鷽��
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

	// --------------------------------------------------------------��ѯͼ�鷽��
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