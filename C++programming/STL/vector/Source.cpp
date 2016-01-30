/*vector�ĸ��ԣ�����ʱ���ٷ���֮ǰ�Ĵ�С
capacity()ȡ��Ŀǰ�Ѿ����������
reserve(n)��ǰԼ������
�±꣺[].operator[](i)Խ�粻���
at(i)Խ���׳��쳣
vector�����ڲ����ɾ������֮������������ܻ�ʧЧ��
��Ϊ���ܻ����·����ڴ棬
����ÿ��ʹ�õ������������ȡ��it=vi.begin();
*/
#include <iostream>
#include <vector>
#include <exception>//�쳣����
#include <typeinfo>//typeid().name()
#include "print.h"
using namespace std;

int main()
{
	vector<double> vd,vv;
	for (int i = 0; i < 10; ++i){
		vd.push_back(i + 0.1);
		cout << &*vd.begin() << ":";
		cout << vd.size() << "/" << vd.capacity() << endl;
	}

	cout << "***************" << endl;
	vv.reserve(9);//����reserve()
	for (int i = 0; i < 10; ++i){
		vv.push_back(i + 0.5);
		cout << vv.size() << "/" << vv.capacity() << endl;
	}

	vd[3] = 123.45;
	for (size_t i = 0; i <vd.size(); ++i)
		cout << vd[i] << " ";
	cout << endl;

	vv.at(4) = 67.8;
	try{
		for (size_t i = 0; i <= vv.size(); ++i)
			cout << vv.at(i) << " ";
		cout << endl;
	}
	catch (exception &e){
		cout << "�쳣��" << e.what() << endl;
		cout << "���ͣ�" << typeid(e).name() << endl;
	}

	cout << "***************" << endl;
	int m = 3, n = 5;
	void print(const vector<vector<int>> &v);
	vector<vector<int>> vvi(m, vector<int>(n));//�����ά����
	print(vvi);

	cout << "***************" << endl;
	vvi.resize(m + 3);
	vvi[1].assign(9, 1);
	vvi[5].assign(4, 5);
	print(vvi);
	return 0;
}

//�����ά����
void print(const vector<vector<int>> &v)
{
	for (size_t i = 0; i < v.size(); ++i){
		for (size_t j = 0; j < v[i].size(); ++j)
			cout << v[i][j] << " ";
		cout << endl;
	}
}