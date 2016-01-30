#include<stdio.h>
#include<stdlib.h>
#include<malloc.h>

typedef int ElemType;
#define INITSIZE 100
typedef struct
{
	ElemType *data;
	int length;
	int listsize;
}sqlist;

void initlist();      /*初始化顺序表*/
int insert();         /*插入函数*/
int delete();         /*删除函数*/
int locate();         /*定位函数*/
void getelem();       /*获取特定元素*/
int getlen();         /*求表长函数*/
void show();          /*输出顺序表*/

void bubblesort();    /*排序函数*/
void invert();        /*倒置函数*/


int main()
{
	int i;
	ElemType x;
	sqlist *L;
	initlist(&L);
	for(i=1;i<=6;i++)
	{
		scanf("%d",&x);
		insert(&L,i,x);
	}
	show(&L);
	return 0;
}

void initlist(sqlist *L)
{
	L->data=(ElemType *)malloc(sizeof(ElemType)*INITSIZE);
	if(L->data == NULL)
	{
		puts("初始化失败");
		exit(-1);
	}
	L->length=0;
	L->listsize=INITSIZE;
}

int insert(sqlist *L,int i,ElemType x)
{
	int j;
	if(i<1 && i > L->length+1) return 0;  /*i值无效*/
	if(L->length == L->listsize)          /*增加内存空间大小*/
	{
		L->data=(ElemType *)realloc(L->data,(L->listsize+1)*sizeof(ElemType));
		L->listsize++;
	}
	for(j=L->length;j>=i;j--)
		L->data[j]=L->data[j-1];
	L->data[i-1]=x;
	L->length++;
	return 1;
}

int delete(sqlist *L,int i,ElemType *e)
{
	int j;
	if(i<1 && i>L->length+1) return 0;  /*i值无效*/
	*e=L->data[i-1];
	for(j=i+1;j<=L->length;j++)
		L->data[i-1]=L->data[i];
	L->length--;
	return 1;
}

int locate(sqlist *L,ElemType x)
{
	int i=0;
	for(i;i < L->length;i++)
		if(L->data[i] == x)
			return i+1;
		return 0;
}

void getelem(sqlist *L,int i,ElemType *e)
{
	if(i<1 && i>L->length+1) return;  /*i值无效*/
	*e=L->data[i-1];
}

int getlen(sqlist *L)
{
	return L->length;
}

void show(sqlist *L)
{
	int i;
	for(i=0;i < L->length;i++)
		printf("%d\n",L->data[i]);
	printf("\n");
}

void bubblesort(sqlist *L)
{
	int i,j,change;
	ElemType temp;
	for(i=change=1;change && i < L->length;i++)
		for(j=change=0;j < L->length-i;j++)
			if(L->data[j] > L->data[j+1])
			{
				temp = L->data[j+1];
				L->data[j+1] = L->data[j];
				L->data[j] = temp;
				change=1;
			}
			return;
}

void invert(sqlist *L)
{
	int i;
	ElemType temp;
	for(i=0;i<L->length/2;i++)
	{
		temp = L->data[L->length-i];
		L->data[L->length-i] = L->data[i];
		L->data[i] = temp;
	}
}