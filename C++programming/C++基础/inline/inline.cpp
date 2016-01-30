#include <iostream>
using namespace std;

class A{
public:
	inline void setX(int x);
	int getX();
private:
	int x;
};

inline void A::setX(int x)
{
	this->x = x;
}

int A::getX()
{
	return x;
}

int main()
{
	A a;
	a.setX(5);
	cout <<a.getX()<<endl;
	return 0;
}