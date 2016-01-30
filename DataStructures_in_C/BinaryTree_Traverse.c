/*--------------------------------------------------------------
---------------------------二叉树的遍历--------------------------
---------包括先序、中序、后序的递归遍历以及中序的非递归遍历---------
------------------------编译环境：VS 2013------------------------
--------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//用于取消VS 2013对printf、scanf等函数的警告
#include <stdio.h>
#include <stdlib.h>

typedef char ElemType;
//定义二叉树数据类型用于存储二叉树结点值
typedef struct BiNode
{
	ElemType data;
	struct BiNode *lchild, *rchild;
}BiTree;
//定义链栈数据类型用于存储二叉树结点地址值
typedef struct Node
{
	BiTree *pointer;
	struct Node *next;
}Stack;

BiTree * CreatBiTree(void);//以先序建立二叉树

void PreOrder(BiTree *bt);//先序遍历
void InOrder(BiTree *bt);//中序遍历
void PostOrder(BiTree *bt);//后序遍历
void InOrder_Non_Recursion(BiTree *bt);//中序非递归遍历

Stack * Initstack(void);//初始化栈
int EmptyStack(Stack *S);//判栈空
int push(Stack *S, BiTree *ptr);//入栈，将二叉树结点的地址存入栈
int pop(Stack *S, BiTree **ptr);//出栈，将二叉树结点的地址传给p，并弹出

int main()
{
	BiTree *bt;
	printf("以先序建立二叉树！请依次输入值（空格表示空）：");
	bt = CreatBiTree();

	printf("\n先序遍历二叉树：");
	PreOrder(bt);
	printf("\n中序遍历二叉树：");
	InOrder(bt);
	printf("\n后序遍历二叉树：");
	PostOrder(bt);
	printf("\n\n中序非递归遍历二叉树：");
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
			puts("二叉树动态内存分配失败！");
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
		puts("初始化栈失败！");
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
		puts("空栈无法弹栈！");
		return 0;
	}
	p = S->next;
	*ptr = p->pointer;
	S->next = p->next;
	free(p);
	return 1;
}