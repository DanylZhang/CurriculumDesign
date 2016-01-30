#include <iostream>
#include <typeinfo>
using namespace std;

template<typename T>//类模板
class Type{
public:
	static string name(){ return typeid(T).name(); }
};

template<typename T>//偏特化类模板
class Type<T *>{
public:
	static string name(){ string name = typeid(T).name(); return name + " pointer"; }
};

//函数模板更优秀，可以不用指定类型，根据传的参数自动推测出其具体类型
template<typename T = int>
string type(T t = 0)
{
	return Type<T>::name();
}

template<typename T, typename U>
T max(T &a, U &b)
{
	return a > b ? a : T(b);
}

int main()
{
	cout << type(123).c_str() << endl;//int
	cout << type(2.13).c_str() << endl;//double
	int i;
	cout << type(&i).c_str() << endl;//int pointer
	cout << type().c_str() << endl;//默认参数类型

	cout << "***************" << endl;
	int a = 4;
	double b = 4.56;
	cout << "最大值：" << max(b, a)/*函数模板可以自动识别参数类型*/ << endl;
	return 0;
}