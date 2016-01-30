//���뻷����VS 2013
//2013��10��12�գ���һ�α༭��ʵ��Brute-Force�㷨��KMP�㷨
//2013��10��14�գ��ڶ��α༭����Ҫ������KMP�㷨�е�next����������ֵ�㷨getnextval()

//����Brute-Force�㷨������ѭ���ṹ���ƣ���Ŀ�괮�ĵ�i=pos-1���ַ���ʼ��ģʽ���ĵ�j=0���ַ��Ƚϡ�
//�������i++��j++������Ŀ�괮�ٴ�i-j+1���ַ���ʼ��ģʽ���ĵ�j=0���ַ��Ƚϡ�
//Brute-Force�㷨����ָ��Ļ��ݣ��㷨Ч�ʽϵͣ����ʱ�临�Ӷ�ΪO(n*m)��

//KMP�㷨��Ҫ��������next��������ָ��Ļ������˺ܺõĽ����next�����������ģʽ������ֲ�ƥ�����Ϣ��
//next����ȷ������ģʽ��ƥ�䲻�ɹ��ĵ�j���ַ���ģʽ��Ӧ�����Ƶ���Ϊj-next[j]���ַ�������Ŀ�괮��ʧ������ƥ�䡣
//next����������ֵ�㷨���ǵ�����ģʽ���г���t[j]==t[k]����Ŀ�괮�е��ַ�s[i]��t[j]�Ƚϲ����ʱ�������
//������Ҫ��t[k]���бȽϣ���ֱ����t[next[k]]���бȽϼ��ɣ���Ϊ��ʱ��next[j]Ӧ��next[k]ֵ��ͬ��
//KMP�㷨��Ƚ���Brute-Force�㷨Ч�ʼ�����ߣ�ʱ�临�Ӷ�ΪO(n+m)��

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>								//����exit()����
#include <malloc.h>
#define INITSIZE 100

typedef struct
{
	char *ch;
	int length;
	int strsize;
}string;

void initstring(string *s);						//��ʼ��������
void strassign(string *s1, char *s2);			//����ֵ����

int BF_index(string *s, string *t, int pos);		//Brute-Force����

void getnext(string *t, int next[]);				//��ģʽ��t�����nextֵ
void getnextval(string *t, int nextval[]);		//��ģʽ��t�����nextvalֵ

int KMP_index(string *s, string *t, int pos);	//KMP������ʹ��getnext()����
int KMP_index2(string *s, string *t, int pos);	//KMP������ʹ��next����������ֵ

int main()
{
	string s, t;
	char str1[INITSIZE], str2[INITSIZE];
	int pos, i;

	initstring(&s);
	initstring(&t);

	printf("������Ҫ���ҵ�Ŀ�괮 S��");
	gets(str1);									//gets()���ڻ�ȡһ���ַ������м�����пո��Իس�����
	strassign(&s, str1);

	printf("������Ҫ���ҵ�ģʽ�� T��");
	gets(str2);
	strassign(&t, str2);

	printf("������ģʽƥ�����ʼλ��");
	scanf("%d", &pos);

	i = BF_index(&s, &t, pos);
	if (i != 0)
		printf("1.Brute-Force�㷨ƥ������\n\tģʽ��T��Ŀ�괮S�е�λ��Ϊ��%d\n\n", i);
	else
		printf("1.Brute-Force�㷨ƥ������\n\tģʽƥ��ʧ�ܣ�\n\n");

	i = KMP_index(&s, &t, pos);
	if (i != 0)
		printf("2.KMP�㷨ƥ������\n\tģʽ��T��Ŀ�괮S�е�λ��Ϊ��%d\n\n", i);
	else
		printf("2.KMP�㷨ƥ������\n\tģʽƥ��ʧ�ܣ�\n\n");

	i = KMP_index2(&s, &t, pos);
	if (i != 0)
		printf("3.KMP�㷨ƥ����(ʹ��next����������ֵ)��\n\tģʽ��T��Ŀ�괮S�е�λ��Ϊ��%d\n", i);
	else
		printf("3.KMP�㷨ƥ����(ʹ��next����������ֵ)��\n\tģʽƥ��ʧ�ܣ�\n");
	return 0;
}

void initstring(string *s)
{
	s->ch = (char *)malloc(sizeof(char)*INITSIZE);
	if (s->ch == NULL)
	{
		puts("��̬�ڴ����ʧ�ܣ�");
		exit(-1);
	}
	s->length = 0;
	s->strsize = INITSIZE;
	return;
}

void strassign(string *s1, char *s2)
{
	int i = 0;
	while (s2[i] != '\0')						//���������s2�ĳ���
		i++;
	if (i > s1->strsize)
	{
		s1->ch = (char *)realloc(s1->ch, sizeof(char)*i);
		if (s1->ch == NULL)
		{
			puts("��̬�ڴ����ʧ�ܣ�");
			exit(-1);
		}
		s1->strsize = i;
	}
	s1->length = i;
	for (i = 0; i < s1->length; i++)
		s1->ch[i] = s2[i];
	return;
}

int BF_index(string *s, string *t, int pos)
{
	int  i, j;
	if (pos < 1 || pos >(s->length - t->length + 1))
	{
		puts("�Ƿ���ģʽƥ����ʼλ��");
		return 0;
	}
	i = pos - 1;
	j = 0;
	while (i < s->length && j < t->length)
	if (s->ch[i] == t->ch[j])
		i++, j++;
	else
		i = i - j + 1, j = 0;
	if (j == t->length)						//��������˵��ƥ��ɹ�
		return i - j + 1;
	else
		return 0;
}

void getnext(string *t, int next[])
{
	int j, k;

	j = 0;
	k = -1;
	next[0] = -1;

	while (j < t->length)
	if (k == -1 || t->ch[j] == t->ch[k])		//ǧ��Ҫ���ˡ�j == -1����һ��������������t->ch[-1]�����
	{
		j++;
		k++;
		next[j] = k;
	}
	else
		k = next[k];
}

void getnextval(string *t, int nextval[])
{
	int j, k;

	j = 0;
	k = -1;
	nextval[0] = -1;

	while (j < t->length)
	if (k == -1 || t->ch[j] == t->ch[k])
	{
		j++, k++;
		if (t->ch[j] != t->ch[k])			//��Ƚ���getnext()��������һ�������ж�ʧ���t[j]��t[k]����ȹ�ϵ
			nextval[j] = k;
		else
			nextval[j] = nextval[k];
	}
	else
		k = nextval[k];
}

int KMP_index(string *s, string *t, int pos)
{
	int i, j, next[INITSIZE];				//next�ķ�����������һ��ȷ����ֵ����t->length�ڳ���δ����ǰ�ǲ�ȷ����
	getnext(t, next);
	if (pos < 1 || pos >(s->length - t->length + 1))
	{
		puts("�Ƿ���ģʽƥ����ʼλ��");
		return 0;
	}
	i = pos - 1;
	j = 0;
	while (i < s->length && j < t->length)
	if (j == -1 || s->ch[i] == t->ch[j])		//ǧ��Ҫ���ˡ�j == -1����һ��������������t->ch[-1]�����
		i++, j++;							//��Ӧ�ַ���ͬ��ָ�����һ��λ��
	else
		j = next[j];							//i���䣬j���ˣ��൱��ģʽ�����һ���
	if (j == t->length)						//��������˵��ƥ��ɹ�
		return i - j + 1;
	else
		return 0;
}

int KMP_index2(string *s, string *t, int pos)
{
	int i, j, nextval[INITSIZE];				//next�ķ�����������һ��ȷ����ֵ����t->length�ڳ���δ����ǰ�ǲ�ȷ����
	getnextval(t, nextval);
	if (pos < 1 || pos >(s->length - t->length + 1))
	{
		puts("�Ƿ���ģʽƥ����ʼλ��");
		return 0;
	}
	i = pos - 1;
	j = 0;
	while (i < s->length && j < t->length)
	if (j == -1 || s->ch[i] == t->ch[j])		//ǧ��Ҫ���ˡ�j == -1����һ��������������t->ch[-1]�����
		i++, j++;							//��Ӧ�ַ���ͬ��ָ�����һ��λ��
	else
		j = nextval[j];						//i���䣬j���ˣ��൱��ģʽ�����һ���
	if (j == t->length)						//��������˵��ƥ��ɹ�
		return i - j + 1;
	else
		return 0;
}