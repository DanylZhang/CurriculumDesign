#include <iostream>
#include <exception>
using namespace std;

int main()
{
	try
	{
		throw runtime_error("HEHE");
	}
	catch (exception &e)
	{
		cerr << "EXCEPTION!" << e.what() << endl;
	}
	catch (...)//可以用“...”代替未知的异常类型
	{
		cerr << "EXCEPTION!" << endl;
	}
	return 0;
}