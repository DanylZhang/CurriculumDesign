#include <iostream>
using namespace std;

int main()
{
	int i = 0;
	while (true)
	{
		int num;
		cout << "������һ������";
		cin >> num;
		cout << "��������ǣ�" << num << endl;
		i++;
		if (i > 3)
			break;
	}
	return 0;
}