#ifndef TEST_H
#define TEST_H
#include <iostream>
#include <vector>
using namespace std;
void test()
{
	vector<int> vectA;
	vectA.push_back(1);
	vectA.push_back(3);
	vectA.push_back(5);
	vectA.push_back(7);
	vectA.push_back(9);

	vectA.pop_back();
	vectA[2] = 155;
	vectA.at(3) = 177;

	int nFront = vectA.front();
	vectA.front() = 111;
	int nBack = vectA.back();
	vectA.back() = 199;

	cout << endl << "***************" << endl;
	for (size_t i = 0; i < vectA.size(); i++)
		cout << vectA[i] << " ";

	cout << endl << "***************" << endl;
	//���������
	vector<int>::iterator it = vectA.begin();
	++it;//ǰ�ӼӱȺ�Ӽ�Ч�ʸߣ���Ϊǰ�Ӽӷ��ص������ã���Ӽӷ��ص���ֵ
	cout << *it << endl;
	--it;
	cout << *it << endl;
	it = it + 2;
	cout << *it << endl;
	it = it - 1;
	cout << *it << endl;

	cout << "�����������";
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	//���������
	cout << endl << "�����������";
	vector<int>::reverse_iterator r_it = vectA.rbegin();
	for (r_it; r_it != vectA.rend(); ++r_it)
		cout << *r_it << " ";

	//ֻ��������
	cout << endl << "ֻ����������";
	vector<int>::const_iterator c_it = vectA.begin();
	for (c_it; c_it != vectA.end(); ++c_it)
		cout << *c_it << " ";

	cout << endl;
	int iArray[] = { 0, 1, 2, 3, 4 };
	vector<int> vectB(iArray, iArray + 5);
	for (vector<int>::iterator b_it = vectB.begin(); b_it != vectB.end(); ++b_it)
		cout << *b_it << " ";

	vector<int> vectC(vectB.begin(), vectB.end());
	for (vector<int>::reverse_iterator rC_it = vectC.rbegin(); rC_it != vectC.rend(); ++rC_it)
		cout << *rC_it << " ";

	cout << endl;
	vector<int> vectD(3, 9);//ʵ����һ��vector������������3��9
	for (size_t i = 0; i < vectD.size(); ++i)
		cout << vectD[i] << " ";

	//����
	cout << endl;
	vectA.insert(vectA.begin() + 2, 4);
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	cout << endl;
	vectA.insert(vectA.begin() + 2, 4, 5);
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	cout << endl;
	vectA.insert(vectA.begin() + 2, vectB.begin(), vectB.end());
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	//ɾ��
	cout << endl << "ɾ��ǰvectA:";
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	vectA.erase(vectA.begin() + 4);
	cout << endl << "ɾ����vectA:";
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	vectA.erase(vectA.begin() + 2, vectA.begin() + 5);
	cout << endl << "ɾ����vectA:";
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	//ɾ����ȵ�Ԫ��
	int iArray2[] = { 0, 1, 2, 3, 4, 3, 5, 3, 3, 6, 7, 8, 3, 9, 3 };
	vectA.assign(iArray2, iArray2 + 15);
	cout << endl << endl << "ɾ��ǰvectA:";
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";
	for (it = vectA.begin(); it != vectA.end(); ++it)
	{
		if (*it == 3)
		{
			it = vectA.erase(it);//��ɾ�������һ��Ԫ��λ�÷��ظ�������
			--it;
		}
	}
	cout << endl << "ɾ����vectA:";
	for (it = vectA.begin(); it != vectA.end(); ++it)
		cout << *it << " ";

	vectA.clear();//���
	return;
}
#endif