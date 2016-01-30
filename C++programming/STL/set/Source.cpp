/*set�ĸ��ԣ�
Ԫ�ؾ���key�����Ҳ������ظ�key�������ظ�key�²���Ļᱻ����
��key����Ĭ����С�ں�
functional�������󣬰���greater<>
*/
#include "Student.h"
#include <set>//��Ϊ�õ���set����
#include <functional>//��Ϊ�õ���greater<int>

struct stuFunctor{//�Զ��庯������
	bool operator() (const Student &stu1, const Student &stu2)
	{
		return (stu1.ID < stu2.ID);//С�ں���less<>,����
	}
};

int main()
{
	set<int, greater<int>> setA;//Ĭ����set<T,less<T>>����
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
	stuA.insert(Student(3, "С��"));
	stuA.insert(Student(5, "С��"));
	stuA.insert(Student(4, "С��"));
	stuA.insert(Student(1, "С��"));
	stuA.insert(Student(2, "С��"));
	for (set<Student, stuFunctor>::iterator it = stuA.begin(); it != stuA.end(); ++it)
		cout << "ID: " <<it->ID<<"\t����: "<<it->Name<< endl;
	return 0;
}