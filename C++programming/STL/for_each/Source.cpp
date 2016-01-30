/*for_each:
前两个参数是范围，后一个参数是函数或函数对象
自己实现了foreach，并写了add类用作函数对象，重载了operator()
*/
#include <iostream>
#include <algorithm>
#include <string>
using namespace std;

void add10(int &element){
	element += 10;
}
string print(int element){
	cout << element << ' ';
	return "芙蓉";
}

class add{
	int delta;
public:
	add(int d) :delta(d){}
	void operator()(int &element){
		element += delta;
	}
};

template<typename Iter, typename Func>
void foreach(Iter ib, Iter ie, Func f){
	while (ib != ie)
		f(*(ib++));
}
int main()
{
	int a[5] = { 11, 22, 33, 44, 55 };
	for_each(a, a + 5, add10);
	for_each(a, a + 5, print); cout << endl;
	foreach(a, a + 5, add(5));
	foreach(a, a + 5, print); cout << endl;
	foreach(a, a + 5, add(1));
	foreach(a, a + 5, print); cout << endl;
	return 0;
}