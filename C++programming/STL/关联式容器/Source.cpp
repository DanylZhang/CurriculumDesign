/*关联式容器共性：都是用二叉查找树来实现的，都会自动根据关键字排序
set(K),multiset(K),map(K,V),multimap(K,V)
构造函数：可以用比较函数作为参数bool (*compare)(K a,K b)，默认用less<>
查找：find(key)返回一个迭代器，指向找到的第一个符合标准的元素，失败返回end()
统计：count(key)返回关键字等于key的个数
删除：erase(key)删除关键字等于key的所有元素
区间：lower_bound(key)取得关键字为key的第一个元素的位置
	upper_bound(key)取得关键字为key的最后一个元素之后的位置
	equal_range(key)一次取得关键字为key的元素的区间，返回一个pair
插入：insert(element)//插入时不用指定位置
*/
#include <iostream>
#include <set>//包含multiset
#include <string>
#include "print.h"
using namespace std;

struct Person{
	string name;
	int age;
public:
	Person(string name, int age) :name(name), age(age){}
};
bool operator<(const Person &a, const Person &b){
	return a.age < b.age || a.age == b.age&&a.name < b.name;
}
ostream &operator<<(ostream &out, const Person &a){
	return out << a.name << ":" << a.age;
}

int main()
{
	multiset<Person> msp;
	msp.insert(Person("郭一茹", 18));
	msp.insert(Person("姚连斌", 20));
	msp.insert(Person("赵元培", 26));
	msp.insert(Person("郭一茹", 18));
	msp.insert(Person("赵元培", 26));
	msp.insert(Person("王臣彬", 21));
	msp.insert(Person("郭一茹", 18));
	print(msp.begin(), msp.end());

	multiset<Person>::iterator it = msp.find(Person("王臣彬", 21));
	if (it == msp.end())
		cout << "没找到王臣彬" << endl;
	else
		cout << "发现目标：" << *it << endl;
	it = msp.find(Person("郭芙蓉", 18));
	if (it == msp.end())
		cout << "没找到郭芙蓉" << endl;
	else
		cout << "发现目标：" << *it << endl;

	//find(),count()
	it = msp.find(Person("郭一茹", 18));
	cout << msp.count(*it) << "个" << *it << endl;

	//lower_bound(), upper_bound()
	cout << "******************" << endl;
	multiset<Person>::iterator ib, ie;
	ib = msp.lower_bound(Person("赵元培", 26));
	ie = msp.upper_bound(Person("赵元培", 26));
	print(ib, ie);//由于内部自动排序，所以输出时只有两个赵元培，中间并无杂项

	cout << "******************" << endl;
	pair<multiset<Person>::iterator, multiset<Person>::iterator> p = msp.equal_range(Person("郭一茹", 18));
	print(p.first, p.second);

	cout << "******************" << endl;
	typedef multiset<Person>::iterator Iter;
	pair<Iter, Iter> q = msp.equal_range(Person("郭一茹", 18));
	print(q.first, q.second);

	//erase()
	cout << "******************" << endl;
	msp.erase(Person("郭一茹", 18));
	print(msp.begin(), msp.end());
	return 0;
}