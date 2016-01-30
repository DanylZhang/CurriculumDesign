/*--------------------------------------------------------------
-------------------用十字链表实现稀疏矩阵的加法--------------------
------------------------编译环境：VS 2013------------------------
---------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//用于取消VS 2013对printf、scanf等函数的警告
#include <stdio.h>
#include <stdlib.h>

#define MAXSIZE 50
typedef int ElemType;
typedef struct matrixnode//结构体和共用体的定义
{
	int i, j;
	struct matrixnode *right, *down;
	union
	{
		ElemType value;
		struct matrixnode *next;
	}tag;
}manode;

manode *creatcroslist();					//建立稀疏矩阵的函数，返回十字链表头指针
void insert(int i, int j, int value, manode *cp[]);//插入结点函数
manode *add(manode *A, manode *B);		//矩阵相加
void print(manode *M);					//输出十字链表的函数

void main()
{
	manode *A, *B, *C;

	printf("正在获取稀疏矩阵A......\n");
	A = creatcroslist();
	system("cls");
	printf("正在获取稀疏矩阵B......\n");
	B = creatcroslist();
	system("cls");

	printf("稀疏矩阵A：\n");
	print(A);
	printf("稀疏矩阵B：\n");
	print(B);

	C = add(A, B);
	puts("稀疏矩阵A与稀疏矩阵B的和为：");
	print(C);
}

manode *creatcroslist()
{
	manode *p, *q, *head, *cp[MAXSIZE];
	int i, j, k, m, n, t, s;
	ElemType value;

	printf("请输入行、列、非零元素个数（中间用逗号隔开）：");
	scanf("%d,%d,%d", &m, &n, &t);

	if (m > n)
		s = m;
	else
		s = n;
	head = (manode *)malloc(sizeof(manode));//建立十字链表头结点
	head->i = m;
	head->j = n;

	cp[0] = head;//cp[]是临时指针数组，分别指向头结点和行、列表头结点
	for (i = 1; i <= s; i++)//建立头结点循环链表
	{
		p = (manode *)malloc(sizeof(manode));
		p->i = 0;
		p->j = 0;
		p->right = p;
		p->down = p;
		cp[i] = p;
		cp[i - 1]->tag.next = p;
	}
	cp[s]->tag.next = head;

	for (k = 1; k <= t; k++)
	{
		printf("第%d个非零元素的行号、列号、元素值（中间用逗号隔开）:", k);
		scanf("%d,%d,%d", &i, &j, &value);
		p = (manode *)malloc(sizeof(manode));
		p->i = i;
		p->j = j;
		p->tag.value = value;
		q = cp[i];
		while ((q->right != cp[i]) && (q->right->j < j))
			q = q->right;
		p->right = q->right;
		q->right = p;
		q = cp[j];
		while ((q->down != cp[j]) && (q->down->i < i))
			q = q->down;
		p->down = q->down;
		q->down = p;
	}
	return head;
}

void insert(int i, int j, int value, manode *cp[])
{
	manode *p, *q;
	p = (manode *)malloc(sizeof(manode));
	p->i = i;
	p->j = j;
	p->tag.value = value;

	//以下是经*p结点插入第i行链表中
	q = cp[i];
	while ((q->right != cp[i]) && (q->right->j < j))
		q = q->right;//在第i行中找第一个列号大于j的结点*(q->right)
	//找不到时，*q是该行表上的尾结点
	p->right = q->right;
	q->right = p;//*p插入在*q之后

	//以下是将结点插入第j列链表中
	q = cp[j];//取第j列表头结点
	while ((q->down != cp[j]) && (q->down->i < i))
		q = q->down;//在第j行中找第一个列号大于i的结点*(q->down)
	//找不到时，*q是该行表上的尾结点
	p->down = q->down;
	q->down = p;//*p插入在*q之后
}

manode *add(manode *A, manode *B)
{
	manode *p, *q, *u, *v, *r, *cp[MAXSIZE], *C;//p,q控制十字链A的行列,u,v控制十字链B的行列
	int s, i;
	if (A->i != B->i || A->j != B->j)
	{
		puts("稀疏矩阵A与稀疏矩阵B不能相加！");
		exit(0);
	}

	//建立C的表头环链
	C = (manode *)malloc(sizeof(manode));
	C->i = A->i; C->j = A->j;
	if (C->i > C->j)s = C->i; else s = C->j;
	cp[0] = C;
	for (i = 1; i <= s; i++)
	{
		r = (manode *)malloc(sizeof(manode));
		r->i = 0; r->j = 0;
		r->right = r; r->down = r;
		cp[i] = r;
		cp[i - 1]->tag.next = r;
	}
	cp[s]->tag.next = C;

	//矩阵相加
	p = A->tag.next; u = B->tag.next;
	while (p != A && u != B)
	{
		q = p->right;
		v = u->right;
		if (q == p && v != u)//矩阵A中第p行为空，矩阵B的第u行不为空
		while (v != u)//将B的行的都复制到和矩阵中
		{
			insert(v->i, v->j, v->tag.value, cp);
			v = v->right;
		}
		else if (v == u && q != p)//矩阵A中第p行不为空，矩阵B的第u行为空
		while (q != p)
		{
			insert(q->i, q->j, q->tag.value, cp);
			q = q->right;
		}
		else if (q != p && v != u)//矩阵B的第u行和矩阵A的第p行都不为空
		{
			while (q != p && v != u)
			{
				if (q->j<v->j)//如果A中有元素的列数小于B的，将A中的所有小于B的值都插到C中
				{
					insert(q->i, q->j, q->tag.value, cp);
					q = q->right;
				}
				else if (q->j>v->j)//如果B中有元素的列数小于A的，将A中的所有小于B的值都插到C中
				{
					insert(v->i, v->j, v->tag.value, cp);
					v = v->right;
				}
				else//A、B当前是在同一个位置，判断加的和是否为零，不为零才做加法运算
				{
					if (q->tag.value + v->tag.value != 0)
						insert(q->i, q->j, (q->tag.value + v->tag.value), cp);
					q = q->right; v = v->right;
				}
			}
			if (q == p && v != u)//如果B未处理完，将B中未处理的值都插入到和矩阵中
			while (v != u)
			{
				insert(v->i, v->j, v->tag.value, cp);
				v = v->right;
			}
			else if (v == u && q != p)//如果A未处理完，将A中未处理的值都插入到和矩阵中
			while (q != p)
			{
				insert(q->i, q->j, q->tag.value, cp);
				q = q->right;
			}
		}
		p = p->tag.next;
		u = u->tag.next;//A，B都指向下一行
	}
	return C;
}

void print(manode *M)
{
	manode *p, *q, *r;//p是指向行，q是指向列，r是指向某一节点的临时指针
	int k, t, col, row;
	col = M->j;//矩阵M的列数
	p = M->tag.next;//p指向第一个结点，不是头结点
	row = 1;
	while (row <= M->i)//判断行是否循环完
	{
		q = p->right;//p指向这一行的一个值
		r = p;//r指向这一行的头结点
		while (q != p)//判断列是否循环完
		{
			for (k = 1; k < (q->j - r->j); k++)//输出同一行上两非零数据间的零
				printf("   0");
			printf("%4d", q->tag.value);//输出那个非零值
			q = q->right;//q指向这一行的下一个元素
			r = r->right;//r指向q前面的一个非零元素
		}
		k = r->j;//k的值是某一行的最后一个非零元的列数
		for (t = k; t < col; t++)//输出一行上最后一个非零元后面的零
			printf("   0");
		printf("\n\n");
		p = p->tag.next;//p指向下一行
		row++;
	}
}