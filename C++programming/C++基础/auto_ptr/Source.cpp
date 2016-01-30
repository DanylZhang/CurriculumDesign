#include <iostream>
using namespace std;

template<typename T>
class Auto_ptr{
	T *p;
public:
	Auto_ptr(T *p) :p(p){}
	~Auto_ptr(){ delete p; }
	Auto_ptr(Auto_ptr &a) :p(0){ operator=(a); }//���ƹ���
	Auto_ptr & operator=(Auto_ptr &a){//=����
		if (this == &a)return *this;
		if (p != NULL)delete p;
		p = a.p;
		a.p = NULL;
		return *this;
	}
	T & operator*()const{ return *p; }
	T * operator->()const{ return p; }
};

class A{
	int data;
public:
	A(int d) :data(d){ cout << this << "A(" << d << ")" << endl; }
	~A(){ cout << this << "~A()" << data << endl; }
	void show(){ cout << this << ":" << data << endl; }
};

int main()
{
	Auto_ptr<A> p(new A(10));
	p->show();
	Auto_ptr<A> q(p);
	//p->show();����p�Ѿ�û�ж�̬�ڴ������Ȩ��
	q->show();
	(*q).show();
	p = q;
	return 0;
}