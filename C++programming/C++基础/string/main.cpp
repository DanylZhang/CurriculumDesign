#define _SCL_SECURE_NO_WARNINGS
#include <iostream>
using namespace std;

int main()
{
	cout << "****************" << endl;
	char *ch = "123abcd";
	string str("UIcower");
	str[2] = 'P';
	cout << ch << endl << str.c_str() << endl;
	char ch1[8] = {};
	int iCount = str.copy(ch1, 3, 2);
	cout << ch1 << endl;

	cout << "****************" << endl;
	cout << "operator[]:\t" << str[2] << endl;
	cout << "at()����:\t" << str.at(2) << endl;

	cout << "****************" << endl;
	string strA = "UIPower";
	string strD(3, 'H');
	strD += strA;
	strD += "123";
	strD.append("abcdefg", 2);
	string strC("STLTest");
	strD.append(strC, 3, 4);
	cout << strD.c_str() << endl;
	if (!strD.empty())
		cout << "strD�ĳ��ȣ�" << strD.length() << endl;
	strD.assign(3, 'c');
	cout << strD.c_str() << endl;
	strD.assign("012345678abc", 3, 2);
	cout << strD.c_str() << endl;

	cout << "****************" << endl;
	strD.assign("Abc");
	strC.assign("abc");
	cout << strD.compare(strC) << endl;

	cout << "****************" << endl;
	cout << strD.substr(1, 2).c_str() << endl;

	cout << "****************" << endl;
	strA.assign("UIPower");
	int pos = strA.find("Po", 0);//�ڶ��������ɲ�д���Ҳ�������-1
	cout << pos << endl;
	pos = strA.rfind("Po");
	cout << pos << endl;

	cout << "****************" << endl;
	strA.assign("UIPower");
	strA.insert(2, "123");
	cout << strA.c_str() << endl;

	cout << "****************" << endl;
	strA.assign("UIPower");
	strA.erase(2, 3);
	cout << strA.c_str() << endl;

	cout << "****************" << endl;
	strA.assign("UIPower");
	strA.replace(2, 2, "----");
	cout << strA.c_str() << endl;

	cout << "****************" << endl;
	strA.assign("UIPower");
	strC.assign("Hello");

	cout << "����ǰ��" << endl;
	cout << "strA:" << strA.c_str() << endl;
	cout << "strC:" << strC.c_str() << endl;
	strA.swap(strC);
	cout << "������" << endl;
	cout << "strA:" << strA.c_str() << endl;
	cout << "strC:" << strC.c_str() << endl;
	return 0;
}