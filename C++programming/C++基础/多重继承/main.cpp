//使用多重继承
#include <iostream>
using namespace std;

class Father{
public:
	void smart(){ cout << "父亲很聪明" << endl; }
	virtual ~Father(){ cout << "析构父类" << endl; }
};

class Mother{
public:
	void beautiful(){ cout << "母亲很漂亮" << endl; }
	virtual ~Mother(){ cout << "析构母类" << endl; }
};

class Son :public Father, public Mother{
public:
	~Son(){ cout << "析构儿子" << endl; }
};

int main()
{
	Father *pf;
	Mother *pm;
	int choice = 0;
	bool quit = false;
	while (true)
	{
		cout << "(0)退出(1)父亲(2)儿子：";
		cin >> choice;
		switch (choice)
		{
		case 0:
			quit = true;
			break;
		case 1:
			pf = new Father;
			//pf->beautiful();
			pf->smart();
			delete pf;
			break;
		case 2:
			pm = new Son;
			pm->beautiful();
			//pm->smart();
			delete pm;
			break;
		default:
			cout << "请输入0、1或2" << endl;
			break;
		}
		if (quit)
			break;
	}
	return 0;
}