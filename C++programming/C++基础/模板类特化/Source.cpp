#include <iostream>
#include <typeinfo>
using namespace std;

template<int n>
class Fact{
public:
	enum { val = Fact<n - 1>::val*n };//������ö�٣��ݹ�
};

template<>
class Fact<0>{
public:
	enum { val = 1 };//������ö��
};

template<typename T>
class Type{
public:
	static string name(){ return typeid(T).name(); }
};

template<typename T>
class Type<T *>{//ƫ�ػ�
public:
	static string name(){ string name = typeid(T).name(); return name + " pointer"; }
};

template<>
class Type<char>{
public:
	static const char * const name;
};
const char * const Type<char>::name = "_char";

int main()
{
	cout << Fact<5>::val << endl;//�ݹ���5!
	cout << Type<int>::name().c_str() << endl;
	cout << Type<double *>::name().c_str() << endl;
	cout << Type<char>::name << endl;
	return 0;
}