#include <iostream>
#include <fstream>
#include <vector>
#include <thread>
#include "Comparer.h"
using namespace std;

void Run(vector<Comparer> &vectComparer)
{
	for each(auto comparer in vectComparer)
	{
		comparer.ShouldAlarm();
		this_thread::sleep_for(chrono::milliseconds(500));//线程睡眠，模拟汽车行驶
	}
};

int main()
{
	//读数据
	ifstream fin("data.txt");
	if (!fin)
	{
		cout << "文件读取失败！";
		return 0;
	}
	Comparer comparer;
	vector<Comparer> vectComparer;
	while (fin >> comparer) {
		vectComparer.push_back(comparer);
	}
	fin.close();

	//创建线程对象
	thread t1 = thread(Run,vectComparer);
	//开启线程
	t1.join();

	getchar();
	return 0;
}