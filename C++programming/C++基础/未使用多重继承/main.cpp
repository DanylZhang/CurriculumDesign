//δʹ�ö��ؼ̳�
#include <iostream>
using namespace std;

class Father{
public:
	void smart(){ cout << "���׺ܴ���" << endl; }
	//virtual void beautiful(){}beautiful�������ڸ���
	virtual ~Father(){ cout << "��������" << endl; }
};

class Son :public Father{
public:
	//void smart(){ cout << "���Ӻܴ���" << endl; }
	void beautiful(){ cout << "���Ӻ�˧" << endl; }
	~Son(){ cout << "��������" << endl; }
};
int main()
{
	Father *pf;
	int choice = 0;
	bool quit = false;
	cout << "(0)�˳�(1)����(2)����" << endl;
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
			cout << "������0��1��2" << endl;
			break;
		}
		if (quit)
			break;
	}
	return 0;
}