/*
iterator find(pos_beg,pos_end,data)
iterator find_if(pos_beg,pos_end,func)	bool func(element)
int count(...)	int count_if(...)
*/
#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
using namespace std;

bool init_upper(const string &s){
	return isupper(s[0]);
}
bool has_o(const string &s){
	return s.find_first_of("oO") != string::npos;
	//find_first_of(str1)找共有的字符，返回所在位置
	//npos=-1，代表着不属于源字符串的位置
	//不等于npos则说明找到了
}

int main()
{
	string a[7] = { "abc", "good", "Day", "look", "God", "Ok", "bye" };
	string *p = find(a, a + 7, "look");
	cout << (p == (a + 7) ? "没找到" : "找到了") << "look" << endl;
	p = find(a, a + 7, "book");
	cout << (p == (a + 7) ? "没找到" : "找到了") << "book" << endl;
	p = find_if(a, a + 7, init_upper);
	cout << (p == (a + 7) ? "没找到大写字母开头的字符串" : "找到了") << *p << endl;
	
	cout << "找到了" << count(a, a + 7, "God") << "个" << "God" << endl;
	cout << "大写字母开头的字符串有" << count_if(a, a + 7, init_upper) << "个" << endl;
	cout << count_if(a, a + 7, has_o) << endl;
	return 0;
}