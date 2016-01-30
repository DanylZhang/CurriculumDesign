/*vector的个性：不够时就再分配之前的大小
capacity()取得目前已经分配的容量
reserve(n)提前约定容量
下标：[].operator[](i)越界不检查
at(i)越界抛出异常
vector容器在插入和删除操作之后其迭代器可能会失效，
因为可能会重新分配内存，
所以每次使用迭代器最好重新取得it=vi.begin();
*/
#include <iostream>
#include <vector>
#include <exception>//异常处理
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
	vv.reserve(9);//测试reserve()
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
		cout << "异常：" << e.what() << endl;
		cout << "类型：" << typeid(e).name() << endl;
	}

	cout << "***************" << endl;
	int m = 3, n = 5;
	void print(const vector<vector<int>> &v);
	vector<vector<int>> vvi(m, vector<int>(n));//定义二维数组
	print(vvi);

	cout << "***************" << endl;
	vvi.resize(m + 3);
	vvi[1].assign(9, 1);
	vvi[5].assign(4, 5);
	print(vvi);
	return 0;
}

//输出二维数组
void print(const vector<vector<int>> &v)
{
	for (size_t i = 0; i < v.size(); ++i){
		for (size_t j = 0; j < v[i].size(); ++j)
			cout << v[i][j] << " ";
		cout << endl;
	}
}