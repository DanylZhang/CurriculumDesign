/*remove();和remove_if();将不符合条件的元素往前移，这样就会覆盖掉目标元素，
 但该操作不会删除元素的物理存储空间,即不改变容器的size大小，然后返回指向后续垃圾数据的迭代器*/
//remove常配合erase使用，从而真正的将容器中的目标元素删除，从存储空间上删除
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main()
{
	vector<int> v;
	v.push_back(11);
	v.push_back(22);
	v.push_back(33);
	v.push_back(44);
	v.push_back(55);
	v.push_back(66);
	for (auto i : v)
		cout << i << endl;
	cout << v.size() << " " << v.capacity() << endl << endl;

	remove(v.begin(), v.end(), 22);
	for (auto i = v.begin(); i != v.end(); ++i)
		cout << *i << endl;
	cout << v.size() << " " << v.capacity() << endl << endl;

	v.erase(remove_if(v.begin(), v.end(), [](int a){return a % 2 == 1; }), v.end());
	for (auto i : v)	//C++11新增的for用法
		cout << i << endl;
	cout << v.size() << " " << v.capacity() << endl;
	return 0;
}