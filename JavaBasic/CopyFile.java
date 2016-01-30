package copyFile;

import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.UIManager;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.SwingConstants;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class CopyFile {

	private JFrame Frame;
	private JTextField textField_source;
	private JTextField textField_destination;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					UIManager
							.setLookAndFeel("com.sun.java.swing.plaf.nimbus.NimbusLookAndFeel");
					CopyFile window = new CopyFile();
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
	public CopyFile() {
		Frame = new JFrame();
		Frame.setTitle("�ļ�����-�ŵ���");
		Frame.setBounds(100, 100, 628, 366);
		Frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Frame.getContentPane().setLayout(null);

		JLabel lbl_source = new JLabel("Դ�ļ���");
		lbl_source.setHorizontalAlignment(SwingConstants.LEFT);
		lbl_source.setFont(new Font("����", Font.BOLD, 14));
		lbl_source.setBounds(21, 50, 68, 25);
		Frame.getContentPane().add(lbl_source);

		JLabel lbl_destination = new JLabel("���Ƶ���");
		lbl_destination.setHorizontalAlignment(SwingConstants.LEFT);
		lbl_destination.setFont(new Font("����", Font.BOLD, 14));
		lbl_destination.setBounds(21, 110, 68, 25);
		Frame.getContentPane().add(lbl_destination);

		textField_source = new JTextField();
		textField_source.setBounds(78, 48, 425, 30);
		Frame.getContentPane().add(textField_source);
		textField_source.setColumns(10);

		textField_destination = new JTextField();
		textField_destination.setColumns(10);
		textField_destination.setBounds(78, 108, 425, 30);
		Frame.getContentPane().add(textField_destination);

		// -------------------------------------------------------------ѡ��Դ�ļ���Դ�ļ���
		JButton button_source = new JButton("ѡ ��");
		button_source.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				// �ļ�ѡ����
				JFileChooser chooser = new JFileChooser();
				chooser.setFileSelectionMode(JFileChooser.FILES_AND_DIRECTORIES);
				chooser.showOpenDialog(null);
				try {
					textField_source.setText(chooser.getSelectedFile()
							.getAbsolutePath());
				} catch (Exception e1) {
					e1.getStackTrace();
				}

				try {
					File file = chooser.getSelectedFile();
					System.out.println(file.getAbsolutePath());
					System.out.println(file.getParent());
					System.out.println(file.getName());
					textField_source.setText(file.getAbsolutePath());
				} catch (Exception e1) {
					JOptionPane.showMessageDialog(null, "Դ�ļ�·����ȡʧ�ܣ�", "������ʾ",
							JOptionPane.ERROR_MESSAGE);
				}
			}
		});
		button_source.setFont(new Font("����", Font.BOLD, 16));
		button_source.setToolTipText("ѡ��Դ�ļ���Դ�ļ���");
		button_source.setBounds(509, 50, 93, 25);
		Frame.getContentPane().add(button_source);

		// -------------------------------------------------------------���Ƶ�...
		JButton button_destination = new JButton("ѡ ��");
		button_destination.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				// �ļ�ѡ����
				JFileChooser chooser = new JFileChooser();
				chooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
				chooser.showOpenDialog(null);
				try {
					textField_destination.setText(chooser.getSelectedFile()
							.getAbsolutePath());
				} catch (Exception e1) {
					e1.getStackTrace();
				}
			}
		});
		button_destination.setFont(new Font("����", Font.BOLD, 16));
		button_destination.setToolTipText("���Ƶ�...");
		button_destination.setBounds(509, 109, 93, 25);
		Frame.getContentPane().add(button_destination);

		// -------------------------------------------------------------��ʼ����
		JButton button_copy = new JButton("��ʼ����");
		button_copy.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				File file_in = new File(textField_source.getText());
				File file_out = new File(textField_destination.getText());
				if (!file_in.exists()) {
					JOptionPane.showMessageDialog(null, "Դ�ļ������ڣ�", "����",
							JOptionPane.INFORMATION_MESSAGE);
				} else if (file_out.list() != null) {
					JOptionPane.showMessageDialog(null, "Ŀ���ļ��Ѵ��ڣ�", "����",
							JOptionPane.INFORMATION_MESSAGE);
				} else if (file_in.exists() && !file_out.exists()) {
					try {
						new FileCopy(file_in, file_out);
					} catch (IOException e1) {
						JOptionPane.showMessageDialog(null, e1.getMessage(),
								"����", JOptionPane.INFORMATION_MESSAGE);
					}
				}
			}
		});
		button_copy.setFont(new Font("����", Font.BOLD, 22));
		button_copy.setBounds(223, 200, 172, 60);
		Frame.getContentPane().add(button_copy);
	}
}

class FileCopy {

	public FileCopy(File file_in, File file_out) throws IOException {
		// ����������䲻���ص�,�ɲ�д

		// ���Ҫ���Ƶ�Ŀ¼������,�ȴ���Ŀ¼
		if (!file_in.exists()) {
			if (file_in.isDirectory()) {
				file_in.mkdir();
			}
		}

		// ���Ҫ���Ƶ�Ŀ�ĵص�Ŀ¼������,�ȴ���Ŀ¼
		if (!file_out.exists()) {
			if (file_out.isDirectory()) {
				file_out.mkdir();
			}
		}
		copy(file_in, file_out);
	}

	// �ݹ�
	public void copy(File file_in, File file_out) throws IOException {

		// �ж�File��Ŀ¼�����ļ�,��Ŀ¼�ʹ���Ŀ¼,���ļ��ʹ����ļ�.�����ļ��Ļ�,ֱ�ӷ��صݹ����һ��
		if (file_in.isDirectory()) {
			file_out.mkdir();
		} else if (file_in.isFile()) {
			FileInputStream file_read = new FileInputStream(file_in);
			FileOutputStream file_write = new FileOutputStream(file_out);
			copyFile(file_read, file_write);
			return;
		}

		// �����Ŀ¼�µ��ļ�������Ϊ0,�����Ǹ��յ�Ŀ¼,Ҳֱ�ӷ��ص��ݹ���һ��.
		if (file_in.list().length == 0) {
			return;
		}

		// ����filesΪ��Ŀ¼�������ļ���������
		String[] files = file_in.list();

		// pathsΪԴ�ļ�·��,pathtΪĿ��·��
		String paths = "", patht = "";

		// ��Դ�ļ�·����Ŀ��·����ֵ.
		paths = file_in.getPath() + File.separator;
		patht = file_out.getPath() + File.separator;

		// ����������,�����ļ��ݹ�
		for (int i = 0; i < files.length; i++) {
			File souf = new File(paths + files[i] + File.separator);
			File tof = new File(patht + files[i] + File.separator);
			copy(souf, tof);
		}
	}

	private void copyFile(FileInputStream file_read, FileOutputStream file_write)
			throws IOException {
		byte[] bytes = new byte[1024]; // ��ʼ���ֽ�����,���ڻ���
		while (file_read.read(bytes) != -1) {// ����ļ�δ����
			file_write.write(bytes);// ����ȡ���ֽ�����д��Ŀ���ļ��������
		}
		file_read.close();// �ر�������
		file_write.close();// �ر������
	}
}