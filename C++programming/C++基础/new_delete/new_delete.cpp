#include <iostream>
using namespace std;

int main()
{
	int *p1 = new int;			//δ��ʼ������������
	cout << *p1 << endl;

	int *p2 = new int();		//���ʼ��
	cout << *p2 << endl;

	int *p3 = new int(1729);	//1729��ʼ��
	cout << *p3 << endl;
	cout << *(p3 + 1) << endl;	//�������ݣ��൱������Խ��

	//int *p4 = new int[];		//δ��ʼ�����������ݣ����ұ�����
	//cout << *p4 << endl;
	//cout << *(p4 + 1) << endl;	//�������ݣ��൱������Խ��

	int *p5 = new int[5];		//δ��ʼ������������
	cout << *p5 << endl;

	int *p6 = new int[5]();	//���ʼ��
	cout << *p6 << endl;

	int *p7 = new int[5]({ 1, 2 });//{..}���ֳ�ʼ��������Ϊ��
	cout << *p7 << endl;			// 1
	cout << *(p7 + 1) << endl;		// 2
	cout << *(p7 + 2) << endl;		// 0
	delete[] p7;
	//delete[] p7;	//delete�����ظ�����
	return 0;
}