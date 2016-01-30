#include "StudentInfo.h"

string StudentInfo::getNianJi(){
	SYSTEMTIME sys;
	GetLocalTime(&sys);
	if (sys.wMonth >= intendTime.getMonth()){
		switch (sys.wYear - intendTime.getYear())
		{
		case 0:return "大一";
		case 1:return "大二";
		case 2:return "大三";
		case 3:return "大四";
		default:return "该生已毕业！";
		}
	}
	else{
		switch (sys.wYear - intendTime.getYear())
		{
		case 1:return "大一";
		case 2:return "大二";
		case 3:return "大三";
		case 4:return "大四";
		default:return "该生已毕业！";
		}
	}
}

void StudentInfo::print(){
	cout << "\n\n学号：\t\t" << stuNumber << endl;
	cout << "\n姓名：\t\t" << Name << endl;
	cout << "\n性别：\t\t" << Sex << endl;
	cout << "\n入学日期：\t" << intendTime << endl
		<< "\n年级：\t\t" << getNianJi() << endl;
	cout << "\n是否师范生：\t" << NormalMajor << endl;
	cout << "\n学院：\t\t" << Department << endl;
	cout << "\n专业：\t\t" << Major << endl;
	cout << "\n班级：\t\t" << Class << endl;
	cout << "\n身份证号：\t" << IdNumber << endl;
	cout << "\n手机号：\t" << PhoneNumber << endl;
	cout << "\n家庭住址：\t" << Address << endl;
}