/*
iterator find(pos_beg,pos_end,data)
iterator find_if(pos_beg,pos_end,func)	bool func(element)
int count(...)	int count_if(...)
*/
#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
using namespace std;

bool init_upper(const string &s){
	return isupper(s[0]);
}
bool has_o(const string &s){
	return s.find_first_of("oO") != string::npos;
	//find_first_of(str1)�ҹ��е��ַ�����������λ��
	//npos=-1�������Ų�����Դ�ַ�����λ��
	//������npos��˵���ҵ���
}

int main()
{
	string a[7] = { "abc", "good", "Day", "look", "God", "Ok", "bye" };
	string *p = find(a, a + 7, "look");
	cout << (p == (a + 7) ? "û�ҵ�" : "�ҵ���") << "look" << endl;
	p = find(a, a + 7, "book");
	cout << (p == (a + 7) ? "û�ҵ�" : "�ҵ���") << "book" << endl;
	p = find_if(a, a + 7, init_upper);
	cout << (p == (a + 7) ? "û�ҵ���д��ĸ��ͷ���ַ���" : "�ҵ���") << *p << endl;
	
	cout << "�ҵ���" << count(a, a + 7, "God") << "��" << "God" << endl;
	cout << "��д��ĸ��ͷ���ַ�����" << count_if(a, a + 7, init_upper) << "��" << endl;
	cout << count_if(a, a + 7, has_o) << endl;
	return 0;
}