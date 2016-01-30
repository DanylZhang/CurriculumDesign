/*multimap�ĸ��ԣ�
�����ظ�key
Ԫ����(key,value)�ԣ���pair
��֧�ַ������±꣬��Ϊmultimap��������key�ظ�
*/
#include <iostream>
#include <string>
#include <map>
#include "print.h"
using namespace std;

int main()
{
	typedef multimap<string, double> MSD;
	MSD m;
	m.insert(MSD::value_type("����", 100000));
	m.insert(MSD::value_type("����", 220000));
	m.insert(MSD::value_type("����", 150000));
	m.insert(make_pair("����", 3000));
	m.insert(make_pair("�ξ���", 120000));
	m.insert(make_pair("�ξ���", 190000));
	m.insert(make_pair("����", 90000));
	m.insert(make_pair("����", 230000));
	m.insert(make_pair("����", 1000000));
	print(m.begin(), m.end());

	cout << "***************************" << endl;
	MSD::iterator ib = m.begin(), ie;
	map<string,double> cnt;
	while (ib != m.end()){
		string name = ib->first;
		ie = m.upper_bound(name);
		double sum = 0.0;
		while (ib != ie)
			sum += (ib++)->second;
		cnt.insert(make_pair(name, sum*0.03));
	}
	print(cnt.begin(), cnt.end());
	return 0;
}