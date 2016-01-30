#include <iostream>
using namespace std;

//类模板，以结构体的形式来写
template<typename T, typename U>
struct Pair{
	T first;
	U second;
	Pair() :first(), second(){}
	Pair(const T &a, const U &b) :first(a), second(b){}
};

//重载输出运算符
template<typename T, typename U>
ostream &operator<<(ostream &out, const Pair<T, U> &p)
{
	return out << p.first << ':' << p.second;
}

//先用函数模板的特性进行类型自动推测，然后再用函数模板对类模板进行实例化
template<typename T, typename U>
Pair<T, U> Make_pair(const T f, const U s)
{
	Pair<T, U> object(f, s);
	return object;
}

int main()
{
	cout << Pair<const char*, int>("茉莉", 18) << endl;
	cout << Pair<int, double>(20, 345.65) << endl;

	cout << "********************" << endl;
	cout << Make_pair("莉莉", 20) << endl;
	return 0;
}