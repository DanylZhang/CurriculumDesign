//ʹ�ö��ؼ̳�
#include <iostream>
using namespace std;

class Father{
public:
	void smart(){ cout << "���׺ܴ���" << endl; }
	virtual ~Father(){ cout << "��������" << endl; }
};

class Mother{
public:
	void beautiful(){ cout << "ĸ�׺�Ư��" << endl; }
	virtual ~Mother(){ cout << "����ĸ��" << endl; }
};

class Son :public Father, public Mother{
public:
	~Son(){ cout << "��������" << endl; }
};

int main()
{
	Father *pf;
	Mother *pm;
	int choice = 0;
	bool quit = false;
	while (true)
	{
		cout << "(0)�˳�(1)����(2)���ӣ�";
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
			cout << "������0��1��2" << endl;
			break;
		}
		if (quit)
			break;
	}
	return 0;
}