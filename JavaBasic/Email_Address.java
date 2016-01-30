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
	private static String url = null;// ��ַ
	private static StringBuffer htmlsource = null;// ��ҳԴ����
	private static String regex = "\\d{3,11}@qq.com";// ������ʽ
	
	public static void main(String[] args) {
		setURL();
		setHtmlSource();
		// setRegex();
		getEmail_Adress();
	}

	public static void setURL() {// ����url
		System.out.println("Please input URL:");
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext("^https?://.+$")) {
			url = scan.next();
		} else
			setURL("Please input URL again:");
	}

	public static void setURL(String str) {// ʧ��ʱ����
		System.out.println(str);
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext("^https?://.+$")) {
			url = scan.next();
		} else
			setURL("Please input URL again:");
	}

	public static void setHtmlSource() {// ��ȡ��ҳԴ����
		try {
			URL url = new URL(Email_Address.url);// ʵ����url���Ӷ���
			HttpURLConnection con = (HttpURLConnection) url.openConnection();// ��������

			InputStream inputStr = con.getInputStream();// �õ�������
			InputStreamReader instrReader = new InputStreamReader(inputStr);// ��ȡ������
			BufferedReader buffStr = new BufferedReader(instrReader);// �����ݴ��뻺����

			String string = null;
			htmlsource = new StringBuffer();
			while ((string = buffStr.readLine()) != null)
				htmlsource.append(string);// ��������д�뵽��ҳԴ����Buffer
			inputStr.close();// �ر�������
			// System.out.println(htmlsource);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public static void setRegex() {// ����������ʽ
		System.out.println("Please input Regex:");
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext()) {
			regex = scan.next();
		} else
			setRegex("Please input Regex again:");
	}

	public static void setRegex(String str) {// ʧ��ʱ����
		System.out.println(str);
		Scanner scan = new Scanner(System.in);
		if (scan.hasNext()) {
			regex = scan.next();
		} else
			setRegex("Please input Regex again:");
	}

	public static void getEmail_Adress() {// ƥ����ҳ���е������ַ����ӡ
		int i = 0;
		Pattern pattern = Pattern.compile(regex);// ��������ʽ�����ģʽ������
		Matcher matcher = pattern.matcher(htmlsource);// ����ƥ��
		while (matcher.find())
			System.out.println(++i + "\t" + matcher.group());
	}
}