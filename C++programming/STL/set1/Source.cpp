/*set�ĸ��ԣ�
Ԫ�ؾ���key�����Ҳ������ظ�key�������ظ�key�²���Ļᱻ����
��key����Ĭ����С�ں�
*/
#include <iostream>
#include <fstream>
#include <string>
#include <set>
#include "print.h"
using namespace std;

int main()
{
	set<string> ss;//set<char *> ss;ֻ��������������׵�ַ
	string s;//char s[100];
	ifstream fin("maillist");
	if (!fin){ return 1; }
	while (fin >> s)ss.insert(s);
	print(ss.begin(), ss.end(),'\n');
	return 0;
}