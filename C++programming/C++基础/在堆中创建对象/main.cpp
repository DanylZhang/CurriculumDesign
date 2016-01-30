#include <iostream>
using namespace std;

class Human{
public:
	Human(){ cout << "构造函数执行中..." << endl; i = new int(999); }
	~Human(){ cout << "析构函数执行中..." << endl; delete i; }
	int getI() const { cout <<"this指针保存的内存地址："<< this << endl; return *i; }
	int getA() const{ return this->a; }
private:
	int *i;
	int a;
};

int main()
{
	void *p;
	p=new Human();
	Human *ph =static_cast<Human *> (p);
	cout << ph->getI() << endl<<ph->getA()<<endl;
	cout<<"sizeof(ph)="<<sizeof(ph) << endl <<"sizeof(*ph)=" <<sizeof(*ph) << endl;
	//delete p;由于与*ph指向同一块内存区域，故不能多次delete，否则程序运行时出错
	cout << "********" << endl;
	delete ph;
	cout << "********" << endl;
	return 0;
}