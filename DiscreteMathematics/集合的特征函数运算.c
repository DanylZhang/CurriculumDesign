/*--------------------------------------------------------------
------------------用集合的特征函数实现集合间的运算-----------------
------------------------编译环境：VS 2013------------------------
--------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//用于取消VS 2013对printf、scanf等函数的警告
#include <stdio.h>
#include <stdlib.h>

//定义集合数据类型用于存放集合
typedef struct
{
	char *data;
	int count;
}Assemble;
//定义特征函数数据类型用于存放集合的特征函数
typedef struct
{
	int *data;
	int count;
}Eigenfunction;

void initAssemble(Assemble *A, char assemble[]);//初始化集合，并存储集合元素
void creatEigenfunction(Eigenfunction *A, char assemble[]);//建立集合的特征函数并存储
void showEigenfunction(Eigenfunction *A);//输出集合的特征函数
void intersection(Eigenfunction *Intersection_AB, Eigenfunction *A, Eigenfunction *B);//利用集合的特征函数进行交运算
void Union(Eigenfunction *Union_AB, Eigenfunction *A, Eigenfunction *B);//利用集合的特征函数进行并运算
void showAssemble(Eigenfunction *A);//输出集合元素

Assemble U;//把全集U定义为全局变量
int main()
{
	char temp_U[50], temp_A[50], temp_B[50];
	Eigenfunction A, B, Intersection_AB, Union_AB;
	system("color 5B");//设置程序框的背景色和前景色

	printf("请输入全集U：");
	gets(temp_U);
	initAssemble(&U, temp_U);

	printf("\n请输入集合A：");
	gets(temp_A);
	creatEigenfunction(&A, temp_A);
	printf("\n请输入集合B：");
	gets(temp_B);
	creatEigenfunction(&B, temp_B);

	printf("\n集合A的特征函数：\n");
	showEigenfunction(&A);
	printf("集合B的特征函数：\n");
	showEigenfunction(&B);

	intersection(&Intersection_AB, &A, &B);
	printf("\n集合A交B的特征函数：\n");
	showEigenfunction(&Intersection_AB);
	Union(&Union_AB, &A, &B);
	printf("集合A并B的特征函数：\n");
	showEigenfunction(&Union_AB);

	printf("\n集合A交B的元素：");
	showAssemble(&Intersection_AB);
	printf("集合A并B的元素：");
	showAssemble(&Union_AB);
	return 0;
}

void  initAssemble(Assemble *A, char assemble[])
{
	int i = 0, j = 0, count = 0;
	while (assemble[i] != '\0')
	{
		if (('0' <= assemble[i] && assemble[i] <= '9') || ('A' <= assemble[i] && assemble[i] <= 'Z') || ('a' <= assemble[i] && assemble[i] <= 'z'))
		{
			count++;
			i++;
		}
		else
			i++;
	}
	A->data = (char *)malloc(sizeof(char)*count);
	if (A->data == NULL)
	{
		puts("动态内存分配失败！");
		exit(-1);
	}
	i = 0;
	while (assemble[i] != '\0')
	{
		if (('0' <= assemble[i] && assemble[i] <= '9') || ('A' <= assemble[i] && assemble[i] <= 'Z') || ('a' <= assemble[i] && assemble[i] <= 'z'))
		{
			A->data[j] = assemble[i];
			j++;
			i++;
		}
		else
			i++;
	}
	A->count = count;
}

void creatEigenfunction(Eigenfunction *A, char assemble[])
{
	int i, j;

	Assemble temp_A;
	initAssemble(&temp_A, assemble);

	A->data = (int *)malloc(sizeof(int)*U.count);
	if (A->data == NULL)
	{
		puts("动态内存分配失败！");
		exit(-1);
	}
	A->count = U.count;

	for (i = 0; i < U.count; i++)
	{
		for (j = 0; j < U.count; j++)
		{
			if (temp_A.data[j] == U.data[i])
			{
				A->data[i] = 1;
				break;
			}
			else
				A->data[i] = 0;
		}
	}
	free(temp_A.data);
}

void showEigenfunction(Eigenfunction *A)
{
	int i;
	for (i = 0; i < A->count; i++)
		printf("X（%c）= %d\t", U.data[i], A->data[i]);
	printf("\n");
}

void intersection(Eigenfunction *Intersection_AB, Eigenfunction *A, Eigenfunction *B)
{
	int i;

	Intersection_AB->data = (int *)malloc(sizeof(int)*U.count);
	if (Intersection_AB->data == NULL)
	{
		puts("动态内存分配失败！");
		exit(-1);
	}
	Intersection_AB->count = U.count;

	for (i = 0; i < U.count; i++)
	if (A->data[i] == 1 && B->data[i] == 1)
		Intersection_AB->data[i] = 1;
	else
		Intersection_AB->data[i] = 0;
}

void Union(Eigenfunction *Union_AB, Eigenfunction *A, Eigenfunction *B)
{
	int i;

	Union_AB->data = (int *)malloc(sizeof(int)*U.count);
	if (Union_AB->data == NULL)
	{
		puts("动态内存分配失败！");
		exit(-1);
	}
	Union_AB->count = U.count;

	for (i = 0; i < U.count; i++)
	if (A->data[i] == 0 && B->data[i] == 0)
		Union_AB->data[i] = 0;
	else
		Union_AB->data[i] = 1;
}

void showAssemble(Eigenfunction *A)
{
	int i;
	for (i = 0; i < A->count; i++)
	if (A->data[i] == 1)
		printf("%4c", U.data[i]);
	printf("\n");
}