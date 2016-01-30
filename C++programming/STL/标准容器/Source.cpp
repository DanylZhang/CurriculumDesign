/*标准容器（类模板）的共性：vector,deque,list,set/multiset,map/multimap
构造函数：无参构造函数，拷贝函数，区间构造（两个迭代器表示的两个位置）
析构函数：
迭代器相关：正向：begin(),end()，反向：rbegin(),rend()
iterator,reverse_iterator,只读迭代器：const_iterator,const_reverse_iterator
对迭代器的操作：*,->,=,==,!=,++,--
插入：insert(pos,element)其中pos是插入位置，是个迭代器
删除：erase(pos),erase(pos_beg,pos_end)
清除：clear()
大小：size(),max_size(),empty()
交换：swap(c2),swap(c1,c2)
运算符：=,>,<,>=,<=,==,!=
*/
#include <iostream>
#include <vector>
#include <algorithm>
#include "print.h"
#include "test.h"
using namespace std;

int main()
{
	int a[5] = { 33, 55, 22, 44, 11 };
	vector<int> vi(begin(a), end(a));

	cout << vi.size() << endl;

	vector<int>::iterator b = vi.begin();
	print(vi.begin(), vi.end());

	sort(vi.begin(), vi.end());
	print(vi.begin(), vi.end());
	print(vi.rbegin(), vi.rend());//反向输出

	vi.insert(++++vi.begin(), 66);
	print(vi.begin(), vi.end());
	vi.insert(vi.end(), 88);
	print(vi.begin(), vi.end());
	cout << vi.size() << "/" << vi.max_size() << endl;

	//vi.erase(++++vi.begin(),vi.end()----);先用再减
	vi.erase(++++vi.begin(), ----vi.end());
	print(vi.begin(), vi.end());

	vector<int> t;
	cout << "vector当前容量：" << t.capacity() << endl;//vector容器才有的

	test();
	return 0;
}