/*multiset�ĸ��ԣ�
Ԫ�ؾ���key
�������ظ���key
*/
#include <iostream>
#include <string>
#include <set>
#include <map>
#include "print.h"
using namespace std;

int main()
{
	multiset<string> ms;
	string name;
	cout << "��������ѡ�ٵ��˵�������end��ʾ��������" << endl;
	while (cin >> name){//windows��Ĭ��Ctrl+Z��������
		ms.insert(name);
	}
	print(ms.begin(), ms.end());

	cout << "*******************" << endl;
	multiset<string>::iterator ib = ms.begin(), ie;
	multimap<int, string> mis;
	while (ib != ms.end()){
		mis.insert(make_pair(ms.count(*ib), *ib));
		ib = ms.upper_bound(*ib);
	}
	print(mis.begin(), mis.end(),'\n');
	return 0;
}