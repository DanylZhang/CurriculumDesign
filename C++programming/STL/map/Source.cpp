/*map的个性：不允许key重复
元素是(key,value)对
支持以key下标访问对应的value的引用
如果不存在则新增一个元素，以这个为key，value则零初始化
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
	mis.insert(pair<int, string>(8, "王龙"));//此pair为类模板，必须人为指定参数类型
	mis.insert(make_pair(4, "李霖"));//此make_pair为函数模板，可以自动识别参数类型
	mis.insert(map<int, string>::value_type(5, "钟玉龙"));//就像迭代器包含在容器内部一样，容器还有一个内部类型，元素类型

	//可以通过下标[key]来方便的插入新元素或者是更新已有元素，此法秒杀以上三种
	mis[3] = "何军军";
	mis[6] = "蒲嗣良";

	mis.insert(make_pair(5, "钟玉龙"));//
	mis.insert(make_pair(5, "郭芙蓉"));//同key已存在，未插进去
	print(mis.begin(), mis.end());

	mis[6] = "蒲松龄";//用下标[key]轻松更新value
	print(mis.begin(), mis.end());

	cout << "************************************" << endl;
	map<int, Person> mp;
	mp.insert(make_pair(1, Person("柳岩", 24)));
	mp.insert(make_pair(4, Person("权志龙", 29)));
	mp.insert(make_pair(2, Person("李小龙", 35)));
	mp.insert(make_pair(3, Person("刘亦菲", 26)));
	mp.insert(make_pair(1, Person("匿名", 24)));
	print(mp.begin(), mp.end());
	mp[5] = Person("曾小贤", 27);//
	mp[1] = Person("柳岩", 22);//以上两句会默认零初始化，调用Person的默认构造函数，然后再赋值
	print(mp.begin(), mp.end());
	return 0;
}