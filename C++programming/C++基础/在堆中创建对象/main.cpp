#include <iostream>
using namespace std;

class Human{
public:
	Human(){ cout << "���캯��ִ����..." << endl; i = new int(999); }
	~Human(){ cout << "��������ִ����..." << endl; delete i; }
	int getI() const { cout <<"thisָ�뱣����ڴ��ַ��"<< this << endl; return *i; }
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
	//delete p;������*phָ��ͬһ���ڴ����򣬹ʲ��ܶ��delete�������������ʱ����
	cout << "********" << endl;
	delete ph;
	cout << "********" << endl;
	return 0;
}