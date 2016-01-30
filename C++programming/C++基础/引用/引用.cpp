#include <iostream>
using namespace std;

int main()
{
	int num;
	int &rnum = num;
	num = 1;
	cout << "rnum=" << rnum << "\t" << "num=" << num << endl;
	rnum = 10;
	cout << "rnum=" << rnum << "\t" << "num=" << num << endl;
	cout << "&num=" << &num << "\t" << "&rnum=" << &rnum << endl;
	return 0;
}