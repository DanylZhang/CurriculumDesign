#include<iostream>
#include<fstream>
#include<stdlib.h>
#include<string.h>
using namespace std;

const int StackLen = 50;
const int WordLen = 20;
const char NT[] = "ABCDEFGHIJK";
const char T1[] = "xyzw+-,;)(:#";
const char T[] = "xyzw+-,;)(:";//用于判断终结符，不包括'#' 
const int M[sizeof(NT) - 1][sizeof(T1) - 1] = {//预测分析表
	{ -1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
	{ -1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1, 2 },
	{ -1, 3,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
	{ -1, 4,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
	{ -1,-1,-1,-1,-1,-1, 5,-1,-1,-1, 6,-1 },
	{ 8, 7, 7,-1, 7, 7,-1,-1,-1,-1,-1,-1 },
	{ -1, 9, 9,-1, 9, 9,-1,-1,-1,-1,-1,-1 },
	{ -1,-1,-1,-1,-1,-1,10,-1,11,-1,-1,-1 },
	{ -1,12,13,-1,13,13,-1,-1,-1,-1,-1,-1 },
	{ -1,-1,14,-1,14,14,-1,-1,-1,-1,-1,-1 },
	{ -1,-1,17,-1,15,16,-1,-1,-1,-1,-1,-1 }
};
const char *p[] = {
	"A->CB",
	"B->;CB",
	"B->",
	"C->D:F",
	"D->yE",
	"E->,yE",
	"E->",
	"F->I",
	"F->x(G)wF",
	"G->IH",
	"H->,IH",
	"H->",
	"I->y",
	"I->J",
	"J->Kz",
	"K->+",
	"K->-",
	"K->"
};
char Buf[4048] = { '\0' };//扫描缓冲区:buf

struct code_val {
	char code;						//种别编码
	char val[WordLen + 1];			//内码值
};

bool IsLetter(char ch) {
	if (ch >= 'a'&&ch <= 'z')
		return true;
	else
		return false;
}

bool IsDigit(char ch) {
	if (ch >= '0'&&ch <= '9')
		return true;
	else
		return false;
}

void concat(char token[], char c)	//拼接字符函数
{
	int i = 0;
	for (; token[i]; i++);			//空语句,找到单词尾
	token[i] = c, token[++i] = '\0';
}

char reserve(char token[])			//查基本字函数
{
	const char *table[2] = { "array","of" };
	const char code[2] = { 'x','w' };
	for (unsigned i = 0; i < 2; i++) {
		if (strcmp(token, table[i]) == 0)
			return code[i];
	}
	return 'y';
}

struct code_val scanner(char Buf[], int &i)
{
	struct code_val t = { '\0', "-" };
	char token[WordLen + 1] = "";	//用于拼接单词
	if (IsLetter(Buf[i])) {			//标识符或基本字
		while (IsLetter(Buf[i]) || IsDigit(Buf[i]))
			concat(token, Buf[i++]);
		t.code = reserve(token);
		strcpy(t.val, token);		//返回标识符或基本字的二元式
		return t;
	}
	if (IsDigit(Buf[i])) {			//整数
		while (IsDigit(Buf[i]))
			concat(token, Buf[i++]);
		t.code = 'z';
		strcpy(t.val, token);
		return t;
	}
	switch (Buf[i]) {
	case'+':
		t.code = '+'; break;
	case'-':
		t.code = '-'; break;
	case',':
		t.code = ','; break;
	case';':
		t.code = ';'; break;
	case'(':
		t.code = '('; break;
	case')':
		t.code = ')'; break;
	case':':
		t.code = ':'; break;
	case'#':
		t.code = '#'; break;
	default:
		cout << "Error char->" << Buf[i] << endl;//非法字符
		exit(0);
	}
	i++;
	return t;
}

void pretreatment(istream &cin, char Buf[])
{
	char c0 = '$', c1;							//C0为前一个字符，C1为当前字符
	bool in_comment = false;					//状态标志
	int i = 0;
	do {
		c1 = cin.get();
		switch (in_comment) {
		case false:								//false:当前字符未处于注释
			if (c0 == '/'&&c1 == '*')			//进入注释，去除已存入Buf的'/'
				in_comment = true, i--;
			else
				if (c0 == '\\'&&c1 == '\n')			//去除已存入Buf的'\'
					i--;
				else {
					if (c1 >= 'A'&&c1 <= 'Z')		//大写转换为小写
						c1 += 32;
					if (c1 == '\t' || c1 == '\n')	//将'\t','\n'转换为' '
						c1 = ' ';
					Buf[i++] = c1;					//将字符存入Buf
				}
				break;
		case true:
			if (c0 == '*'&&c1 == '/')
				in_comment = false;
		}
		c0 = c1;
	} while (c1 != '#');
	Buf[i] = '#';
}

bool isT_NT(char c, const char str[])
{//str=T,判断c是否是终结符；str=NT，判断c是否是非终结符 
	for (int i = 0; i < (int)strlen(str); i++)
		if (c == str[i])
			return 1;
	return 0;
}
int lin_col(char c, const char str[])
{//str=NT,将c转换为行号（0..10），将c转换为列号（0..11) 
	for (int i = 0; i < (int)strlen(str); i++)
		if (c == str[i])
			return i;
	cout << "Err in lin_col()->" << c << endl;
	exit(0);
}
int main()
{
	cout << "请输入源代码（以'#'结束）：" << endl;
	pretreatment(cin, Buf);
	ofstream coutf("Lex.txt", ios::out);
	code_val t;
	cout << endl << "<单词二元式>" << endl;
	int i = 0;
	do {
		while (Buf[i] == ' ')						//去除前导空格
			i++;
		t = scanner(Buf, i);						//调用一次扫描器获得一个单词二元式
		coutf << t.code << '\t' << t.val << endl;	//将单词二元式写入Lex.txt文件
		cout << '(' << t.code << ',' << t.val << ')' << endl;//屏幕显示单词二元式
	} while (t.code != '#');

	char stack[StackLen] = { '#','A' };
	int top = 1, j = 0;									//j用于显示计算次数，即循环次数
	cout << endl << "步骤" << '\t' << "栈" << '\t' << "X" << '\t' << "单词种别" << endl;
	cout << j << ')';
	ifstream cinf("Lex.txt", ios::in);					//输入文件为Lex.txt 
	cinf >> t.code >> t.val;							//读第一个单词二元式 
	while (1) {
		cout << '\t';
		for (int i = 0; i <= top; i++)
			cout << stack[i];
		cout << '\t' << ' ' << '\t' << t.code << endl;
		char X = stack[top--];
		if (!isT_NT(X, NT) && !isT_NT(X, T1)) {			//非法符号 
			cout << "Err in main->" << X << endl;
			exit(0);
		}
		cout << ++j << ')' << '\t';
		for (int i = 0; i <= top; i++)
			cout << stack[i];
		cout << '\t' << X << '\t' << t.code << endl;
		if (X == '#') {
			if (X == t.code) {
				cout << "\tAcc" << endl;
				cout << "*****正确*****" << endl;
				break;
			}
			else {
				cout << "Err in #-->" << X << '\t' << t.code << endl;
				exit(0);
			}
		}
		if (isT_NT(X, T)) {							//是终结符
			if (X == t.code)
				cinf >> t.code >> t.val;			//读下一个单词二元式
			else {
				cout << "Err in T->" << X << '\t' << t.code << endl;
				exit(0);
			}
		}
		if (isT_NT(X, NT)) {						//是非终结符
			int lin = lin_col(X, NT), col = lin_col(t.code, T1), k = M[lin][col];
			if (k != -1) {
				for (int i = strlen(p[k]) - 1; i >= 3; i--)	//左部符号1字节，'->' 2字节
					stack[++top] = *(p[k] + i);
			}
			else {
				cout << "Err in NT->" << X << '\t' << t.code << endl;
				exit(0);
			}
		}
	}
	system("pause");
	return 0;
}