#ifndef ARRSY_H
#define ARRSY_H
#include <typeinfo>

template<typename T = int, int size = 0>//在编译时这些类型和参数必须要确定
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