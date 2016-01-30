/*--------------------------------------------------------------
----------------用三元组顺序表实现对稀疏矩阵的转置-----------------
------------------------编译环境：VS 2013------------------------
--------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//用于取消VS 2013对printf、scanf等函数的警告
#include <stdio.h>
#include <stdlib.h>

#define MAXSIZE 100
typedef int ElemType;
typedef struct
{
	int i;
	int j;
	ElemType e;
}tupletype;
typedef struct
{
	int rownum;
	int colnum;
	int nznum;
	tupletype data[MAXSIZE];
}table;

void creatable(table *M);			//用户输入，创建一个三元组表
void trans(table *M, table *T);		//转置
void show(table *M);					//以矩阵形式输出三元组表

int main()
{
	table M, T;

	creatable(&M);
	system("cls");
	puts("矩阵M：");
	show(&M);

	trans(&M, &T);
	puts("矩阵M的转置矩阵T：");
	show(&T);
	return 0;
}

void creatable(table *M)
{
	int row, col, i, j, nz;
	ElemType e;
	
	printf("请输入矩阵M的行、列、非零元素个数（中间用逗号隔开）：");
	scanf("%d,%d,%d", &row, &col, &nz);
	M->rownum = row;
	M->colnum = col;
	M->nznum = 0;
	
	while (M->nznum < nz)
	{
		printf("请输入依次输入矩阵M中非零元素的行标(1~%d)、列标(1~%d)和元素值：", row, col);
		scanf("%d,%d,%d", &i, &j, &e);
		if (e != 0)
		{
			M->data[M->nznum].i = i - 1;
			M->data[M->nznum].j = j - 1;
			M->data[M->nznum].e = e;
			M->nznum++;
		}
	}
}

void trans(table *M, table *T)
{
	int col, b, q = 0;
	T->rownum = M->colnum;
	T->colnum = M->rownum;
	T->nznum = M->nznum;
	if (T->nznum != 0)
	{
		for (col = 0; col < M->colnum; col++)
		{
			for (b = 0; b < M->nznum; b++)
			{
				if (M->data[b].j == col)
				{
					T->data[q].i = M->data[b].j;
					T->data[q].j = M->data[b].i;
					T->data[q].e = M->data[b].e;
					q++;
				}
			}
		}
	}
}

void show(table *M)
{
	int i, j, k, e;
	for (i = 0; i < M->rownum; i++)
	{
		for (j = 0; j < M->colnum; j++)
		{
			e = 0;
			for (k = 0; k < M->nznum; k++)
			{
				if (i == M->data[k].i && j == M->data[k].j)
				{
					e = M->data[k].e;
					break;
				}
			}
			printf("%4d", e);
		}
		printf("\n\n");
	}
}