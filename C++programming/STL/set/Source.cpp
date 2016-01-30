/*set的个性：
元素就是key，而且不允许重复key，插入重复key新插入的会被丢弃
按key排序，默认用小于号
functional函数对象，包含greater<>
*/
#include "Student.h"
#include <set>//因为用到了set容器
#include <functional>//因为用到了greater<int>

struct stuFunctor{//自定义函数对象
	bool operator() (const Student &stu1, const Student &stu2)
	{
		return (stu1.ID < stu2.ID);//小于号是less<>,升序
	}
};

int main()
{
	set<int, greater<int>> setA;//默认是set<T,less<T>>升序
	setA.insert(11);
	setA.insert(22);
	setA.insert(33);
	setA.insert(22);
	setA.insert(44);
	setA.insert(55);
	setA.insert(22);
	setA.insert(3);
	for (set<int,greater<int>>::iterator it = setA.begin(); it != setA.end(); ++it)
		cout << *it << " ";

	cout << endl << "*******************" << endl;
	setA.erase(22);
	for (set<int, greater<int>>::iterator it = setA.begin(); it != setA.end(); ++it)
		cout << *it << " ";

	set<int>::iterator itF = setA.find(11);//find()
	int nFind = *itF;

	int iCount = setA.count(3);//count()

	//lower_bound(),upper_bound()
	set<int>::iterator itLower = setA.lower_bound(3);
	set<int>::iterator itUpper = setA.upper_bound(11);

	//pair
	pair<set<int>::iterator, set<int>::iterator> itPair = setA.equal_range(33);
	set<int>::iterator itFirst = itPair.first;
	set<int>::iterator itSecond = itPair.second;

	cout << endl << "*******************" << endl;
	set<Student, stuFunctor> stuA;
	stuA.insert(Student(3, "小明"));
	stuA.insert(Student(5, "小刚"));
	stuA.insert(Student(4, "小草"));
	stuA.insert(Student(1, "小花"));
	stuA.insert(Student(2, "小晶"));
	for (set<Student, stuFunctor>::iterator it = stuA.begin(); it != stuA.end(); ++it)
		cout << "ID: " <<it->ID<<"\t姓名: "<<it->Name<< endl;
	return 0;
}