/*--------------------------------------------------------------
---------------------------�������ı���--------------------------
---------�����������򡢺���ĵݹ�����Լ�����ķǵݹ����---------
------------------------���뻷����VS 2013------------------------
--------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//����ȡ��VS 2013��printf��scanf�Ⱥ����ľ���
#include <stdio.h>
#include <stdlib.h>

typedef char ElemType;
//��������������������ڴ洢���������ֵ
typedef struct BiNode
{
	ElemType data;
	struct BiNode *lchild, *rchild;
}BiTree;
//������ջ�����������ڴ洢����������ֵַ
typedef struct Node
{
	BiTree *pointer;
	struct Node *next;
}Stack;

BiTree * CreatBiTree(void);//��������������

void PreOrder(BiTree *bt);//�������
void InOrder(BiTree *bt);//�������
void PostOrder(BiTree *bt);//�������
void InOrder_Non_Recursion(BiTree *bt);//����ǵݹ����

Stack * Initstack(void);//��ʼ��ջ
int EmptyStack(Stack *S);//��ջ��
int push(Stack *S, BiTree *ptr);//��ջ�������������ĵ�ַ����ջ
int pop(Stack *S, BiTree **ptr);//��ջ�������������ĵ�ַ����p��������

int main()
{
	BiTree *bt;
	printf("��������������������������ֵ���ո��ʾ�գ���");
	bt = CreatBiTree();

	printf("\n���������������");
	PreOrder(bt);
	printf("\n���������������");
	InOrder(bt);
	printf("\n���������������");
	PostOrder(bt);
	printf("\n\n����ǵݹ������������");
	InOrder_Non_Recursion(bt);
	printf("\n");
	return 0;
}

BiTree * CreatBiTree(void)
{
	BiTree * bt;
	ElemType x;
	scanf("%c", &x);
	if (x == ' ')
		bt = NULL;
	else
	{
		bt = (BiTree *)malloc(sizeof(BiTree));
		if (bt == NULL)
		{
			puts("��������̬�ڴ����ʧ�ܣ�");
			exit(0);
		}
		bt->data = x;
		bt->lchild = CreatBiTree();
		bt->rchild = CreatBiTree();
	}
	return bt;
}

void PreOrder(BiTree *bt)
{
	if (bt != NULL)
	{
		printf("%c", bt->data);
		PreOrder(bt->lchild);
		PreOrder(bt->rchild);
	}
}

void InOrder(BiTree *bt)
{
	if (bt != NULL)
	{
		InOrder(bt->lchild);
		printf("%c", bt->data);
		InOrder(bt->rchild);
	}
}

void PostOrder(BiTree *bt)
{
	if (bt != NULL)
	{
		PostOrder(bt->lchild);
		PostOrder(bt->rchild);
		printf("%c", bt->data);
	}
}

void InOrder_Non_Recursion(BiTree *bt)
{
	Stack *S;
	BiTree *p;
	S = Initstack();
	p = bt;
	while (p || !EmptyStack(S))
	{
		while (p)
		{
			push(S, p);
			p = p->lchild;
		}
		pop(S, &p);
		printf("%c", p->data);
		p = p->rchild;
	}
}

Stack * Initstack(void)
{
	Stack *S = (Stack *)malloc(sizeof(Stack));
	if (S == NULL)
	{
		puts("��ʼ��ջʧ�ܣ�");
		exit(0);
	}
	S->next = NULL;
	return S;
}

int EmptyStack(Stack *S)
{
	if (S->next == NULL)
		return 1;
	else
		return 0;
}

int push(Stack *S, BiTree *ptr)
{
	Stack *p = (Stack *)malloc(sizeof(Stack));
	if (p == NULL)
		return 0;
	p->pointer = ptr;
	p->next = S->next;
	S->next = p;
	return 1;
}

int pop(Stack *S, BiTree **ptr)
{
	Stack *p;
	if (S->next == NULL)
	{
		puts("��ջ�޷���ջ��");
		return 0;
	}
	p = S->next;
	*ptr = p->pointer;
	S->next = p->next;
	free(p);
	return 1;
}