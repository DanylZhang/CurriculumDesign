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
		this_thread::sleep_for(chrono::milliseconds(500));//�߳�˯�ߣ�ģ��������ʻ
	}
};

int main()
{
	//������
	ifstream fin("data.txt");
	if (!fin)
	{
		cout << "�ļ���ȡʧ�ܣ�";
		return 0;
	}
	Comparer comparer;
	vector<Comparer> vectComparer;
	while (fin >> comparer) {
		vectComparer.push_back(comparer);
	}
	fin.close();

	//�����̶߳���
	thread t1 = thread(Run,vectComparer);
	//�����߳�
	t1.join();

	getchar();
	return 0;
}