#ifndef ARRSY_H
#define ARRSY_H
#include <typeinfo>

template<typename T = int, int size = 0>//�ڱ���ʱ��Щ���ͺͲ�������Ҫȷ��
class Array{
public:
	Array();
	~Array();
	int getLength();
	void showType();
private:
	T arr[size];
};

#endif //ARRAY_H