/*���������ࣺ++,*,->,==,!=
������������ɶ�*it��ֵ������һ�����޸�*it��ֵ
�������������д*it��ֵ������һ���ɶ���*it��ֵ
ǰ����������ɶ��ֿ�д
˫���������֧��--
�����������������ָ��һ����֧��+=��-=��֧���±�[]��֧�ֱȽϴ�С
*/
#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <iterator>//�����������Ҫ
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