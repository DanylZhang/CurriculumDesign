/*remove();��remove_if();��������������Ԫ����ǰ�ƣ������ͻḲ�ǵ�Ŀ��Ԫ�أ�
 ���ò�������ɾ��Ԫ�ص�����洢�ռ�,�����ı�������size��С��Ȼ�󷵻�ָ������������ݵĵ�����*/
//remove�����eraseʹ�ã��Ӷ������Ľ������е�Ŀ��Ԫ��ɾ�����Ӵ洢�ռ���ɾ��
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main()
{
	vector<int> v;
	v.push_back(11);
	v.push_back(22);
	v.push_back(33);
	v.push_back(44);
	v.push_back(55);
	v.push_back(66);
	for (auto i : v)
		cout << i << endl;
	cout << v.size() << " " << v.capacity() << endl << endl;

	remove(v.begin(), v.end(), 22);
	for (auto i = v.begin(); i != v.end(); ++i)
		cout << *i << endl;
	cout << v.size() << " " << v.capacity() << endl << endl;

	v.erase(remove_if(v.begin(), v.end(), [](int a){return a % 2 == 1; }), v.end());
	for (auto i : v)	//C++11������for�÷�
		cout << i << endl;
	cout << v.size() << " " << v.capacity() << endl;
	return 0;
}