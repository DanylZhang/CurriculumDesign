//编译环境：VS 2013
//2013年10月12日，第一次编辑，实现Brute-Force算法和KMP算法
//2013年10月14日，第二次编辑，主要增加了KMP算法中的next函数的修正值算法getnextval()

//对于Brute-Force算法就是用循环结构控制，从目标串的第i=pos-1个字符开始与模式串的第j=0个字符比较。
//若相等则i++，j++；否则目标串再从i-j+1个字符开始与模式串的第j=0个字符比较。
//Brute-Force算法存在指针的回溯，算法效率较低，最坏的时间复杂度为O(n*m)。

//KMP算法主要是引入了next函数，对指针的回溯有了很好的解决。next函数用来求解模式串自身局部匹配的信息。
//next函数确定了在模式串匹配不成功的第j个字符处模式串应往右移的量为j-next[j]个字符，再与目标串的失配点进行匹配。
//next函数的修正值算法考虑到了在模式串中出现t[j]==t[k]，而目标串中的字符s[i]与t[j]比较不相等时的情况，
//不再需要与t[k]进行比较，而直接与t[next[k]]进行比较即可，因为此时的next[j]应和next[k]值相同。
//KMP算法相比较于Brute-Force算法效率极大提高，时间复杂度为O(n+m)。

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>								//包含exit()函数
#include <malloc.h>
#define INITSIZE 100

typedef struct
{
	char *ch;
	int length;
	int strsize;
}string;

void initstring(string *s);						//初始化串函数
void strassign(string *s1, char *s2);			//串赋值函数

int BF_index(string *s, string *t, int pos);		//Brute-Force函数

void getnext(string *t, int next[]);				//由模式串t求出其next值
void getnextval(string *t, int nextval[]);		//由模式串t求出其nextval值

int KMP_index(string *s, string *t, int pos);	//KMP函数，使用getnext()函数
int KMP_index2(string *s, string *t, int pos);	//KMP函数，使用next函数的修正值

int main()
{
	string s, t;
	char str1[INITSIZE], str2[INITSIZE];
	int pos, i;

	initstring(&s);
	initstring(&t);

	printf("请输入要查找的目标串 S：");
	gets(str1);									//gets()用于获取一行字符串，中间可以有空格，以回车结束
	strassign(&s, str1);

	printf("请输入要查找的模式串 T：");
	gets(str2);
	strassign(&t, str2);

	printf("请输入模式匹配的起始位序：");
	scanf("%d", &pos);

	i = BF_index(&s, &t, pos);
	if (i != 0)
		printf("1.Brute-Force算法匹配结果：\n\t模式串T在目标串S中的位序为：%d\n\n", i);
	else
		printf("1.Brute-Force算法匹配结果：\n\t模式匹配失败！\n\n");

	i = KMP_index(&s, &t, pos);
	if (i != 0)
		printf("2.KMP算法匹配结果：\n\t模式串T在目标串S中的位序为：%d\n\n", i);
	else
		printf("2.KMP算法匹配结果：\n\t模式匹配失败！\n\n");

	i = KMP_index2(&s, &t, pos);
	if (i != 0)
		printf("3.KMP算法匹配结果(使用next函数的修正值)：\n\t模式串T在目标串S中的位序为：%d\n", i);
	else
		printf("3.KMP算法匹配结果(使用next函数的修正值)：\n\t模式匹配失败！\n");
	return 0;
}

void initstring(string *s)
{
	s->ch = (char *)malloc(sizeof(char)*INITSIZE);
	if (s->ch == NULL)
	{
		puts("动态内存分配失败！");
		exit(-1);
	}
	s->length = 0;
	s->strsize = INITSIZE;
	return;
}

void strassign(string *s1, char *s2)
{
	int i = 0;
	while (s2[i] != '\0')						//求出常量串s2的长度
		i++;
	if (i > s1->strsize)
	{
		s1->ch = (char *)realloc(s1->ch, sizeof(char)*i);
		if (s1->ch == NULL)
		{
			puts("动态内存分配失败！");
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
		puts("非法的模式匹配起始位序！");
		return 0;
	}
	i = pos - 1;
	j = 0;
	while (i < s->length && j < t->length)
	if (s->ch[i] == t->ch[j])
		i++, j++;
	else
		i = i - j + 1, j = 0;
	if (j == t->length)						//条件满足说明匹配成功
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
	if (k == -1 || t->ch[j] == t->ch[k])		//千万不要忘了“j == -1”这一条件，否则会出现t->ch[-1]的情况
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
		if (t->ch[j] != t->ch[k])			//相比较于getnext()函数多了一个条件判断失配的t[j]与t[k]的相等关系
			nextval[j] = k;
		else
			nextval[j] = nextval[k];
	}
	else
		k = nextval[k];
}

int KMP_index(string *s, string *t, int pos)
{
	int i, j, next[INITSIZE];				//next的方括号中须是一个确定的值，而t->length在程序未运行前是不确定的
	getnext(t, next);
	if (pos < 1 || pos >(s->length - t->length + 1))
	{
		puts("非法的模式匹配起始位序！");
		return 0;
	}
	i = pos - 1;
	j = 0;
	while (i < s->length && j < t->length)
	if (j == -1 || s->ch[i] == t->ch[j])		//千万不要忘了“j == -1”这一条件，否则会出现t->ch[-1]的情况
		i++, j++;							//对应字符相同，指针后移一个位置
	else
		j = next[j];							//i不变，j后退，相当于模式串向右滑动
	if (j == t->length)						//条件满足说明匹配成功
		return i - j + 1;
	else
		return 0;
}

int KMP_index2(string *s, string *t, int pos)
{
	int i, j, nextval[INITSIZE];				//next的方括号中须是一个确定的值，而t->length在程序未运行前是不确定的
	getnextval(t, nextval);
	if (pos < 1 || pos >(s->length - t->length + 1))
	{
		puts("非法的模式匹配起始位序！");
		return 0;
	}
	i = pos - 1;
	j = 0;
	while (i < s->length && j < t->length)
	if (j == -1 || s->ch[i] == t->ch[j])		//千万不要忘了“j == -1”这一条件，否则会出现t->ch[-1]的情况
		i++, j++;							//对应字符相同，指针后移一个位置
	else
		j = nextval[j];						//i不变，j后退，相当于模式串向右滑动
	if (j == t->length)						//条件满足说明匹配成功
		return i - j + 1;
	else
		return 0;
}