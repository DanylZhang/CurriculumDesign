#include <iostream>
using namespace std;

void swap(int &i1, int &i2) {
	int temp = i1;
	i1 = i2;
	i2 = temp;
}

int main()
{
	int i1, i2;
	swap(i1, i2);
	cout << i1 << i2 << endl;
}