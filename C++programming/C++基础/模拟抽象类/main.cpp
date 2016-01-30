//模拟抽象类
#include <iostream>
using namespace std;

class Human{
public:
	virtual void smart(){}//这只是虚函数，并不是纯虚函数；虚函数只是为了帮助实现多态；虚函数体可以为空也可以不为空
	virtual void beautiful(){}
	virtual ~Human(){ cout << "析构人类" << endl; }
};

class Father:virtual public Human{
public:
	void smart(){ cout << "父亲很聪明" << endl; }
	virtual ~Father(){ cout << "析构父类" << endl; }
};

class Mother :virtual public Human{
public:
	void beautiful(){ cout << "母亲很漂亮" << endl; }
	virtual ~Mother(){ cout << "析构母类" << endl; }
};

class Son:public Father,public Mother{
public:
	void smart(){ cout << "儿子很聪明" << endl; }
	void beautiful(){ cout << "儿子也很帅" << endl; }
	~Son(){ cout << "析构儿子" << endl; }
};

int main()
{
	Human *p;
	int choice = 0;
	bool quit = false;
	while (true)
	{
		cout << "(0)退出(1)父亲(2)母亲(3)儿子：";
		cin >> choice;
		switch (choice)
		{
		case 0:
			quit = true;
			break;
		case 1:
			p = new Father;
			p->smart();
			delete p;
			break;
		case 2:
			p = new Mother;
			p->beautiful();
			delete p;
			break;
		case 3:
			p = new Son;
			p->beautiful();
			p->smart();
			delete p;
			break;
		default:
			cout << "请输入0、1、2或3" << endl;
			break;
		}
		if (quit)
			break;
	}
	return 0;
}