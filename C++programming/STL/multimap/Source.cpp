/*multimap的个性：
允许重复key
元素是(key,value)对，即pair
不支持方括号下标，因为multimap容器允许key重复
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
	m.insert(MSD::value_type("王刚", 100000));
	m.insert(MSD::value_type("王刚", 220000));
	m.insert(MSD::value_type("王刚", 150000));
	m.insert(make_pair("杨勇", 3000));
	m.insert(make_pair("何军军", 120000));
	m.insert(make_pair("何军军", 190000));
	m.insert(make_pair("杨勇", 90000));
	m.insert(make_pair("王刚", 230000));
	m.insert(make_pair("杨勇", 1000000));
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