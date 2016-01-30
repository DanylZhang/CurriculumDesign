//编译环境：VS 2013
#define _CRT_SECURE_NO_WARNINGS//此语句用来消除在VS 2013环境下语法警告，VC++不必加此语句
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

int * initMain(void); //初始化函数
char * set_assemble(char *assemble);	//将输入的字符转为集合元素存储
int * init_matrix(char *A);//依据用户输入的集合初始化其关系矩阵
void set_boolean(char *A, int *matrix, char *relation);//依据用户输入的关系对关系矩阵赋值
int get_xb(char *A, char ch);//返回元素在集合A中的下标
void show_boolean_matrix(int *matrix);//输出建立好的布尔矩阵

int zfx(int *matrix);//自反性判定
int fzfx(int *matrix);//反自反性判定
int dcx(int *matrix);//对称性判定
int fdcx(int *matrix);//反对称性判定
int cdx(int *matrix);//传递性判定
int equal_relation(int *matrix);	//等价关系判定

int main()//主函数入口
{
	int *matrix = initMain();
	if (zfx(matrix))
		puts("二元关系R是自反的");
	if (fzfx(matrix))
		puts("二元关系R是反自反的");
	if (dcx(matrix))
		puts("二元关系R是对称的");
	if (fdcx(matrix))
		puts("二元关系R是反对称的");
	if (cdx(matrix))
		puts("二元关系R是传递的");
	if (equal_relation(matrix))
		puts("二元关系R是等价关系");
	return 0;
}

int * initMain(void)
{
	char assemble[100];
	char relation[500];

	puts("请输入集合A中的各元素(各元素请用逗号隔开)：");
	gets(assemble);
	char *A = set_assemble(assemble);
	int *matrix = init_matrix(A);

	puts("请输入二元关系R中的各个元素：");
	gets(relation);
	set_boolean(A, matrix, relation);

	show_boolean_matrix(matrix);
	return matrix;
}

char * set_assemble(char *assemble)
{
	int i = 0, count = 0;

	while (assemble[i] != '\0')
	{
		if (assemble[i] != ',')
		{
			count++;
			i++;
		}
		else
			i++;
	}
	char * A = (char *)malloc(sizeof(char)*count);
	if (A == NULL)
	{
		puts("动态内存分配失败！");
		exit(-1);
	}
	i = 0;
	while (assemble[i] != '\0')
	{
		if (assemble[i] != ',')
		{
			A[i] = assemble[i];
			i++;
		}
		else
			i++;
	}
	return A;
}

int * init_matrix(char *A)
{
	int i;
	int count = (sizeof(A) / sizeof(char))*(sizeof(A) / sizeof(char));
	int * matrix = (int *)malloc(sizeof(int)*count);
	for (i = 0; i < count; i++)
		matrix[i] = 0;
	return matrix;
}

void set_boolean(char *A, int *matrix, char *relation)
{
	int i = 0, row, col;
	int n = sizeof(A) / sizeof(char);
	while (relation[i] != '\0')
	if ((i + 1) % 5 == 2)
	{
		row = get_xb(A, relation[i]);
		col = get_xb(A, relation[i + 2]);
		matrix[row*n + col] = 1;
		i = i + 4;
	}
	else
		i++;
}

int get_xb(char *A, char ch)				//返回字符在集合A中的下标
{
	int i;
	int n = sizeof(A) / sizeof(char);
	for (i = 0; i < n; i++)
	if (A[i] == ch)
		return i;
	return 0;
}

void show_boolean_matrix(int *matrix)
{
	int i, j;
	int n = (int)sqrt(sizeof(matrix)) + 1;
	for (i = 0; i < n; i++)
	{
		for (j = 0; j < n; j++)
			printf("%4d", matrix[i*n + j]);
		printf("\n");
	}
}

int zfx(int *matrix)
{
	int i;
	int n = (int)sqrt(sizeof(matrix)) + 1;
	for (i = 0; i < n; i++)
	if (matrix[i*n + i] == 0)
		return 0;
	return 1;
}

int fzfx(int *matrix)
{
	int i;
	int n = (int)sqrt(sizeof(matrix)) + 1;
	for (i = 0; i < n; i++)
	if (matrix[i*n + i] == 1)
		return 0;
	return 1;
}

int dcx(int *matrix)
{
	int i, j;
	int n = (int)sqrt(sizeof(matrix)) + 1;
	for (i = 1; i < n; i++)
	for (j = 0; j < i; j++)
	if (matrix[i*n + j] != matrix[j*n + i])
		return 0;
	return 1;
}

int fdcx(int *matrix)
{
	int i, j;
	int n = (int)sqrt(sizeof(matrix)) + 1;
	for (i = 1; i < n; i++)
	for (j = 0; j < i; j++)
	if (matrix[i*n + j] == matrix[j*n + i])
	if (matrix[i*n + j] && matrix[j*n + i])
		return 0;
	return 1;
}

int cdx(int *matrix)
{
	int row, col, i;
	int n = (int)sqrt(sizeof(matrix)) + 1;
	int * buerji_matrix = (int *)malloc(sizeof(int)*n*n);

	for (row = 0; row < n; row++)
	for (col = 0; col < n; col++)
	{
		buerji_matrix[row*n + col] = 0;
		for (i = 0; i < n; i++)
			buerji_matrix[row*n + col] += matrix[row*n + i] && matrix[i*n + col];
	}

	for (row = 0; row < n; row++)
	for (col = 0; col < n; col++)
	if (buerji_matrix[row*n + col] > matrix[row*n + col])
		return 0;
	return 1;
}

int equal_relation(int *matrix)
{
	if (zfx(matrix) && dcx(matrix) && cdx(matrix))
		return 1;
	else
		return 0;
}