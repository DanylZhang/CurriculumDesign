/*list�����ԣ�
��ɾ��push_front(element),pop_back(),remove(element),remove_if()//����������ɾ��
��֧���±�[]
����.unique()ֻȥ�����ڵ���ͬԪ�أ�ֻ����һ��
����.sort(compare_func=less)Ĭ����С�ںűȽϣ���С�����������
	Ҳ�������Զ���ıȺ������бȽ�//Ȼ���������.unique()ȥ��
���ã�reverse()�ߵ�������Ԫ��˳��
ת�ƣ�splice(pos,list2)
	splice(pos,list2,pos2)
	splice(pos,list2,pos_begin,pos_end)
	//��list2�е�Ԫ��ת�Ƶ��������pos����list2�б�ת��Ԫ�ر�ɾ��
�鲢��merge(list2)//�����ת�ƣ�list2�鲢��Ϊ��
*/
#include <iostream>
#include <cassert>
#include <list>
#include <functional>//greater<>()
#include "print.h"
using namespace std;

bool compare(int x, int y)
{
	return (x % 3) < (y % 3);
}

int main()
{
	int a[10] = { 3, 8, 8, 8, 5, 5, 1, 8, 8, 7 }, b[6] = { 9, 3, 5, 2, 7, 6 };
	list<int> li(a, a + 10), lili(b, b + 6);
	print(li.begin(), li.end());

	li.insert(li.end(), 3, 5);//����
	print(li.begin(), li.end());

	li.unique();//ȥ�أ�Ĭ����==�Ƚϣ�Ҳ����ʹ���Զ���ıȽϺ���
	print(li.begin(), li.end());

	li.sort();//����
	print(li.begin(), li.end());
	li.unique();//��ȥ��
	print(li.begin(), li.end());

	li.reverse();//����
	print(li.begin(), li.end());

	li.splice(li.begin(), lili);
	print(li.begin(), li.end());
	assert(lili.empty());//Ϊtrue�͵���ͨ��

	li.remove(5);//ɾ��ָ��Ԫ��
	print(li.begin(), li.end());

	li.sort(); li.unique();
	print(li.begin(), li.end());
	lili.push_back(0); lili.push_back(4); lili.push_back(7);
	lili.push_back(5); lili.push_back(10);
	lili.sort();
	print(lili.begin(), lili.end());
	li.merge(lili);//��˳��鲢�����������ź���ģ��������г���
	print(li.begin(), li.end());

	lili.assign(b, b + 6);
	print(lili.begin(), lili.end());

	lili.sort(greater<int>());
	print(lili.begin(), lili.end());

	lili.sort(compare);//ʹ���Զ����������
	print(lili.begin(), lili.end());
	return 0;
}