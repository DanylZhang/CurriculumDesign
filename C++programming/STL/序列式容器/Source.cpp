/*����ʽ�����Ĺ��ԣ�vector,deque,list
���캯����ָ��Ԫ�ظ����ͳ�ʼֵ����ʼֵĬ��Ϊ���ʼ����
��������
���룺insert(pos,n,element),insert(pos,pos_begin,pos_end)
��ֵ��assign(n,element),assign(pos_begin,pos_end)
������resize(n,element=Ĭ�����ʼ��)
��β��front(),back()
��ɾ��push_back(),pop_back()ֻɾ��������void
*/
#include <iostream>
#include <string>
#include <deque>
#include "print.h"
using namespace std;

int main()
{
	deque<string> ds;
	//deque<vector<int>>
	ds.push_back("������");
	ds.push_back("������");
	ds.push_back("Ѧ����");
	ds.push_back("����");
	print(ds.begin(), ds.end());

	ds.insert(++++ds.begin(), 2, "ܽ��");
	print(ds.begin(), ds.end());

	string s[3] = { "���޴�", "��ӽ��", "������" };
	ds.insert(----ds.end(), s, s + 3);
	print(ds.begin(), ds.end());

	ds.pop_back(); ds.pop_back();
	print(ds.begin(), ds.end());

	ds.resize(12, "��һ��");
	print(ds.begin(), ds.end());

	//front(),back()���ص�����βԪ�ص����ã�����ζ�ſ�������������Ԫ��ֵ
	cout << "front:" << ds.front() << "back:" << ds.back() << endl;
	ds.front() = "��С��"; ds.back() = "�쾲��";
	cout << "front:" << ds.front() << "back:" << ds.back() << endl;

	ds.assign(5, "��ɭ��");
	print(ds.begin(), ds.end());
	return 0;
}