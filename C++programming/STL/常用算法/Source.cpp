#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>//包含少数的算术运算模板，例如：accumulate
#include "print.h"
using namespace std;

int main()
{
	vector<int> viA;
	viA.push_back(1);
	viA.push_back(3);
	viA.push_back(5);
	viA.push_back(7);
	viA.push_back(9);
	print(viA.begin(), viA.end());
	cout << "viA的累加和：" << accumulate(viA.begin(), viA.end(), 0) << endl;

	vector<int> viB;
	viB.push_back(1);
	viB.push_back(3);
	viB.push_back(5);
	viB.push_back(6);
	viB.push_back(8);
	//fill(viB.begin(), viB.end(), 1);填充函数
	print(viB.begin(), viB.end());

	vector<int> viC;
	viC.resize(10);
	//集合交集，应提前将填充容器设置足够的大小
	set_intersection(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	viC.clear();

	viC.resize(10);
	//集合并集，应提前将填充容器设置足够的大小
	set_union(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	viC.clear();

	viC.resize(10);
	//集合的差集，前面的viA减去后面的viB
	set_difference(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	viC.clear();

	viC.resize(10);
	//集合的异或，即对称差
	set_symmetric_difference(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	return 0;
}