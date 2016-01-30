#include <iostream>
#include <typeinfo>
using namespace std;

template<typename T>//��ģ��
class Type{
public:
	static string name(){ return typeid(T).name(); }
};

template<typename T>//ƫ�ػ���ģ��
class Type<T *>{
public:
	static string name(){ string name = typeid(T).name(); return name + " pointer"; }
};

//����ģ������㣬���Բ���ָ�����ͣ����ݴ��Ĳ����Զ��Ʋ�����������
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
	cout << type().c_str() << endl;//Ĭ�ϲ�������

	cout << "***************" << endl;
	int a = 4;
	double b = 4.56;
	cout << "���ֵ��" << max(b, a)/*����ģ������Զ�ʶ���������*/ << endl;
	return 0;
}