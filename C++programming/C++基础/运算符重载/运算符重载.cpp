#include <iostream>
using namespace std;

class num{
public:
	explicit num(const int n = 0)//ָ����������ʾ
	{
		if (n < 0)
		{
			cout << "��Ȼ��������㣡" << endl;
			this->n = 0;
		}
		else
			this->n = n;
		cout << "���캯��ִ��..." << endl;
	}
	num(const num &a){ n = a.n; cout << "���ƹ��캯��ִ��..." << endl; }
	~num(){ cout << "��������ִ��..." << endl; }
	void setN(int n){ this->n = n; }
	int getN()const{ return n; }
	const num & operator++()//ǰ���Լ�
	{
		++n;
		return *this;
	}
	const num operator++(int o)//�����Լ�
	{
		num temp(n);
		++n;
		return temp;
	}
	const num operator+(const num &b) const { return num(this->n + b.n); }
	friend ostream & operator<<(ostream &c, const num &a);
	/*���ڸ���������غ����Ĳ������зǸ���������Բ������ڸ���ĳ�Ա����,
	��ô�Ͳ���ֱ�ӷ��ʸ����˽�г�Ա�������ùؼ���friend��������⣬
	�����������<<������Ϊ�������Ԫ�����Ϳ���ʹ�˺���ֱ�ӷ���num��˽�г�Ա*/
	friend istream & operator>>(istream &c, num &a);
private:
	int n;
};

ostream & operator<<(ostream &c, const num &a)
{
	c << a.n;
	return c;
}

istream & operator>>(istream &c, num &a)
{
	c >> a.n;
	do{
		if (!(a.n < 0))
			break;
		else
		{
			cout << "��Ȼ��������㣡" << endl;
			cin >> a.n;
			//cin.sync();
			//cin.clear();
		}
	} while (a.n < 0);
	return c;
}

int main()
{
	cout << "****************" << endl;
	num a, b;
	cin >> a >> b;
	cout << "a=" << a << "\tb=" << b << endl;
	b = a;
	cout << "b=" << b << endl;
	cout << "****************" << endl;
	num n(-1);
	cout << "n=" << n << endl;
	n = num(1);//explicit��ʽ
	cout << "n=" << n << endl;
	++n;
	cout << "n=" << n << endl;
	num i = ++n;
	cout << "i=" << i << "\tn=" << n << endl;
	num j = n++;
	cout << "j=" << j << "\tn=" << n << endl;
	cout << "****************" << endl;
	cout << "j+n=" << j + n << endl;
	cout << "****************" << endl;
	return 0;
}