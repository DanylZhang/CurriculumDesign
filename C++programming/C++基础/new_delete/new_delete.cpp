#include <iostream>
using namespace std;

int main()
{
	int *p1 = new int;			//未初始化，垃圾数据
	cout << *p1 << endl;

	int *p2 = new int();		//零初始化
	cout << *p2 << endl;

	int *p3 = new int(1729);	//1729初始化
	cout << *p3 << endl;
	cout << *(p3 + 1) << endl;	//垃圾数据，相当于数组越界

	//int *p4 = new int[];		//未初始化，垃圾数据，并且报错了
	//cout << *p4 << endl;
	//cout << *(p4 + 1) << endl;	//垃圾数据，相当于数组越界

	int *p5 = new int[5];		//未初始化，垃圾数据
	cout << *p5 << endl;

	int *p6 = new int[5]();	//零初始化
	cout << *p6 << endl;

	int *p7 = new int[5]({ 1, 2 });//{..}部分初始化，其余为零
	cout << *p7 << endl;			// 1
	cout << *(p7 + 1) << endl;		// 2
	cout << *(p7 + 2) << endl;		// 0
	delete[] p7;
	//delete[] p7;	//delete不能重复操作
	return 0;
}