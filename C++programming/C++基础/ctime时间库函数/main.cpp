#include <iostream>
#include <ctime>
using namespace std;

int main()
{
	tm newtime;
	time_t timer;
	time(&timer);
	localtime_s(&newtime, &timer);
	cout << "today is:"
		<< newtime.tm_year + 1900 << "-"
		<< newtime.tm_mon + 1 << "-"
		<< newtime.tm_mday << endl;
	return 0;
}