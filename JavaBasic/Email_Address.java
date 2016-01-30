package email_address;

import java.util.Scanner;
import java.net.URL;
import java.net.HttpURLConnection;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.BufferedReader;
import java.io.IOException;
import java.util.regex.Pattern;
import java.util.regex.Matcher;

public class Email_Address {
	private static String url = null;// 网址
	private static StringBuffer htmlsource = null;// 网页源代码
	private static String regex = "\\d{3,11}@qq.com";// 正则表达式
	
	public static void main(String[] args) {
		setURL();
		setHtmlSource();
		// setRegex();
		getEmail_Adress();
	}

	public static void setURL() {// 设置url
		System.out.println("Please input URL:");
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext("^https?://.+$")) {
			url = scan.next();
		} else
			setURL("Please input URL again:");
	}

	public static void setURL(String str) {// 失败时重载
		System.out.println(str);
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext("^https?://.+$")) {
			url = scan.next();
		} else
			setURL("Please input URL again:");
	}

	public static void setHtmlSource() {// 获取网页源代码
		try {
			URL url = new URL(Email_Address.url);// 实例化url链接对象
			HttpURLConnection con = (HttpURLConnection) url.openConnection();// 进行连接

			InputStream inputStr = con.getInputStream();// 得到输入流
			InputStreamReader instrReader = new InputStreamReader(inputStr);// 读取输入流
			BufferedReader buffStr = new BufferedReader(instrReader);// 将内容存入缓冲流

			String string = null;
			htmlsource = new StringBuffer();
			while ((string = buffStr.readLine()) != null)
				htmlsource.append(string);// 将缓冲流写入到网页源代码Buffer
			inputStr.close();// 关闭输入流
			// System.out.println(htmlsource);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public static void setRegex() {// 设置正则表达式
		System.out.println("Please input Regex:");
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext()) {
			regex = scan.next();
		} else
			setRegex("Please input Regex again:");
	}

	public static void setRegex(String str) {// 失败时重载
		System.out.println(str);
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext()) {
			regex = scan.next();
		} else
			setRegex("Please input Regex again:");
	}

	public static void getEmail_Adress() {// 匹配网页当中的邮箱地址并打印
		int i = 0;
		Pattern pattern = Pattern.compile(regex);// 将正则表达式编译成模式串对象
		Matcher matcher = pattern.matcher(htmlsource);// 进行匹配
		while (matcher.find())
			System.out.println(++i + "\t" + matcher.group());
	}
}