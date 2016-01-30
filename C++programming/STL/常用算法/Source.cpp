#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>//������������������ģ�壬���磺accumulate
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
	cout << "viA���ۼӺͣ�" << accumulate(viA.begin(), viA.end(), 0) << endl;

	vector<int> viB;
	viB.push_back(1);
	viB.push_back(3);
	viB.push_back(5);
	viB.push_back(6);
	viB.push_back(8);
	//fill(viB.begin(), viB.end(), 1);��亯��
	print(viB.begin(), viB.end());

	vector<int> viC;
	viC.resize(10);
	//���Ͻ�����Ӧ��ǰ��������������㹻�Ĵ�С
	set_intersection(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	viC.clear();

	viC.resize(10);
	//���ϲ�����Ӧ��ǰ��������������㹻�Ĵ�С
	set_union(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	viC.clear();

	viC.resize(10);
	//���ϵĲ��ǰ���viA��ȥ�����viB
	set_difference(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	viC.clear();

	viC.resize(10);
	//���ϵ���򣬼��ԳƲ�
	set_symmetric_difference(viA.begin(), viA.end(), viB.begin(), viB.end(), viC.begin());
	print(viC.begin(), viC.end());
	return 0;
}