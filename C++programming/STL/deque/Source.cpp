/*deque�ĸ��ԣ�double-ended queue˫�˶��У����ڲ��ɶ���������,�ʺ�ǰ������ɾ��Ƶ����ʱ��
�±꣺operator[](i)�����Խ��
at(i)Խ���׳��쳣
��ɾ��push_front(element),pop_front()
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