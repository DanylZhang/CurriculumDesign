//ģ�������
#include <iostream>
using namespace std;

class Human{
public:
	virtual void smart(){}//��ֻ���麯���������Ǵ��麯�����麯��ֻ��Ϊ�˰���ʵ�ֶ�̬���麯�������Ϊ��Ҳ���Բ�Ϊ��
	virtual void beautiful(){}
	virtual ~Human(){ cout << "��������" << endl; }
};

class Father:virtual public Human{
public:
	void smart(){ cout << "���׺ܴ���" << endl; }
	virtual ~Father(){ cout << "��������" << endl; }
};

class Mother :virtual public Human{
public:
	void beautiful(){ cout << "ĸ�׺�Ư��" << endl; }
	virtual ~Mother(){ cout << "����ĸ��" << endl; }
};

class Son:public Father,public Mother{
public:
	void smart(){ cout << "���Ӻܴ���" << endl; }
	void beautiful(){ cout << "����Ҳ��˧" << endl; }
	~Son(){ cout << "��������" << endl; }
};

int main()
{
	Human *p;
	int choice = 0;
	bool quit = false;
	while (true)
	{
		cout << "(0)�˳�(1)����(2)ĸ��(3)���ӣ�";
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
			cout << "������0��1��2��3" << endl;
			break;
		}
		if (quit)
			break;
	}
	return 0;
}