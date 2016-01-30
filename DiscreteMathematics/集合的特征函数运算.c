/*--------------------------------------------------------------
------------------�ü��ϵ���������ʵ�ּ��ϼ������-----------------
------------------------���뻷����VS 2013------------------------
--------------------------------------------------------------*/
#define _CRT_SECURE_NO_WARNINGS//����ȡ��VS 2013��printf��scanf�Ⱥ����ľ���
#include <stdio.h>
#include <stdlib.h>

//���弯�������������ڴ�ż���
typedef struct
{
	char *data;
	int count;
}Assemble;
//�����������������������ڴ�ż��ϵ���������
typedef struct
{
	int *data;
	int count;
}Eigenfunction;

void initAssemble(Assemble *A, char assemble[]);//��ʼ�����ϣ����洢����Ԫ��
void creatEigenfunction(Eigenfunction *A, char assemble[]);//�������ϵ������������洢
void showEigenfunction(Eigenfunction *A);//������ϵ���������
void intersection(Eigenfunction *Intersection_AB, Eigenfunction *A, Eigenfunction *B);//���ü��ϵ������������н�����
void Union(Eigenfunction *Union_AB, Eigenfunction *A, Eigenfunction *B);//���ü��ϵ������������в�����
void showAssemble(Eigenfunction *A);//�������Ԫ��

Assemble U;//��ȫ��U����Ϊȫ�ֱ���
int main()
{
	char temp_U[50], temp_A[50], temp_B[50];
	Eigenfunction A, B, Intersection_AB, Union_AB;
	system("color 5B");//���ó����ı���ɫ��ǰ��ɫ

	printf("������ȫ��U��");
	gets(temp_U);
	initAssemble(&U, temp_U);

	printf("\n�����뼯��A��");
	gets(temp_A);
	creatEigenfunction(&A, temp_A);
	printf("\n�����뼯��B��");
	gets(temp_B);
	creatEigenfunction(&B, temp_B);

	printf("\n����A������������\n");
	showEigenfunction(&A);
	printf("����B������������\n");
	showEigenfunction(&B);

	intersection(&Intersection_AB, &A, &B);
	printf("\n����A��B������������\n");
	showEigenfunction(&Intersection_AB);
	Union(&Union_AB, &A, &B);
	printf("����A��B������������\n");
	showEigenfunction(&Union_AB);

	printf("\n����A��B��Ԫ�أ�");
	showAssemble(&Intersection_AB);
	printf("����A��B��Ԫ�أ�");
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
		puts("��̬�ڴ����ʧ�ܣ�");
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
		puts("��̬�ڴ����ʧ�ܣ�");
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
		printf("X��%c��= %d\t", U.data[i], A->data[i]);
	printf("\n");
}

void intersection(Eigenfunction *Intersection_AB, Eigenfunction *A, Eigenfunction *B)
{
	int i;

	Intersection_AB->data = (int *)malloc(sizeof(int)*U.count);
	if (Intersection_AB->data == NULL)
	{
		puts("��̬�ڴ����ʧ�ܣ�");
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
		puts("��̬�ڴ����ʧ�ܣ�");
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