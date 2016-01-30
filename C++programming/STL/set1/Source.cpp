/*set的个性：
元素就是key，而且不允许重复key，插入重复key新插入的会被丢弃
按key排序，默认用小于号
*/
#include <iostream>
#include <fstream>
#include <string>
#include <set>
#include "print.h"
using namespace std;

int main()
{
	set<string> ss;//set<char *> ss;只保存了字数组的首地址
	string s;//char s[100];
	ifstream fin("maillist");
	if (!fin){ return 1; }
	while (fin >> s)ss.insert(s);
	print(ss.begin(), ss.end(),'\n');
	return 0;
}