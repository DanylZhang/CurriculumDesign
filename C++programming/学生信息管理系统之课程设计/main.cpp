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
		cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
			<< "\n\t\t\t\t1、学生登录" << endl
			<< "\n\t\t\t\t2、教师登录" << endl
			<< "\n\t\t\t\t3、辅导员登录" << endl
			<< "\n\t\t\t\t4、管理员登录" << endl
			<< "\n\t\t\t\t5、退出程序" << endl
			<< "\n请选择 1~5: ";
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
		default:cout << "输入错误！请重新选择："; break;
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
			cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
				<< "\t\t\t\t\t\t\t\t" << student->getID() << " 已登录" << endl
				<< "\n\t\t\t    1、修改基本信息" << endl
				<< "\n\t\t\t    2、查询基本信息" << endl
				<< "\n\t\t\t    3、查询考试成绩" << endl
				<< "\n\t\t\t    4、查询奖惩信息" << endl
				<< "\n\t\t\t    5、更改密码" << endl
				<< "\n\t\t\t    6、注销" << endl
				<< "\n请选择 1~6: ";
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
			case '6': cout << "已退出登录！请按任意键返回主菜单。"; _getch(); flag = false; break;
			default:cout << "输入错误！请重新选择："; break;
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
			cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
				<< "\t\t\t\t\t\t\t\t" << teacher->getID() << " 已登录" << endl
				<< "\n\t\t\t    1、添加考试成绩" << endl
				<< "\n\t\t\t    2、查询学生基本信息" << endl
				<< "\n\t\t\t    3、查询学生考试成绩" << endl
				<< "\n\t\t\t    4、查询学生奖惩信息" << endl
				<< "\n\t\t\t    5、更改密码" << endl
				<< "\n\t\t\t    6、注销" << endl
				<< "\n请选择 1~6: ";
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
			case '6': cout << "已退出登录！请按任意键返回主菜单。"; _getch(); flag = false; break;
			default:cout << "输入错误！请重新选择："; break;
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
			cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
				<< "\t\t\t\t\t\t\t\t" << counsellor->getID() << " 已登录" << endl
				<< "\n\t\t\t    1、添加学生奖惩信息" << endl
				<< "\n\t\t\t    2、修改学生基本信息" << endl
				<< "\n\t\t\t    3、查询学生基本信息" << endl
				<< "\n\t\t\t    4、查询学生考试成绩" << endl
				<< "\n\t\t\t    5、查询学生奖惩信息" << endl
				<< "\n\t\t\t    6、更改密码" << endl
				<< "\n\t\t\t    7、注销" << endl
				<< "\n请选择 1~7: ";
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
			case '7': cout << "已退出登录！请按任意键返回主菜单。"; _getch(); flag = false; break;
			default:cout << "输入错误！请重新选择："; break;
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
			cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
				<< "\t\t\t\t\t\t\t\t" << admin->getID() << " 已登录" << endl
				<< "\n\t\t\t\t1、添加用户" << endl
				<< "\n\t\t\t\t2、删除用户" << endl
				<< "\n\t\t\t\t3、数据备份" << endl
				<< "\n\t\t\t\t4、数据恢复" << endl
				<< "\n\t\t\t\t5、更改密码" << endl
				<< "\n\t\t\t\t6、注销" << endl
				<< "\n请选择 1~6: ";
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
			case '6': cout << "已退出登录！请按任意键返回主菜单。"; _getch(); flag = false; break;
			default:cout << "输入错误！请重新选择："; break;
			}
		} while (flag);
	}
	delete admin;
	system("cls");
	return;
}