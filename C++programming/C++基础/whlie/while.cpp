#include <iostream>
using namespace std;

int main()
{
	int i = 0;
	while (true)
	{
		int num;
		cout << "请输入一个数：";
		cin >> num;
		cout << "您输入的是：" << num << endl;
		i++;
		if (i > 3)
			break;
	}
	return 0;
}