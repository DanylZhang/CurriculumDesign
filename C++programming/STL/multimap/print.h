#ifndef PRINT_H
#define PRINT_H
#include <string>
using namespace std;

template<typename T>
void print(T b, T e, const char c = ' ')
{
	while (b != e)
		cout << *(b++) << c;
	if (c != '\n')
		cout << endl;
}

template<typename K,typename V>
ostream &operator<<(ostream &out, const pair<K, V> &p){
	return out << p.first << ":" << p.second;
}
#endif //PRINT_H