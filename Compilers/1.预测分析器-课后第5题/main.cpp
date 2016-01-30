#include<iostream>
#include<fstream>
#include<stdlib.h>
#include<string.h>
using namespace std;

const int StackLen = 50;
const int WordLen = 20;
const char NT[] = "ABCDEFGHIJK";
const char T1[] = "xyzw+-,;)(:#";
const char T[] = "xyzw+-,;)(:";//�����ж��ս����������'#' 
const int M[sizeof(NT) - 1][sizeof(T1) - 1] = {//Ԥ�������
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
char Buf[4048] = { '\0' };//ɨ�軺����:buf

struct code_val {
	char code;						//�ֱ����
	char val[WordLen + 1];			//����ֵ
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

void concat(char token[], char c)	//ƴ���ַ�����
{
	int i = 0;
	for (; token[i]; i++);			//�����,�ҵ�����β
	token[i] = c, token[++i] = '\0';
}

char reserve(char token[])			//������ֺ���
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
	char token[WordLen + 1] = "";	//����ƴ�ӵ���
	if (IsLetter(Buf[i])) {			//��ʶ���������
		while (IsLetter(Buf[i]) || IsDigit(Buf[i]))
			concat(token, Buf[i++]);
		t.code = reserve(token);
		strcpy(t.val, token);		//���ر�ʶ��������ֵĶ�Ԫʽ
		return t;
	}
	if (IsDigit(Buf[i])) {			//����
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
		cout << "Error char->" << Buf[i] << endl;//�Ƿ��ַ�
		exit(0);
	}
	i++;
	return t;
}

void pretreatment(istream &cin, char Buf[])
{
	char c0 = '$', c1;							//C0Ϊǰһ���ַ���C1Ϊ��ǰ�ַ�
	bool in_comment = false;					//״̬��־
	int i = 0;
	do {
		c1 = cin.get();
		switch (in_comment) {
		case false:								//false:��ǰ�ַ�δ����ע��
			if (c0 == '/'&&c1 == '*')			//����ע�ͣ�ȥ���Ѵ���Buf��'/'
				in_comment = true, i--;
			else
				if (c0 == '\\'&&c1 == '\n')			//ȥ���Ѵ���Buf��'\'
					i--;
				else {
					if (c1 >= 'A'&&c1 <= 'Z')		//��дת��ΪСд
						c1 += 32;
					if (c1 == '\t' || c1 == '\n')	//��'\t','\n'ת��Ϊ' '
						c1 = ' ';
					Buf[i++] = c1;					//���ַ�����Buf
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
{//str=T,�ж�c�Ƿ����ս����str=NT���ж�c�Ƿ��Ƿ��ս�� 
	for (int i = 0; i < (int)strlen(str); i++)
		if (c == str[i])
			return 1;
	return 0;
}
int lin_col(char c, const char str[])
{//str=NT,��cת��Ϊ�кţ�0..10������cת��Ϊ�кţ�0..11) 
	for (int i = 0; i < (int)strlen(str); i++)
		if (c == str[i])
			return i;
	cout << "Err in lin_col()->" << c << endl;
	exit(0);
}
int main()
{
	cout << "������Դ���루��'#'��������" << endl;
	pretreatment(cin, Buf);
	ofstream coutf("Lex.txt", ios::out);
	code_val t;
	cout << endl << "<���ʶ�Ԫʽ>" << endl;
	int i = 0;
	do {
		while (Buf[i] == ' ')						//ȥ��ǰ���ո�
			i++;
		t = scanner(Buf, i);						//����һ��ɨ�������һ�����ʶ�Ԫʽ
		coutf << t.code << '\t' << t.val << endl;	//�����ʶ�Ԫʽд��Lex.txt�ļ�
		cout << '(' << t.code << ',' << t.val << ')' << endl;//��Ļ��ʾ���ʶ�Ԫʽ
	} while (t.code != '#');

	char stack[StackLen] = { '#','A' };
	int top = 1, j = 0;									//j������ʾ�����������ѭ������
	cout << endl << "����" << '\t' << "ջ" << '\t' << "X" << '\t' << "�����ֱ�" << endl;
	cout << j << ')';
	ifstream cinf("Lex.txt", ios::in);					//�����ļ�ΪLex.txt 
	cinf >> t.code >> t.val;							//����һ�����ʶ�Ԫʽ 
	while (1) {
		cout << '\t';
		for (int i = 0; i <= top; i++)
			cout << stack[i];
		cout << '\t' << ' ' << '\t' << t.code << endl;
		char X = stack[top--];
		if (!isT_NT(X, NT) && !isT_NT(X, T1)) {			//�Ƿ����� 
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
				cout << "*****��ȷ*****" << endl;
				break;
			}
			else {
				cout << "Err in #-->" << X << '\t' << t.code << endl;
				exit(0);
			}
		}
		if (isT_NT(X, T)) {							//���ս��
			if (X == t.code)
				cinf >> t.code >> t.val;			//����һ�����ʶ�Ԫʽ
			else {
				cout << "Err in T->" << X << '\t' << t.code << endl;
				exit(0);
			}
		}
		if (isT_NT(X, NT)) {						//�Ƿ��ս��
			int lin = lin_col(X, NT), col = lin_col(t.code, T1), k = M[lin][col];
			if (k != -1) {
				for (int i = strlen(p[k]) - 1; i >= 3; i--)	//�󲿷���1�ֽڣ�'->' 2�ֽ�
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