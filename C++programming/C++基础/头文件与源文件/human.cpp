#include "human.h"

human::human(int x, int y)
{
	this->x = x;
	this->y = y;
	cout << "调用了构造函数。" << endl;
}
human::~human()
{
	cout << "调用了析构函数。" << endl;
}
void human::setXY(int x,int y)
{
	this->x = x;
	this->y = y;
}
void human::showXY()
{
	cout << "x=" << x << endl << "y=" << y << endl;
}

int main()
{
	human a[3];
	return 0;
}