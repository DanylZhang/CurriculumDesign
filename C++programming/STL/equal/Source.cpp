//equal(a.begin(),a.end(),b.begin());
//A的区间和B比，B的长度必须大于或等于A的区间，否则会范围出错
#include <iostream>
#include <functional>
#include <vector>
using namespace std;

int main()
{
	vector<int> a;
	a.push_back(11);
	a.push_back(22);
	a.push_back(33);
	a.push_back(44);
	a.push_back(55);
	vector<int> b;
	b.push_back(11);
	b.push_back(22);
	b.push_back(33);
	b.push_back(44);
	b.push_back(55);
	b.push_back(66);
	if (equal(a.begin(), a.end(), b.begin()))	//也就是说A的这一块区间和B的相等
		cout << "Sequence A equals Sequence B" << endl;
	return 0;
}