#include <iostream>
using namespace std;

class num{
public:
	explicit num(const int n = 0)//指定必须是显示
	{
		if (n < 0)
		{
			cout << "自然数需大于零！" << endl;
			this->n = 0;
		}
		else
			this->n = n;
		cout << "构造函数执行..." << endl;
	}
	num(const num &a){ n = a.n; cout << "复制构造函数执行..." << endl; }
	~num(){ cout << "析构函数执行..." << endl; }
	void setN(int n){ this->n = n; }
	int getN()const{ return n; }
	const num & operator++()//前置自加
	{
		++n;
		return *this;
	}
	const num operator++(int o)//后置自加
	{
		num temp(n);
		++n;
		return temp;
	}
	const num operator+(const num &b) const { return num(this->n + b.n); }
	friend ostream & operator<<(ostream &c, const num &a);
	/*由于该运算符重载函数的参数含有非该类对象，所以不能属于该类的成员函数,
	那么就不能直接访问该类的私有成员，可以用关键字friend解决该问题，
	将重载运算符<<函数作为该类的友元函数就可以使此函数直接访问num类私有成员*/
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
			cout << "自然数需大于零！" << endl;
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
	n = num(1);//explicit显式
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