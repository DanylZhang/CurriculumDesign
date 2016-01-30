#include <iostream>
#include <type_traits>
using namespace std;

template<typename T>
void foo(T t, true_type){
	cout << t <<"integral!"<< endl;
}

template<typename T>
void foo(T t, false_type){
	cout << t << "floating!" << endl;
}

template<typename T>
void bar(T t){
	foo(t, typename is_integral<T>::type());
}

int main()
{
	bar(23);
	bar(23.7);
	return 0;
}