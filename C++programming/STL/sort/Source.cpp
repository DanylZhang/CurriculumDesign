//sort(a.begin(),a.end(),functor);	functor可以是 函数对象 或 lambda表达式
//stable_sort(a.begin(),a.end(),functor);	稳定的排序
#include <algorithm>
#include <functional>
#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Person{
private:
	string name;
	int age;
public:
	Person(){}
	Person(string name, int age) :name(name), age(age){}
	~Person(){}
	void show(){ cout << "Name:" << name.c_str() << "\tAge:" << age << endl; }
	bool operator<(const Person &p){ return this->age < p.age; }//sort默认以小于号排序
	friend ostream &operator<<(ostream &out, const Person &p){
		return out << p.name.c_str() << ":" << p.age;
	}
};

template<typename T>
void print(T b, T e, char ch = ' ')
{
	while (b != e)
		cout << *(b++) << ch;
	if (ch != '\n')
		cout << endl;
}

int main()
{
	int a[6] = { 5, 2, 6, 3, 7, 1 };
	double b[4] = { 6.6, 3.3, 5.5, 2.2 };
	Person c[3] = { Person("芙蓉", 18), Person("刘强", 20), Person("薇薇", 16) };

	sort(a, a + 6);
	print(a, a + 6);

	sort(&b[0], &b[4]);
	print(&b[0], &b[4]);

	sort(begin(c), end(c));
	print(begin(c), end(c));

	vector<string> v;
	v.push_back("cat");
	v.push_back("antelope");
	v.push_back("puppy");
	v.push_back("bear");
	v.push_back("dog");

	stable_sort(v.begin(), v.end(), greater<string>());	//stable_sort()稳定排序	greater<string>()函数对象
	print(v.begin(), v.end(), '\n'); cout << endl;

	stable_sort(v.begin(), v.end(),
		[](string left, string right){	//lambda表达式
		return left.size() < right.size(); }
	);
	print(v.begin(), v.end(), '\n');
	return 0;
}