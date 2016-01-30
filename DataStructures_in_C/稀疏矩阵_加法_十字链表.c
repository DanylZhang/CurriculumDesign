/*--------------------------------------------------------------
-------------------��ʮ������ʵ��ϡ�����ļӷ�--------------------
------------------------���뻷����VS 2013------------------------
---------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//����ȡ��VS 2013��printf��scanf�Ⱥ����ľ���
#include <stdio.h>
#include <stdlib.h>

#define MAXSIZE 50
typedef int ElemType;
typedef struct matrixnode//�ṹ��͹�����Ķ���
{
	int i, j;
	struct matrixnode *right, *down;
	union
	{
		ElemType value;
		struct matrixnode *next;
	}tag;
}manode;

manode *creatcroslist();					//����ϡ�����ĺ���������ʮ������ͷָ��
void insert(int i, int j, int value, manode *cp[]);//�����㺯��
manode *add(manode *A, manode *B);		//�������
void print(manode *M);					//���ʮ������ĺ���

void main()
{
	manode *A, *B, *C;

	printf("���ڻ�ȡϡ�����A......\n");
	A = creatcroslist();
	system("cls");
	printf("���ڻ�ȡϡ�����B......\n");
	B = creatcroslist();
	system("cls");

	printf("ϡ�����A��\n");
	print(A);
	printf("ϡ�����B��\n");
	print(B);

	C = add(A, B);
	puts("ϡ�����A��ϡ�����B�ĺ�Ϊ��");
	print(C);
}

manode *creatcroslist()
{
	manode *p, *q, *head, *cp[MAXSIZE];
	int i, j, k, m, n, t, s;
	ElemType value;

	printf("�������С��С�����Ԫ�ظ������м��ö��Ÿ�������");
	scanf("%d,%d,%d", &m, &n, &t);

	if (m > n)
		s = m;
	else
		s = n;
	head = (manode *)malloc(sizeof(manode));//����ʮ������ͷ���
	head->i = m;
	head->j = n;

	cp[0] = head;//cp[]����ʱָ�����飬�ֱ�ָ��ͷ�����С��б�ͷ���
	for (i = 1; i <= s; i++)//����ͷ���ѭ������
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
		printf("��%d������Ԫ�ص��кš��кš�Ԫ��ֵ���м��ö��Ÿ�����:", k);
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

	//�����Ǿ�*p�������i��������
	q = cp[i];
	while ((q->right != cp[i]) && (q->right->j < j))
		q = q->right;//�ڵ�i�����ҵ�һ���кŴ���j�Ľ��*(q->right)
	//�Ҳ���ʱ��*q�Ǹ��б��ϵ�β���
	p->right = q->right;
	q->right = p;//*p������*q֮��

	//�����ǽ��������j��������
	q = cp[j];//ȡ��j�б�ͷ���
	while ((q->down != cp[j]) && (q->down->i < i))
		q = q->down;//�ڵ�j�����ҵ�һ���кŴ���i�Ľ��*(q->down)
	//�Ҳ���ʱ��*q�Ǹ��б��ϵ�β���
	p->down = q->down;
	q->down = p;//*p������*q֮��
}

manode *add(manode *A, manode *B)
{
	manode *p, *q, *u, *v, *r, *cp[MAXSIZE], *C;//p,q����ʮ����A������,u,v����ʮ����B������
	int s, i;
	if (A->i != B->i || A->j != B->j)
	{
		puts("ϡ�����A��ϡ�����B������ӣ�");
		exit(0);
	}

	//����C�ı�ͷ����
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

	//�������
	p = A->tag.next; u = B->tag.next;
	while (p != A && u != B)
	{
		q = p->right;
		v = u->right;
		if (q == p && v != u)//����A�е�p��Ϊ�գ�����B�ĵ�u�в�Ϊ��
		while (v != u)//��B���еĶ����Ƶ��;�����
		{
			insert(v->i, v->j, v->tag.value, cp);
			v = v->right;
		}
		else if (v == u && q != p)//����A�е�p�в�Ϊ�գ�����B�ĵ�u��Ϊ��
		while (q != p)
		{
			insert(q->i, q->j, q->tag.value, cp);
			q = q->right;
		}
		else if (q != p && v != u)//����B�ĵ�u�к;���A�ĵ�p�ж���Ϊ��
		{
			while (q != p && v != u)
			{
				if (q->j<v->j)//���A����Ԫ�ص�����С��B�ģ���A�е�����С��B��ֵ���嵽C��
				{
					insert(q->i, q->j, q->tag.value, cp);
					q = q->right;
				}
				else if (q->j>v->j)//���B����Ԫ�ص�����С��A�ģ���A�е�����С��B��ֵ���嵽C��
				{
					insert(v->i, v->j, v->tag.value, cp);
					v = v->right;
				}
				else//A��B��ǰ����ͬһ��λ�ã��жϼӵĺ��Ƿ�Ϊ�㣬��Ϊ������ӷ�����
				{
					if (q->tag.value + v->tag.value != 0)
						insert(q->i, q->j, (q->tag.value + v->tag.value), cp);
					q = q->right; v = v->right;
				}
			}
			if (q == p && v != u)//���Bδ�����꣬��B��δ�����ֵ�����뵽�;�����
			while (v != u)
			{
				insert(v->i, v->j, v->tag.value, cp);
				v = v->right;
			}
			else if (v == u && q != p)//���Aδ�����꣬��A��δ�����ֵ�����뵽�;�����
			while (q != p)
			{
				insert(q->i, q->j, q->tag.value, cp);
				q = q->right;
			}
		}
		p = p->tag.next;
		u = u->tag.next;//A��B��ָ����һ��
	}
	return C;
}

void print(manode *M)
{
	manode *p, *q, *r;//p��ָ���У�q��ָ���У�r��ָ��ĳһ�ڵ����ʱָ��
	int k, t, col, row;
	col = M->j;//����M������
	p = M->tag.next;//pָ���һ����㣬����ͷ���
	row = 1;
	while (row <= M->i)//�ж����Ƿ�ѭ����
	{
		q = p->right;//pָ����һ�е�һ��ֵ
		r = p;//rָ����һ�е�ͷ���
		while (q != p)//�ж����Ƿ�ѭ����
		{
			for (k = 1; k < (q->j - r->j); k++)//���ͬһ�������������ݼ����
				printf("   0");
			printf("%4d", q->tag.value);//����Ǹ�����ֵ
			q = q->right;//qָ����һ�е���һ��Ԫ��
			r = r->right;//rָ��qǰ���һ������Ԫ��
		}
		k = r->j;//k��ֵ��ĳһ�е����һ������Ԫ������
		for (t = k; t < col; t++)//���һ�������һ������Ԫ�������
			printf("   0");
		printf("\n\n");
		p = p->tag.next;//pָ����һ��
		row++;
	}
}