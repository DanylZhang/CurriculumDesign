//EDIT BY: �ŵ��� 41212205
#include <iostream>
using namespace std;

char str[256], strToken[50], ch;
//�����ַ��������ɵ��ʷ��ŵ��ַ������ַ�������
char IdTable[50][50], NumTable[50][50];
//��ʶ����������
int Id, Const;
//��ǰ��ʶ����ͳ�����λ�ã�
int syn, p, m, n, sum;
//��־����������λ�ã����λ�ã���ʱ��������������ʱ��������

char table[18][10] = { "DIM","IF","DO","STOP","END","��ʶ����","����(��)","=","+","++","*","**",",","(",")",";","{","}" };
//�����ֱ�

void print()
{
	cout << "\t\t\t--�ŵ��� �������2�� 41212205--" << endl;
	cout << endl << "�����ֱ�Ϊ:\n" << endl;
	for (int i = 0; i < 18; i++)
	{
		cout << i + 1 << "��";
		cout << table[i] << "\t";

		if (i % 6 == 5 && i != 0)//ÿ6������
		{
			cout << endl << endl;
		}
	}
	cout << "***�����뼸�����ӣ���'#'�������룩***" << endl;
}//��ӡ�����ֱ�

void GetChar()
{
	ch = str[p++];
}//����һ�����ַ�����ch�У�����ָʾ��ǰһ���ַ�λ��

void GetBC()
{
	while ((ch == ' ') || (ch == '\n'))
	{
		GetChar();
	}
}//���ch�е��ַ��Ƿ�Ϊ�հ׻�س���

void Concat()
{
	strToken[m++] = ch;
}//��ch�е��ַ����ӵ�strToken֮��

bool IsLetter(char ch)
{
	if (((ch <= 'z') && (ch >= 'a')) || ((ch <= 'Z') && (ch >= 'A')))
		return true;
	else return false;
}//�ж�ch�е��ַ��Ƿ�Ϊ��ĸ��

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
}//�ж�ch�е��ַ��Ƿ�Ϊ���֣�

int Reserve(char strToken[50])
{
	for (n = 0; n < 18; n++)
		if (strcmp(strToken, table[n]) == 0)
		{
			syn = n + 1;
			return syn;
		}
	return 6;
}//��strToken�е��ַ������ұ����ֱ������ر��룻

void Retract()
{
	p--;
	ch = '\0';
}//������ָʾ���ص�һ���ַ�λ�ã�

char * InsertId(char strToken[50])
{
	int i;
	for (i = 0; i < strlen(strToken); i++)
		IdTable[Id][i] = strToken[i];
	IdTable[Id][i] = '\0';
	i = Id;
	Id++;
	return IdTable[i];
}//��strToken�еı�ʶ�������ʶ�������ر�ʶ����ָ�룻

char * InsertConst(char strToken[50])
{
	int i, j;
	for (i = 0; i < strlen(strToken); i++)
		NumTable[Const][i] = strToken[i];
	i = Const;
	Const++;
	return NumTable[i];
}//��strToken�еĳ������볣�������س�����ָ�룻

void scaner()
{
	sum = 0;

	for (m = 0; m < 50; m++)
	{
		strToken[m++] = NULL;
	}//�ַ������ʼ����

	GetChar();//����һ���ַ���
	m = 0;//mΪstrToken�����ָʾ����
	GetBC();//ÿ�γԵ��հף�

	if (IsLetter(ch))//���¶�����Դ�����ַ�Ϊ��ĸ��
	{
		while (IsLetter(ch) || IsDigit(ch))
		{
			Concat();
			GetChar();
		}

		Retract();
		syn = 6;//6��Ϊ��ʶ�����ȼ���Ϊ��ʶ����

		if (Reserve(strToken) == 6)//��Ϊ��ʶ���������ʶ����ָ�룻
		{
			cout << "��ʶ����ָ��Ϊ��" << InsertId(strToken) << endl;
		}
	}//���ϼ���ʶ���ͱ����֣�
	else if (IsDigit(ch))//���¶�����Դ�����ַ�Ϊ���֣�
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

		cout << "������ָ��Ϊ��" << InsertConst(tmp) << endl;
	}
	else
	{
		switch (ch)//�ж����¶�����Դ�����ַ���
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
	//��ʼ����ʶ����ָ�룬������ָ�룬����λ��Ϊ0��
	print();//�����ʾ��Ϣ��

	do
	{
		ch = cin.get();
		str[p++] = ch;
	} while (ch != '#');

	p = 0;
	//����λ��Ϊ0��

	do
	{
		cout << endl;
		scaner();
		switch (syn)
		{
		case 0:
			cout << "������ַ�����" << endl;
			break;//������ʾ��
		case 7:
			cout << "�� " << sum << "\t��" << syn << " ��" << endl;
			break;//��Ϊ���������ʱ��
		case 19:
			break;//����ӡ"#"��
		default:
			cout << "�� " << strToken << "\t��" << syn << " ��" << endl;
			break;//���������
		}
	} while (syn != 19);//ֱ��'#'ѭ������

	system("pause");
	return 0;
}