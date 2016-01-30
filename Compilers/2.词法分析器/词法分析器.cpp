//EDIT BY: 张丹玉 41212205
#include <iostream>
using namespace std;

char str[256], strToken[50], ch;
//输入字符串，构成单词符号的字符串，字符变量；
char IdTable[50][50], NumTable[50][50];
//标识符表，常数表；
int Id, Const;
//当前标识符表和常数表位置；
int syn, p, m, n, sum;
//标志变量，最新位置，最后位置，临时变量，常数（临时变量）；

char table[18][10] = { "DIM","IF","DO","STOP","END","标识符表","常熟(整)","=","+","++","*","**",",","(",")",";","{","}" };
//保留字表

void print()
{
	cout << "\t\t\t--张丹玉 软件工程2班 41212205--" << endl;
	cout << endl << "保留字表为:\n" << endl;
	for (int i = 0; i < 18; i++)
	{
		cout << i + 1 << "、";
		cout << table[i] << "\t";

		if (i % 6 == 5 && i != 0)//每6个换行
		{
			cout << endl << endl;
		}
	}
	cout << "***请输入几个句子（以'#'结束输入）***" << endl;
}//打印保留字表

void GetChar()
{
	ch = str[p++];
}//将下一输入字符读到ch中，搜索指示器前一个字符位；

void GetBC()
{
	while ((ch == ' ') || (ch == '\n'))
	{
		GetChar();
	}
}//检查ch中的字符是否为空白或回车；

void Concat()
{
	strToken[m++] = ch;
}//将ch中的字符连接到strToken之后；

bool IsLetter(char ch)
{
	if (((ch <= 'z') && (ch >= 'a')) || ((ch <= 'Z') && (ch >= 'A')))
		return true;
	else return false;
}//判断ch中的字符是否为字母；

bool IsDigit(char ch)
{
	if ((ch >= '0') && (ch <= '9'))
	{
		return true;
	}
	else
	{
		return false;
	}
}//判断ch中的字符是否为数字；

int Reserve(char strToken[50])
{
	for (n = 0; n < 18; n++)
		if (strcmp(strToken, table[n]) == 0)
		{
			syn = n + 1;
			return syn;
		}
	return 6;
}//对strToken中的字符串查找保留字表，并返回编码；

void Retract()
{
	p--;
	ch = '\0';
}//将搜索指示器回调一个字符位置；

char * InsertId(char strToken[50])
{
	int i;
	for (i = 0; i < strlen(strToken); i++)
		IdTable[Id][i] = strToken[i];
	IdTable[Id][i] = '\0';
	i = Id;
	Id++;
	return IdTable[i];
}//将strToken中的标识符插入标识符表，返回标识符表指针；

char * InsertConst(char strToken[50])
{
	int i, j;
	for (i = 0; i < strlen(strToken); i++)
		NumTable[Const][i] = strToken[i];
	i = Const;
	Const++;
	return NumTable[i];
}//将strToken中的常数插入常数表，返回常数表指针；

void scaner()
{
	sum = 0;

	for (m = 0; m < 50; m++)
	{
		strToken[m++] = NULL;
	}//字符数组初始化；

	GetChar();//读下一个字符；
	m = 0;//m为strToken数组的指示器；
	GetBC();//每次吃掉空白；

	if (IsLetter(ch))//最新读进的源程序字符为字母；
	{
		while (IsLetter(ch) || IsDigit(ch))
		{
			Concat();
			GetChar();
		}

		Retract();
		syn = 6;//6号为标识符，先假设为标识符；

		if (Reserve(strToken) == 6)//若为标识符，输出标识符表指针；
		{
			cout << "标识符表指针为：" << InsertId(strToken) << endl;
		}
	}//以上检查标识符和保留字；
	else if (IsDigit(ch))//最新读进的源程序字符为数字；
	{
		char tmp[50] = "";
		int j = 0;
		while (IsDigit(ch))
		{
			sum = sum * 10 + ch - '0';
			tmp[j++] = ch;
			GetChar();
		}
		Retract();
		syn = 7;

		cout << "常数表指针为：" << InsertConst(tmp) << endl;
	}
	else
	{
		switch (ch)//判断最新读进的源程序字符；
		{
		case '=':
			syn = 8;
			Concat();
			break;

		case '+':
			Concat();
			GetChar();
			if (ch == '+')
			{
				syn = 10;
				Concat();
			}
			else
			{
				syn = 9;
				Retract();
			}
			break;

		case '*':
			Concat();
			GetChar();
			if (ch == '*')
			{
				syn = 12;
				Concat();
			}
			else
			{
				syn = 11;
				Retract();
			}
			break;

		case ',':
			syn = 13;
			Concat();
			break;

		case '(':
			syn = 14;
			Concat();
			break;

		case ')':
			syn = 15;
			Concat();
			break;

		case ';':
			syn = 16;
			Concat();
			break;

		case '{':
			syn = 17;
			Concat();
			break;

		case '}':
			syn = 18;
			Concat();
			break;

		case '#':
			syn = 19;
			Concat();
			break;

		default:
			syn = 0;
			break;
		}
	}
	strToken[m++] = '\0';
}

int main()
{
	Id = Const = p = 0;
	//初始化标识符表指针，常数表指针，最新位置为0；
	print();//输出提示信息；

	do
	{
		ch = cin.get();
		str[p++] = ch;
	} while (ch != '#');

	p = 0;
	//最新位置为0；

	do
	{
		cout << endl;
		scaner();
		switch (syn)
		{
		case 0:
			cout << "错误的字符串！" << endl;
			break;//错误提示；
		case 7:
			cout << "（ " << sum << "\t，" << syn << " ）" << endl;
			break;//当为常数的情况时；
		case 19:
			break;//不打印"#"；
		default:
			cout << "（ " << strToken << "\t，" << syn << " ）" << endl;
			break;//正常输出；
		}
	} while (syn != 19);//直到'#'循环结束

	system("pause");
	return 0;
}