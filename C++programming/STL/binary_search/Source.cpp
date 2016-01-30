//���ж��ֲ��ҵ�ǰ����Ŀ�������Ѿ���ǰ�ź���
/*lower_bound(pos_beg,pos_end,element);	��Ȼʹ�ö��ֲ���
	1.����ҵ��˷������������
	2.����ҵ��˲��������в�ֹһ��Ŀ��Ԫ�أ���ô���ص�һ���ĵ�������
	3.���û�ҵ����򷵻��ܲ���Ŀ��Ԫ�صķ�Χ���ұ߽�(��ʱ�᷵�� pos_begin �� pos_end)��*/
/*binary_search(pos_beg,pos_end,element);
	�ڷ�Χ����element������ҵ��˷���true�����򷵻�false*/
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int main()
{
	vector<int> v;
	v.push_back(11);
	v.push_back(22);
	v.push_back(33);
	v.push_back(44);
	v.push_back(55);
	v.push_back(33);

	sort(v.begin(), v.end());

	auto i1 = lower_bound(v.begin(), v.end(), 33);
	cout << *i1 << " " << *(++i1) << endl;

	auto i2 = lower_bound(v.begin(), v.end(), 50);
	cout << *i2 << endl;

	auto i3 = lower_bound(v.begin(), v.end(), 10);
	cout << *i3 << endl;

	auto i4 = lower_bound(v.begin(), v.end(), 90);
	if (i4 == v.end())
		cout << "end" << endl;

	if (binary_search(v.begin(), v.end(), 5))
		cout << "�ҵ���" << endl;
	else
		cout << "û�ҵ�" << endl;
	return 0;
}