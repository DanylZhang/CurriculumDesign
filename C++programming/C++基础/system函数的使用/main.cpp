#include <iostream>
#include <string>//添加了该头文件可以支持<<直接输出string
using namespace std;

int main()
{
	string str1, str2, str3;
	cout << "please input str1:";
	cin >> str1;
	cout << "please input str2:";
	cin >> str2;
	cout << "please input str3:";
	cin >> str3;
	cout << str1 << str2 << str3;
	system("cls");
	system("notepad");
	system("explorer");
}