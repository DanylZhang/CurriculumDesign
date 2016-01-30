//copy(a.begin(),a.end(),b.begin());	copy内部实现并不负责拓展b的存储空间，所以可能会越界，应使用back_inserter(b.begin())
//copy_if(a.begin(),a.end(),b.begin(),functor);	同上
#include <iostream>
#include <vector>
#include <deque>
#include <algorithm>
#include <iterator>//包含front_inserter()和back_inserter()
#include "print.h"
using namespace std;

template<typename Iter, typename Pos>
void _copy(Iter ib, Iter ie, Pos p){
	while (ib != ie)
		*(p++) = *(ib++);
}
template<typename Iter, typename Pos>
void _copy_backward(Iter ib, Iter ie, Pos p){
	while (ib != ie)
		*(--p) = *(--ie);
}

bool func(int n){
	return (n & 1);//解读成当n跟1相与非零时返回true，当n的二进制末位为1时为true，那么n是奇数
}

int main()
{
	int a[5] = { 3, 4, 2, 5, 1 };
	int b[8] = { 0 };
	vector<int> vi(a, a + 5);

	sort(vi.begin(), vi.end());
	print(vi.begin(), vi.end());

	print(a, a + 5, ',');
	copy(vi.begin(), vi.end(), a);
	print(a, a + 5, ',');

	print(b, b + 8);
	_copy(a, a + 5, b);
	print(b, b + 8);

	_copy(b, b + 5, b + 3);
	print(b, b + 8);
	_copy_backward(b, b + 5, b + 8);
	print(b, b + 8);

	deque<int> dq;
	_copy(a, a + 5, back_inserter(dq));//_copy内部换用push_back()实现，所以不用考虑越界问题
	print(dq.begin(), dq.end());
	_copy(a, a + 5, front_inserter(dq));//_copy内部换用push_front()实现，所以不用考虑越界问题
	print(dq.begin(), dq.end());

	dq.clear();
	bool func(int);
	copy_if(a, a + 5, back_inserter(dq), func);
	print(dq.begin(), dq.end());
	return 0;
}