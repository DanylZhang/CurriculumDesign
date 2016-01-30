//进行二分查找的前提是目标容器已经提前排好序。
/*lower_bound(pos_beg,pos_end,element);	仍然使用二分查找
	1.如果找到了返回其迭代器；
	2.如果找到了并且容器中不止一个目标元素，那么返回第一个的迭代器；
	3.如果没找到，则返回能插入目标元素的范围的右边界(有时会返回 pos_begin 或 pos_end)；*/
/*binary_search(pos_beg,pos_end,element);
	在范围内找element，如果找到了返回true，否则返回false*/
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int main()
{
	vector<int> v;
	v.push_back(11);
	v.push_back(22);
	v.push_back(33);
	v.push_back(44);
	v.push_back(55);
	v.push_back(33);

	sort(v.begin(), v.end());

	auto i1 = lower_bound(v.begin(), v.end(), 33);
	cout << *i1 << " " << *(++i1) << endl;

	auto i2 = lower_bound(v.begin(), v.end(), 50);
	cout << *i2 << endl;

	auto i3 = lower_bound(v.begin(), v.end(), 10);
	cout << *i3 << endl;

	auto i4 = lower_bound(v.begin(), v.end(), 90);
	if (i4 == v.end())
		cout << "end" << endl;

	if (binary_search(v.begin(), v.end(), 5))
		cout << "找到了" << endl;
	else
		cout << "没找到" << endl;
	return 0;
}