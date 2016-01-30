/*迭代器分类：++,*,->,==,!=
输入迭代器：可读*it的值，但不一定能修改*it的值
输出迭代器：可写*it的值，但不一定可读的*it的值
前向迭代器：可读又可写
双向迭代器：支持--
随机迭代器：几乎跟指针一样，支持+=，-=，支持下标[]，支持比较大小
*/
#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <iterator>//特殊迭代器需要
#include "print.h"
using namespace std;

int main()
{
	istream_iterator<int> in(cin), end;
	vector<int> vi;
	copy(in, end, back_inserter(vi));
	print(vi.begin(), vi.end());

	ostream_iterator<int> o(cout, "*");
	copy(vi.begin(), vi.end(), o); cout << endl;

	ofstream fo("datafile");
	ostream_iterator<int> fiter(fo, " ");
	copy(vi.begin(), vi.end(), fiter); fo << endl;
	fo.close();

	ifstream fin("datafile");
	istream_iterator<int> fit(fin);
	vector<int> v;
	copy(fit, end, back_inserter(v));
	print(v.begin(), v.end(),',');
	fin.close();
	return 0;
}