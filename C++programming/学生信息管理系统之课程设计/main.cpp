#include "Admin.h"
#include "Counsellor.h"
#include "Teacher.h"
#include "Student.h"
using namespace std;

void StudentFun();
void TeacherFun();
void CounsellorFun();
void AdminFun();

int main()
{
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
			<< "\n\t\t\t\t1��ѧ����¼" << endl
			<< "\n\t\t\t\t2����ʦ��¼" << endl
			<< "\n\t\t\t\t3������Ա��¼" << endl
			<< "\n\t\t\t\t4������Ա��¼" << endl
			<< "\n\t\t\t\t5���˳�����" << endl
			<< "\n��ѡ�� 1~5: ";
		char ch;
		cin >> ch;
		cin.sync();
		cin.clear();
		switch (ch)
		{
		case '1':StudentFun(); break;
		case '2':TeacherFun(); break;
		case '3':CounsellorFun();break;
		case '4':AdminFun();break;
		case '5':flag = false; break;
		default:cout << "�������������ѡ��"; break;
		}
	} while (flag);
	return 0;
}

void StudentFun(){
	Student *student = new Student;
	student->Login();
	if (student->getState()){
		bool flag = true;
		do{
			system("cls");
			cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
				<< "\t\t\t\t\t\t\t\t" << student->getID() << " �ѵ�¼" << endl
				<< "\n\t\t\t    1���޸Ļ�����Ϣ" << endl
				<< "\n\t\t\t    2����ѯ������Ϣ" << endl
				<< "\n\t\t\t    3����ѯ���Գɼ�" << endl
				<< "\n\t\t\t    4����ѯ������Ϣ" << endl
				<< "\n\t\t\t    5����������" << endl
				<< "\n\t\t\t    6��ע��" << endl
				<< "\n��ѡ�� 1~6: ";
			char ch;
			cin >> ch;
			cin.sync();
			cin.clear();
			switch (ch)
			{
			case '1':student->updata_Info(); break;
			case '2':student->query_Info(); break;
			case '3':student->query_Score(); break;
			case '4':student->query_Punishment(); break;
			case '5':student->change_PWD(); break;
			case '6': cout << "���˳���¼���밴������������˵���"; _getch(); flag = false; break;
			default:cout << "�������������ѡ��"; break;
			}
		} while (flag);
	}
	delete student;
	system("cls");
	return;
}

void TeacherFun(){
	Teacher *teacher = new Teacher;
	teacher->Login();
	if (teacher->getState()){
		bool flag = true;
		do{
			system("cls");
			cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
				<< "\t\t\t\t\t\t\t\t" << teacher->getID() << " �ѵ�¼" << endl
				<< "\n\t\t\t    1����ӿ��Գɼ�" << endl
				<< "\n\t\t\t    2����ѯѧ��������Ϣ" << endl
				<< "\n\t\t\t    3����ѯѧ�����Գɼ�" << endl
				<< "\n\t\t\t    4����ѯѧ��������Ϣ" << endl
				<< "\n\t\t\t    5����������" << endl
				<< "\n\t\t\t    6��ע��" << endl
				<< "\n��ѡ�� 1~6: ";
			char ch;
			cin >> ch;
			cin.sync();
			cin.clear();
			switch (ch)
			{
			case '1':teacher->add_Score(); break;
			case '2':teacher->query_StudentInfo(); break;
			case '3':teacher->query_StudentScore(); break;
			case '4':teacher->query_StudentPunishment(); break;
			case '5':teacher->change_PWD(); break;
			case '6': cout << "���˳���¼���밴������������˵���"; _getch(); flag = false; break;
			default:cout << "�������������ѡ��"; break;
			}
		} while (flag);
	}
	delete teacher;
	system("cls");
	return;
}

void CounsellorFun(){
	Counsellor *counsellor = new Counsellor;
	counsellor->Login();
	if (counsellor->getState()){
		bool flag = true;
		do{
			system("cls");
			cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
				<< "\t\t\t\t\t\t\t\t" << counsellor->getID() << " �ѵ�¼" << endl
				<< "\n\t\t\t    1�����ѧ��������Ϣ" << endl
				<< "\n\t\t\t    2���޸�ѧ��������Ϣ" << endl
				<< "\n\t\t\t    3����ѯѧ��������Ϣ" << endl
				<< "\n\t\t\t    4����ѯѧ�����Գɼ�" << endl
				<< "\n\t\t\t    5����ѯѧ��������Ϣ" << endl
				<< "\n\t\t\t    6����������" << endl
				<< "\n\t\t\t    7��ע��" << endl
				<< "\n��ѡ�� 1~7: ";
			char ch;
			cin >> ch;
			cin.sync();
			cin.clear();
			switch (ch)
			{
			case '1':counsellor->update_StudentPunishment(); break;
			case '2':counsellor->update_StudentInfo(); break;
			case '3':counsellor->query_StudentInfo(); break;
			case '4':counsellor->query_StudentScore(); break;
			case '5':counsellor->query_StudentPunishment(); break;
			case '6':counsellor->change_PWD(); break;
			case '7': cout << "���˳���¼���밴������������˵���"; _getch(); flag = false; break;
			default:cout << "�������������ѡ��"; break;
			}
		} while (flag);
	}
	delete counsellor;
	system("cls");
	return;
}

void AdminFun(){
	Admin *admin = new Admin;
	admin->Login();
	if (admin->getState()){
		bool flag = true;
		do{
			system("cls");
			cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
				<< "\t\t\t\t\t\t\t\t" << admin->getID() << " �ѵ�¼" << endl
				<< "\n\t\t\t\t1������û�" << endl
				<< "\n\t\t\t\t2��ɾ���û�" << endl
				<< "\n\t\t\t\t3�����ݱ���" << endl
				<< "\n\t\t\t\t4�����ݻָ�" << endl
				<< "\n\t\t\t\t5����������" << endl
				<< "\n\t\t\t\t6��ע��" << endl
				<< "\n��ѡ�� 1~6: ";
			char ch;
			cin >> ch;
			cin.sync();
			cin.clear();
			switch (ch)
			{
			case '1':admin->add_User();break;
			case '2':admin->delete_User();break;
			case '3':admin->backup_Data();break;
			case '4':admin->recovery_Data();break;
			case '5':admin->change_PWD();break;
			case '6': cout << "���˳���¼���밴������������˵���"; _getch(); flag = false; break;
			default:cout << "�������������ѡ��"; break;
			}
		} while (flag);
	}
	delete admin;
	system("cls");
	return;
}