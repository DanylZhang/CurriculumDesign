//未使用多重继承
#include <iostream>
using namespace std;

class Father{
public:
	void smart(){ cout << "父亲很聪明" << endl; }
	//virtual void beautiful(){}beautiful本不属于父类
	virtual ~Father(){ cout << "析构父类" << endl; }
};

class Son :public Father{
public:
	//void smart(){ cout << "儿子很聪明" << endl; }
	void beautiful(){ cout << "儿子很帅" << endl; }
	~Son(){ cout << "析构儿子" << endl; }
};
int main()
{
	Father *pf;
	int choice = 0;
	bool quit = false;
	cout << "(0)退出(1)父亲(2)儿子" << endl;
	while (true)
	{
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
			pf = new Son;
			dynamic_cast<Son *>(pf)->beautiful();
			pf->smart();
			delete pf;
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