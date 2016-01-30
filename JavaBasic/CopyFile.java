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
		Frame.setTitle("文件复制-张丹玉");
		Frame.setBounds(100, 100, 628, 366);
		Frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Frame.getContentPane().setLayout(null);

		JLabel lbl_source = new JLabel("源文件：");
		lbl_source.setHorizontalAlignment(SwingConstants.LEFT);
		lbl_source.setFont(new Font("宋体", Font.BOLD, 14));
		lbl_source.setBounds(21, 50, 68, 25);
		Frame.getContentPane().add(lbl_source);

		JLabel lbl_destination = new JLabel("复制到：");
		lbl_destination.setHorizontalAlignment(SwingConstants.LEFT);
		lbl_destination.setFont(new Font("宋体", Font.BOLD, 14));
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

		// -------------------------------------------------------------选择源文件或源文件夹
		JButton button_source = new JButton("选 择");
		button_source.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				// 文件选择器
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
					JOptionPane.showMessageDialog(null, "源文件路径获取失败！", "错误提示",
							JOptionPane.ERROR_MESSAGE);
				}
			}
		});
		button_source.setFont(new Font("黑体", Font.BOLD, 16));
		button_source.setToolTipText("选择源文件或源文件夹");
		button_source.setBounds(509, 50, 93, 25);
		Frame.getContentPane().add(button_source);

		// -------------------------------------------------------------复制到...
		JButton button_destination = new JButton("选 择");
		button_destination.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				// 文件选择器
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
		button_destination.setFont(new Font("黑体", Font.BOLD, 16));
		button_destination.setToolTipText("复制到...");
		button_destination.setBounds(509, 109, 93, 25);
		Frame.getContentPane().add(button_destination);

		// -------------------------------------------------------------开始复制
		JButton button_copy = new JButton("开始复制");
		button_copy.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				File file_in = new File(textField_source.getText());
				File file_out = new File(textField_destination.getText());
				if (!file_in.exists()) {
					JOptionPane.showMessageDialog(null, "源文件不存在！", "提醒",
							JOptionPane.INFORMATION_MESSAGE);
				} else if (file_out.list() != null) {
					JOptionPane.showMessageDialog(null, "目标文件已存在！", "提醒",
							JOptionPane.INFORMATION_MESSAGE);
				} else if (file_in.exists() && !file_out.exists()) {
					try {
						new FileCopy(file_in, file_out);
					} catch (IOException e1) {
						JOptionPane.showMessageDialog(null, e1.getMessage(),
								"提醒", JOptionPane.INFORMATION_MESSAGE);
					}
				}
			}
		});
		button_copy.setFont(new Font("楷体", Font.BOLD, 22));
		button_copy.setBounds(223, 200, 172, 60);
		Frame.getContentPane().add(button_copy);
	}
}

class FileCopy {

	public FileCopy(File file_in, File file_out) throws IOException {
		// 以下两个语句不是重点,可不写

		// 如果要复制的目录不存在,先创建目录
		if (!file_in.exists()) {
			if (file_in.isDirectory()) {
				file_in.mkdir();
			}
		}

		// 如果要复制到目的地的目录不存在,先创建目录
		if (!file_out.exists()) {
			if (file_out.isDirectory()) {
				file_out.mkdir();
			}
		}
		copy(file_in, file_out);
	}

	// 递归
	public void copy(File file_in, File file_out) throws IOException {

		// 判断File是目录还是文件,是目录就创建目录,是文件就创建文件.且是文件的话,直接返回递归的上一层
		if (file_in.isDirectory()) {
			file_out.mkdir();
		} else if (file_in.isFile()) {
			FileInputStream file_read = new FileInputStream(file_in);
			FileOutputStream file_write = new FileOutputStream(file_out);
			copyFile(file_read, file_write);
			return;
		}

		// 如果该目录下的文件的数量为0,表明是个空的目录,也直接返回到递归上一层.
		if (file_in.list().length == 0) {
			return;
		}

		// 定义files为该目录下所有文件名的数组
		String[] files = file_in.list();

		// paths为源文件路径,patht为目标路径
		String paths = "", patht = "";

		// 对源文件路径和目标路径赋值.
		paths = file_in.getPath() + File.separator;
		patht = file_out.getPath() + File.separator;

		// 对以上条件,进行文件递归
		for (int i = 0; i < files.length; i++) {
			File souf = new File(paths + files[i] + File.separator);
			File tof = new File(patht + files[i] + File.separator);
			copy(souf, tof);
		}
	}

	private void copyFile(FileInputStream file_read, FileOutputStream file_write)
			throws IOException {
		byte[] bytes = new byte[1024]; // 初始化字节数组,用于缓冲
		while (file_read.read(bytes) != -1) {// 如果文件未读完
			file_write.write(bytes);// 将读取的字节数组写入目标文件输出流中
		}
		file_read.close();// 关闭输入流
		file_write.close();// 关闭输出流
	}
}