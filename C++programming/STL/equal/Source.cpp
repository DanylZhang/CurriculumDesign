//equal(a.begin(),a.end(),b.begin());
//A�������B�ȣ�B�ĳ��ȱ�����ڻ����A�����䣬����᷶Χ����
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
	if (equal(a.begin(), a.end(), b.begin()))	//Ҳ����˵A����һ�������B�����
		cout << "Sequence A equals Sequence B" << endl;
	return 0;
}