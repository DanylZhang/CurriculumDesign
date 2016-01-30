/*����ʽ�������ԣ������ö����������ʵ�ֵģ������Զ����ݹؼ�������
set(K),multiset(K),map(K,V),multimap(K,V)
���캯���������ñȽϺ�����Ϊ����bool (*compare)(K a,K b)��Ĭ����less<>
���ң�find(key)����һ����������ָ���ҵ��ĵ�һ�����ϱ�׼��Ԫ�أ�ʧ�ܷ���end()
ͳ�ƣ�count(key)���عؼ��ֵ���key�ĸ���
ɾ����erase(key)ɾ���ؼ��ֵ���key������Ԫ��
���䣺lower_bound(key)ȡ�ùؼ���Ϊkey�ĵ�һ��Ԫ�ص�λ��
	upper_bound(key)ȡ�ùؼ���Ϊkey�����һ��Ԫ��֮���λ��
	equal_range(key)һ��ȡ�ùؼ���Ϊkey��Ԫ�ص����䣬����һ��pair
���룺insert(element)//����ʱ����ָ��λ��
*/
#include <iostream>
#include <set>//����multiset
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
	msp.insert(Person("��һ��", 18));
	msp.insert(Person("Ҧ����", 20));
	msp.insert(Person("��Ԫ��", 26));
	msp.insert(Person("��һ��", 18));
	msp.insert(Person("��Ԫ��", 26));
	msp.insert(Person("������", 21));
	msp.insert(Person("��һ��", 18));
	print(msp.begin(), msp.end());

	multiset<Person>::iterator it = msp.find(Person("������", 21));
	if (it == msp.end())
		cout << "û�ҵ�������" << endl;
	else
		cout << "����Ŀ�꣺" << *it << endl;
	it = msp.find(Person("��ܽ��", 18));
	if (it == msp.end())
		cout << "û�ҵ���ܽ��" << endl;
	else
		cout << "����Ŀ�꣺" << *it << endl;

	//find(),count()
	it = msp.find(Person("��һ��", 18));
	cout << msp.count(*it) << "��" << *it << endl;

	//lower_bound(), upper_bound()
	cout << "******************" << endl;
	multiset<Person>::iterator ib, ie;
	ib = msp.lower_bound(Person("��Ԫ��", 26));
	ie = msp.upper_bound(Person("��Ԫ��", 26));
	print(ib, ie);//�����ڲ��Զ������������ʱֻ��������Ԫ�࣬�м䲢������

	cout << "******************" << endl;
	pair<multiset<Person>::iterator, multiset<Person>::iterator> p = msp.equal_range(Person("��һ��", 18));
	print(p.first, p.second);

	cout << "******************" << endl;
	typedef multiset<Person>::iterator Iter;
	pair<Iter, Iter> q = msp.equal_range(Person("��һ��", 18));
	print(q.first, q.second);

	//erase()
	cout << "******************" << endl;
	msp.erase(Person("��һ��", 18));
	print(msp.begin(), msp.end());
	return 0;
}