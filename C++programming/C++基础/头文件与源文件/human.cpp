#include "human.h"

human::human(int x, int y)
{
	this->x = x;
	this->y = y;
	cout << "�����˹��캯����" << endl;
}
human::~human()
{
	cout << "����������������" << endl;
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