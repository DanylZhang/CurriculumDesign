#ifndef PRINT_H
#define PRINT_H
#include <string>//���Ӹ�ͷ�ļ���Ϊ��֧��<<ֱ�����string
using namespace std;
template<typename T>
void print(T b, T e,const char c=' ')
{
	while (b != e)
		cout << *(b++) << c;
	if(c!='\n')
		cout << endl;
}
#endif