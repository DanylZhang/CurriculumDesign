//sort(a.begin(),a.end(),functor);	functor������ �������� �� lambda���ʽ
//stable_sort(a.begin(),a.end(),functor);	�ȶ�������
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
	bool operator<(const Person &p){ return this->age < p.age; }//sortĬ����С�ں�����
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
	Person c[3] = { Person("ܽ��", 18), Person("��ǿ", 20), Person("ޱޱ", 16) };

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

	stable_sort(v.begin(), v.end(), greater<string>());	//stable_sort()�ȶ�����	greater<string>()��������
	print(v.begin(), v.end(), '\n'); cout << endl;

	stable_sort(v.begin(), v.end(),
		[](string left, string right){	//lambda���ʽ
		return left.size() < right.size(); }
	);
	print(v.begin(), v.end(), '\n');
	return 0;
}