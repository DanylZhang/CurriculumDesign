#include <iostream>
using namespace std;

//��ģ�壬�Խṹ�����ʽ��д
template<typename T, typename U>
struct Pair{
	T first;
	U second;
	Pair() :first(), second(){}
	Pair(const T &a, const U &b) :first(a), second(b){}
};

//������������
template<typename T, typename U>
ostream &operator<<(ostream &out, const Pair<T, U> &p)
{
	return out << p.first << ':' << p.second;
}

//���ú���ģ������Խ��������Զ��Ʋ⣬Ȼ�����ú���ģ�����ģ�����ʵ����
template<typename T, typename U>
Pair<T, U> Make_pair(const T f, const U s)
{
	Pair<T, U> object(f, s);
	return object;
}

int main()
{
	cout << Pair<const char*, int>("����", 18) << endl;
	cout << Pair<int, double>(20, 345.65) << endl;

	cout << "********************" << endl;
	cout << Make_pair("����", 20) << endl;
	return 0;
}