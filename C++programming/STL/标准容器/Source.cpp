/*��׼��������ģ�壩�Ĺ��ԣ�vector,deque,list,set/multiset,map/multimap
���캯�����޲ι��캯�����������������乹�죨������������ʾ������λ�ã�
����������
��������أ�����begin(),end()������rbegin(),rend()
iterator,reverse_iterator,ֻ����������const_iterator,const_reverse_iterator
�Ե������Ĳ�����*,->,=,==,!=,++,--
���룺insert(pos,element)����pos�ǲ���λ�ã��Ǹ�������
ɾ����erase(pos),erase(pos_beg,pos_end)
�����clear()
��С��size(),max_size(),empty()
������swap(c2),swap(c1,c2)
�������=,>,<,>=,<=,==,!=
*/
#include <iostream>
#include <vector>
#include <algorithm>
#include "print.h"
#include "test.h"
using namespace std;

int main()
{
	int a[5] = { 33, 55, 22, 44, 11 };
	vector<int> vi(begin(a), end(a));

	cout << vi.size() << endl;

	vector<int>::iterator b = vi.begin();
	print(vi.begin(), vi.end());

	sort(vi.begin(), vi.end());
	print(vi.begin(), vi.end());
	print(vi.rbegin(), vi.rend());//�������

	vi.insert(++++vi.begin(), 66);
	print(vi.begin(), vi.end());
	vi.insert(vi.end(), 88);
	print(vi.begin(), vi.end());
	cout << vi.size() << "/" << vi.max_size() << endl;

	//vi.erase(++++vi.begin(),vi.end()----);�����ټ�
	vi.erase(++++vi.begin(), ----vi.end());
	print(vi.begin(), vi.end());

	vector<int> t;
	cout << "vector��ǰ������" << t.capacity() << endl;//vector�������е�

	test();
	return 0;
}