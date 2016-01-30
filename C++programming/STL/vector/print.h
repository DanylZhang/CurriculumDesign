#ifndef PRINT_H
#define PRINT_H
#include <string>//添加该头文件是为了支持<<直接输出string
using namespace std;
template<typename T>
void print(T b, T e, const char c = ' ')
{
	while (b != e)
		cout << *(b++) << c;
	if (c != '\n')
		cout << endl;
}
#endif