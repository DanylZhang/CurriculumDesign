#include <iostream>
using namespace std;

class Father{
public:
	virtual void run(){ cout << "父类可以跑千米" << endl; }
	void jump(){ cout << "父类可以跳五米" << endl; }
};

class Son:public Father{
	void run(){ cout << "子类可以跑万米" << endl; }
	void jump(){ cout << "子类可以跳十米" << endl; }
};

int main()
{
	Father *pfather = new Son;
	pfather->jump();
	pfather->run();
	pfather->Father::run();
	return 0;
}