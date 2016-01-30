//���뻷����VS 2013
#define _CRT_SECURE_NO_WARNINGS//���������������VS 2013�������﷨���棬VC++���ؼӴ����
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

int * initMain(void); //��ʼ������
char * set_assemble(char *assemble);	//��������ַ�תΪ����Ԫ�ش洢
int * init_matrix(char *A);//�����û�����ļ��ϳ�ʼ�����ϵ����
void set_boolean(char *A, int *matrix, char *relation);//�����û�����Ĺ�ϵ�Թ�ϵ����ֵ
int get_xb(char *A, char ch);//����Ԫ���ڼ���A�е��±�
void show_boolean_matrix(int *matrix);//��������õĲ�������

int zfx(int *matrix);//�Է����ж�
int fzfx(int *matrix);//���Է����ж�
int dcx(int *matrix);//�Գ����ж�
int fdcx(int *matrix);//���Գ����ж�
int cdx(int *matrix);//�������ж�
int equal_relation(int *matrix);	//�ȼ۹�ϵ�ж�

int main()//���������
{
	int *matrix = initMain();
	if (zfx(matrix))
		puts("��Ԫ��ϵR���Է���");
	if (fzfx(matrix))
		puts("��Ԫ��ϵR�Ƿ��Է���");
	if (dcx(matrix))
		puts("��Ԫ��ϵR�ǶԳƵ�");
	if (fdcx(matrix))
		puts("��Ԫ��ϵR�Ƿ��ԳƵ�");
	if (cdx(matrix))
		puts("��Ԫ��ϵR�Ǵ��ݵ�");
	if (equal_relation(matrix))
		puts("��Ԫ��ϵR�ǵȼ۹�ϵ");
	return 0;
}

int * initMain(void)
{
	char assemble[100];
	char relation[500];

	puts("�����뼯��A�еĸ�Ԫ��(��Ԫ�����ö��Ÿ���)��");
	gets(assemble);
	char *A = set_assemble(assemble);
	int *matrix = init_matrix(A);

	puts("�������Ԫ��ϵR�еĸ���Ԫ�أ�");
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
		puts("��̬�ڴ����ʧ�ܣ�");
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

int get_xb(char *A, char ch)				//�����ַ��ڼ���A�е��±�
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