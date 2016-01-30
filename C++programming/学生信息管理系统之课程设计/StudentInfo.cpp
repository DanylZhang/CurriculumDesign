#include "StudentInfo.h"

string StudentInfo::getNianJi(){
	SYSTEMTIME sys;
	GetLocalTime(&sys);
	if (sys.wMonth >= intendTime.getMonth()){
		switch (sys.wYear - intendTime.getYear())
		{
		case 0:return "��һ";
		case 1:return "���";
		case 2:return "����";
		case 3:return "����";
		default:return "�����ѱ�ҵ��";
		}
	}
	else{
		switch (sys.wYear - intendTime.getYear())
		{
		case 1:return "��һ";
		case 2:return "���";
		case 3:return "����";
		case 4:return "����";
		default:return "�����ѱ�ҵ��";
		}
	}
}

void StudentInfo::print(){
	cout << "\n\nѧ�ţ�\t\t" << stuNumber << endl;
	cout << "\n������\t\t" << Name << endl;
	cout << "\n�Ա�\t\t" << Sex << endl;
	cout << "\n��ѧ���ڣ�\t" << intendTime << endl
		<< "\n�꼶��\t\t" << getNianJi() << endl;
	cout << "\n�Ƿ�ʦ������\t" << NormalMajor << endl;
	cout << "\nѧԺ��\t\t" << Department << endl;
	cout << "\nרҵ��\t\t" << Major << endl;
	cout << "\n�༶��\t\t" << Class << endl;
	cout << "\n���֤�ţ�\t" << IdNumber << endl;
	cout << "\n�ֻ��ţ�\t" << PhoneNumber << endl;
	cout << "\n��ͥסַ��\t" << Address << endl;
}