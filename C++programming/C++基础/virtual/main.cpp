#include <iostream>
using namespace std;

class Father{
public:
	virtual void run(){ cout << "���������ǧ��" << endl; }
	void jump(){ cout << "�������������" << endl; }
};

class Son:public Father{
	void run(){ cout << "�������������" << endl; }
	void jump(){ cout << "���������ʮ��" << endl; }
};

int main()
{
	Father *pfather = new Son;
	pfather->jump();
	pfather->run();
	pfather->Father::run();
	return 0;
}