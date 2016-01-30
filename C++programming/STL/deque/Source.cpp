/*deque的个性：double-ended queue双端队列，其内部由多个数组组成,适合前后插入和删除频繁的时候
下标：operator[](i)不检查越界
at(i)越界抛出异常
增删：push_front(element),pop_front()
*/
#include <iostream>
#include <deque>
#include "print.h"
using namespace std;

int main()
{
	deque<char> dc;
	dc.push_back(97); dc.push_back('c');
	dc.push_front('s'); dc.push_front('d');
	dc.push_back('k'); dc.push_front('$');
	print(dc.begin(), dc.end());

	cout << "***************" << endl;
	dc[1] = 't';
	for (size_t i = 0; i < dc.size(); ++i)
		cout << dc[i] << " ";
	cout << endl;

	cout << "***************" << endl;
	dc.pop_back(); dc.pop_front();
	print(dc.begin(), dc.end());
	return 0;
}