/*adjacent_find(pos_beg,pos_end)
查找范围内连续相等的两个元素，找到则返回第一个元素的迭代器，否则返回end()
*/
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int main()
{
	vector<int> vecIntA;
	vecIntA.push_back(1);
	vecIntA.push_back(2);
	vecIntA.push_back(2);
	vecIntA.push_back(3);
	vecIntA.push_back(4);
	vecIntA.push_back(5);

	vector<int>::iterator  vit = adjacent_find(vecIntA.begin(), vecIntA.end());
	cout << *vit << endl;
	return 0;
}