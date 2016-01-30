//copy(a.begin(),a.end(),b.begin());	copy�ڲ�ʵ�ֲ���������չb�Ĵ洢�ռ䣬���Կ��ܻ�Խ�磬Ӧʹ��back_inserter(b.begin())
//copy_if(a.begin(),a.end(),b.begin(),functor);	ͬ��
#include <iostream>
#include <vector>
#include <deque>
#include <algorithm>
#include <iterator>//����front_inserter()��back_inserter()
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
	return (n & 1);//����ɵ�n��1�������ʱ����true����n�Ķ�����ĩλΪ1ʱΪtrue����ôn������
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
	_copy(a, a + 5, back_inserter(dq));//_copy�ڲ�����push_back()ʵ�֣����Բ��ÿ���Խ������
	print(dq.begin(), dq.end());
	_copy(a, a + 5, front_inserter(dq));//_copy�ڲ�����push_front()ʵ�֣����Բ��ÿ���Խ������
	print(dq.begin(), dq.end());

	dq.clear();
	bool func(int);
	copy_if(a, a + 5, back_inserter(dq), func);
	print(dq.begin(), dq.end());
	return 0;
}