/*map�ĸ��ԣ�������key�ظ�
Ԫ����(key,value)��
֧����key�±���ʶ�Ӧ��value������
���������������һ��Ԫ�أ������Ϊkey��value�����ʼ��
*/
#include <iostream>
#include <string>
#include <map>
#include "print.h"
using namespace std;

struct Person{
	string name;
	int age;
public:
	Person(){}
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
	map<int, string> mis;
	mis.insert(pair<int, string>(8, "����"));//��pairΪ��ģ�壬������Ϊָ����������
	mis.insert(make_pair(4, "����"));//��make_pairΪ����ģ�壬�����Զ�ʶ���������
	mis.insert(map<int, string>::value_type(5, "������"));//��������������������ڲ�һ������������һ���ڲ����ͣ�Ԫ������

	//����ͨ���±�[key]������Ĳ�����Ԫ�ػ����Ǹ�������Ԫ�أ��˷���ɱ��������
	mis[3] = "�ξ���";
	mis[6] = "������";

	mis.insert(make_pair(5, "������"));//
	mis.insert(make_pair(5, "��ܽ��"));//ͬkey�Ѵ��ڣ�δ���ȥ
	print(mis.begin(), mis.end());

	mis[6] = "������";//���±�[key]���ɸ���value
	print(mis.begin(), mis.end());

	cout << "************************************" << endl;
	map<int, Person> mp;
	mp.insert(make_pair(1, Person("����", 24)));
	mp.insert(make_pair(4, Person("Ȩ־��", 29)));
	mp.insert(make_pair(2, Person("��С��", 35)));
	mp.insert(make_pair(3, Person("�����", 26)));
	mp.insert(make_pair(1, Person("����", 24)));
	print(mp.begin(), mp.end());
	mp[5] = Person("��С��", 27);//
	mp[1] = Person("����", 22);//���������Ĭ�����ʼ��������Person��Ĭ�Ϲ��캯����Ȼ���ٸ�ֵ
	print(mp.begin(), mp.end());
	return 0;
}