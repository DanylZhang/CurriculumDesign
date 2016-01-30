/*list的特性：
增删：push_front(element),pop_back(),remove(element),remove_if()//满足条件的删除
不支持下标[]
除重.unique()只去除相邻的相同元素，只保留一个
排序：.sort(compare_func=less)默认用小于号比较，从小到大进行排序，
	也可以用自定义的比函数进行比较//然后可以再用.unique()去重
倒置：reverse()颠倒链表中元素顺序
转移：splice(pos,list2)
	splice(pos,list2,pos2)
	splice(pos,list2,pos_begin,pos_end)
	//将list2中的元素转移到本链表的pos处，list2中被转移元素被删除
归并：merge(list2)//有序的转移，list2归并后为空
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

	li.insert(li.end(), 3, 5);//插入
	print(li.begin(), li.end());

	li.unique();//去重，默认用==比较，也可以使用自定义的比较函数
	print(li.begin(), li.end());

	li.sort();//排序
	print(li.begin(), li.end());
	li.unique();//再去重
	print(li.begin(), li.end());

	li.reverse();//倒置
	print(li.begin(), li.end());

	li.splice(li.begin(), lili);
	print(li.begin(), li.end());
	assert(lili.empty());//为true就调试通过

	li.remove(5);//删除指定元素
	print(li.begin(), li.end());

	li.sort(); li.unique();
	print(li.begin(), li.end());
	lili.push_back(0); lili.push_back(4); lili.push_back(7);
	lili.push_back(5); lili.push_back(10);
	lili.sort();
	print(lili.begin(), lili.end());
	li.merge(lili);//按顺序归并，但必须是排好序的，否则运行出错
	print(li.begin(), li.end());

	lili.assign(b, b + 6);
	print(lili.begin(), lili.end());

	lili.sort(greater<int>());
	print(lili.begin(), lili.end());

	lili.sort(compare);//使用自定义排序规则
	print(lili.begin(), lili.end());
	return 0;
}