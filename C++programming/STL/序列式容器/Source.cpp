/*序列式容器的共性：vector,deque,list
构造函数：指定元素个数和初始值（初始值默认为零初始化）
析构函数
插入：insert(pos,n,element),insert(pos,pos_begin,pos_end)
赋值：assign(n,element),assign(pos_begin,pos_end)
调整：resize(n,element=默认零初始化)
首尾：front(),back()
增删：push_back(),pop_back()只删除，返回void
*/
#include <iostream>
#include <string>
#include <deque>
#include "print.h"
using namespace std;

int main()
{
	deque<string> ds;
	//deque<vector<int>>
	ds.push_back("曾文武");
	ds.push_back("赵旭泽");
	ds.push_back("薛晓娟");
	ds.push_back("高上");
	print(ds.begin(), ds.end());

	ds.insert(++++ds.begin(), 2, "芙蓉");
	print(ds.begin(), ds.end());

	string s[3] = { "张艳春", "张咏翔", "刘克雷" };
	ds.insert(----ds.end(), s, s + 3);
	print(ds.begin(), ds.end());

	ds.pop_back(); ds.pop_back();
	print(ds.begin(), ds.end());

	ds.resize(12, "郭一茹");
	print(ds.begin(), ds.end());

	//front(),back()返回的是首尾元素的引用，这意味着可以用其来更改元素值
	cout << "front:" << ds.front() << "back:" << ds.back() << endl;
	ds.front() = "曾小贤"; ds.back() = "徐静蕾";
	cout << "front:" << ds.front() << "back:" << ds.back() << endl;

	ds.assign(5, "康森林");
	print(ds.begin(), ds.end());
	return 0;
}