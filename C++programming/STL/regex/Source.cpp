#include <iostream>
#include <string>
#include <regex>
using namespace std;

void regex_test1(){
	const regex r("(\\d{2})/(\\d{2})/(\\d{4})");

	for (string s; getline(cin, s);){
		smatch m;	//smatch 模板类的特化，专门用来存储匹配分组
		const bool b = regex_match(s, m, r);	//match the whole string
		cout << b << endl;
		if (b){
			cout << m[1] << endl;
			cout << m[2] << endl;
			cout << m[3] << endl;
		}
		cout << endl;
	}
	return;
}

void regex_test2(){
	const regex r("c+d+e+");

	for (string s; getline(cin, s);){
		smatch m;
		const bool b = regex_search(s, m, r);	//search the more satisfying in part of string
		cout << b << endl;
		if (b){
			cout << m[0] << endl;
			cout << m[0].first - s.begin() << endl;	//m[0].first是匹配分组的左边界在字符串中的迭代器位置
			cout << m[0].second - s.begin() << endl;	//m[0].second是匹配分组的右边界的下一个字符在字符串中的迭代器位置，类似lower_bound
		}
		cout << endl;
	}
}

void regex_test3(){
	const regex r("(c+)(d+)(e+)");
	const string fmt("[$3]-[$2]-[$1]");
	for (string s; getline(cin, s);){
		cout << regex_replace(s, r, fmt) << endl;	//use the fmt to replace string
		cout << endl;
	}
}

void regex_test4(){
	const regex r("(c+)(d+)(e+)");
	for (string s; getline(cin, s);){
		for (sregex_iterator i(s.begin(), s.end(), r), end; i != end; ++i){
			cout << (*i)[2] << endl;
		}
	}
}

int main()
{
	cout << boolalpha;

	//regex_test1();
	//regex_test2();
	//regex_test3();
	regex_test4();
	return 0;
}