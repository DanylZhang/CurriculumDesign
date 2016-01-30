#include <iostream>
using namespace std;

int main()
{
	int i = 1;
number:
	i++;
	cout << "*";
	if (i < 10)
		goto number;
	cout << "\n³ÌĞò½áÊø\n";
	cout << "*********\n";
	return 0;
}