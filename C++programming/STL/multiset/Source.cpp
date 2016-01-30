/*multiset的个性：
元素就是key
允许有重复的key
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
	cout << "请输入你选举的人的姓名（end表示结束）：" << endl;
	while (cin >> name){//windows下默认Ctrl+Z结束输入
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