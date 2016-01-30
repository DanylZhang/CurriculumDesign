#include <iostream>
#include <windows.h>
using namespace std;

int main()
{
	SYSTEMTIME sys;
	GetLocalTime(&sys);
	cout << "today is:"
		<< sys.wYear << "-"
		<< sys.wMonth << "-"
		<< sys.wDay << endl;
	return 0;
}