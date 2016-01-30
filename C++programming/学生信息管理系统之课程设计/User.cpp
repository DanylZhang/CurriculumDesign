#include "User.h"

User::User(string ID, string PWD) :ID(ID), PWD(PWD){}

User::~User(){
	this->Logout();
}

string User::input_pwd(){
	char ch;
	string pwd;
	while ((ch = _getch()) != '\r'){	//getchar()键盘输入先到缓冲区
		if (ch >= 48 && ch <= 122){
			pwd += ch;
			cout << '*';
		}
		else if (ch == 8 && !pwd.empty()){
			pwd.resize(pwd.size() - 1);
		}
	}
	cout << endl;
	return pwd;
}

string User::getNewPWD(){
	string oldPWD, newPWD1, newPWD2;
	do{
		cout << "请输入原密码：";
		oldPWD = input_pwd();
		if (this->PWD != oldPWD)
			cout << "密码错误！请重新输入。" << endl;
	} while (this->PWD != oldPWD);
	cout << "请输入新密码：";
	newPWD1 = input_pwd();
	do{
		cout << "请确认新密码：";
		newPWD2 = input_pwd();
		if (newPWD1 != newPWD2)
			cout << "密码错误！请重新确认。" << endl;
	} while (newPWD1 != newPWD2);
	return newPWD1;
}

bool User::existThisID(const string &filename, const string &thisid){
	ifstream fin(filename);
	if (!fin){
		cout << "文件读取失败！按任意键返回菜单。";
		_getch();
		exit(0);
	}
	string id;
	set<string> id_set;
	while (fin){
		fin >> id; fin.ignore(1024, '\n');
		if (fin)
			id_set.insert(id);
	}
	fin.close();
	if (id_set.find(thisid) != id_set.end())
		return true;
	else
		return false;
}