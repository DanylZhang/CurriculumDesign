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
	catch (...)//�����á�...������δ֪���쳣����
	{
		cerr << "EXCEPTION!" << endl;
	}
	return 0;
}