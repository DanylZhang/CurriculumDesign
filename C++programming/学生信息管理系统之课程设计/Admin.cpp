#include "Admin.h"

void Admin::Login(){
	ifstream fin("admin_user.txt");
	if (!fin){
		cout << "文件读取失败！请按任意键继续操作。";
		_getch();
		return;
	}
	string id, pwd;
	map<string, string> admin_map;
	while (fin){
		fin >> id; fin.get(); fin >> pwd; fin.get();
		if (fin)
			admin_map.insert(make_pair(id, pwd));
	}
	fin.close();
	do{
		cout << "请输入用户名：";
		cin >> id;
		cin.sync();cin.clear();
		if (admin_map.count(id) == 0)
			cout << "无此用户！请重新输入用户名。" << endl;
		else
			break;
	} while (true);
	do{
		cout << "请输入密码：";
		pwd = input_pwd();
		if (admin_map[id] == pwd){
			this->ID = id;
			this->PWD = pwd;
			this->Online = true;
			cout << "登录成功!按任意键继续操作。" << endl;
			_getch();
			system("cls");
		}
		else
			cout << "密码错误！请重新输入密码。" << endl;
	} while (!Online);
}

void Admin::change_PWD(){
	ifstream fin("admin_user.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	string temp_id, temp_pwd;
	map<string, string> admin_map;
	while (fin){
		fin >> temp_id; fin.get(); fin >> temp_pwd; fin.get();
		if (fin)
			admin_map.insert(make_pair(temp_id, temp_pwd));
	}
	fin.close();
	admin_map[this->ID] = getNewPWD();
	ofstream fout("admin_user.txt");
	output(admin_map.begin(), admin_map.end(), fout);
	fout.close();
	cout << "更改密码成功，请重新选择操作。";
	return;
}

void Admin::backup_Data(){
	system("explorer");
	cout << "数据已备份，按任意键继续。";
	_getch();
	return;
}

void Admin::recovery_Data(){
	system("explorer");
	cout << "数据已恢复，按任意键继续。";
	_getch();
	return;
}

void Admin::add_User(){
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " 已登录" << endl
			<< "\n\t\t\t    1、添加学生账户" << endl
			<< "\n\t\t\t    2、添加教师账户" << endl
			<< "\n\t\t\t    3、添加辅导员账户" << endl
			<< "\n\t\t\t    4、添加系统管理员账户" << endl
			<< "\n\t\t\t    5、返回上级菜单" << endl
			<< "\n请选择 1~5: ";
		char ch;
		cin >> ch;
		cin.sync();cin.clear();
		switch (ch)
		{
		case '1':add_studentUser(); break;
		case '2':add_teacherUser(); break;
		case '3':add_counsellorUser(); break;
		case '4':add_adminUser(); break;
		case '5':flag = false; break;
		default:cout << "输入错误！请重新选择："; break;
		}
	} while (flag);
}

void Admin::delete_User(){
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " 已登录" << endl
			<< "\n\t\t\t    1、删除学生账户" << endl
			<< "\n\t\t\t    2、删除教师账户" << endl
			<< "\n\t\t\t    3、删除辅导员账户" << endl
			<< "\n\t\t\t    4、删除系统管理员账户" << endl
			<< "\n\t\t\t    5、返回上级菜单" << endl
			<< "\n请选择 1~5: ";
		char ch;
		cin >> ch;
		cin.sync();cin.clear();
		switch (ch)
		{
		case '1':delete_studentUser(); break;
		case '2':delete_teacherUser(); break;
		case '3':delete_counsellorUser(); break;
		case '4':delete_adminUser(); break;
		case '5':flag = false; break;
		default:cout << "输入错误！请重新选择："; break;
		}
	} while (flag);
}

void Admin::add_studentUser(){
	system("cls");
	StudentInfo stuInfo;
	cout << "请输入学生学号：";
	cin >> stuInfo.stuNumber;
	cin.sync();cin.clear();
	if (existThisID("student_user.txt", stuInfo.stuNumber)){
		cout << "该用户已存在！按任意键返回上级菜单。";
		_getch();
		return;
	}
	stuInfo.Name = "未填";
	stuInfo.Sex = "未填";
	cout << "请输入入学日期(格式2012-1-1)：";
	bool flag = false;
	do{
		try{
			flag = false;
			cin >> stuInfo.intendTime;
		}
		catch (exception &e){
			flag = true;
			cout << e.what();
			cin.sync(); cin.clear();
		}
	} while (flag);
	cout << "请输入是否师范生：";
	cin >> stuInfo.NormalMajor;
	cin.sync();cin.clear();
	cout << "请输入所属学院：";
	cin >> stuInfo.Department;
	cin.sync();cin.clear();
	cout << "请输入专业：";
	cin >> stuInfo.Major;
	cin.sync();cin.clear();
	cout << "请输入班级：";
	cin >> stuInfo.Class;
	cin.sync();cin.clear();
	stuInfo.IdNumber = "未填";
	stuInfo.PhoneNumber = "未填";
	stuInfo.Address = "未填";
	ofstream fout("student_user.txt", ios_base::app);
	fout << stuInfo.stuNumber << '\t' << stuInfo.intendTime.getYear() << stuInfo.intendTime.getMonth() << endl;
	fout.close();
	fout.open("student_info.txt", ios_base::app);
	fout << stuInfo << endl;
	fout.close();
	cout << "新建用户信息已保存，按任意键返回上级菜单。";
	_getch();
	return;
}

void Admin::add_teacherUser(){
	system("cls");
	Teacher teacherInfo;
	vector<Teacher> vectTeacherInfo;
	bool flag = true;
	do{
		cout << "请输入教师工号：";
		cin >> teacherInfo.ID;
		cin.sync();cin.clear();
		if (existThisID("teacher_user.txt", teacherInfo.ID)){
			cout << "该用户已存在！";
			continue;
		}
		cout << "请输入教师密码：";
		teacherInfo.PWD = input_pwd();
		cout << "请输入所属教学单位：";
		cin >> teacherInfo.Department;
		cin.sync(); cin.clear();
		cout << "请输入班级：";
		cin >> teacherInfo.Class;
		cin.sync();cin.clear();
		cout << "请输入教授科目：";
		cin >> teacherInfo.Subject;
		cin.sync();cin.clear();
		vectTeacherInfo.push_back(teacherInfo);
		cout << "继续添加教师用户？（Y）";
		char ch; cin >> ch;
		cin.sync(); cin.clear();
		if (ch == 'y' || ch == 'Y')
			flag = true;
		else
			flag = false;
	} while (flag);
	ofstream fout("teacher_user.txt", ios_base::app);
	output(vectTeacherInfo.begin(), vectTeacherInfo.end(), fout);
	fout.close();
	cout << "新建用户信息已保存，按任意键返回上级菜单。";
	_getch();
	return;
}

void Admin::add_counsellorUser(){
	system("cls");
	Counsellor counsellorInfo;
	vector<Counsellor> vectCounsellorInfo;
	bool flag = true;
	do{
		cout << "请输入辅导员工号：";
		cin >> counsellorInfo.ID;
		cin.sync();cin.clear();
		if (existThisID("counsellor_user.txt", counsellorInfo.ID)){
			cout << "该用户已存在！";
			continue;
		}
		cout << "请输入辅导员密码：";
		counsellorInfo.PWD = input_pwd();
		cout << "请输入所属教学单位：";
		cin >> counsellorInfo.Department;
		cin.sync();cin.clear();
		cout << "请输入管理班级：";
		cin >> counsellorInfo.Class;
		cin.sync();cin.clear();
		vectCounsellorInfo.push_back(counsellorInfo);
		cout << "继续添加辅导员用户？（Y）";
		char ch; cin >> ch;
		cin.sync(); cin.clear();
		if (ch == 'y' || ch == 'Y')
			flag = true;
		else
			flag = false;
	} while (flag);
	ofstream fout("counsellor_user.txt", ios_base::app);
	output(vectCounsellorInfo.begin(), vectCounsellorInfo.end(), fout);
	fout.close();
	cout << "新建用户信息已保存，按任意键返回上级菜单。";
	_getch();
	return;
}

void Admin::add_adminUser(){
	system("cls");
	Admin adminInfo;
	cout << "请输入管理员登录名：";
	cin >> adminInfo.ID;
	cin.sync();cin.clear();
	if (existThisID("admin_user.txt", adminInfo.ID)){
		cout << "该用户已存在！按任意键返回上级菜单。";
		_getch();
		return;
	}
	cout << "请输入新建管理员密码：";
	adminInfo.PWD = input_pwd();
	ofstream fout("admin_user.txt", ios_base::app);
	fout << adminInfo.ID << '\t' << adminInfo.PWD << endl;
	fout.close();
	cout << "新建用户信息已保存，按任意键返回上级菜单。";
	_getch();
	return;
}

void Admin::delete_studentUser(){
	string id;
	cout << "请输入学生学号：";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("student_user.txt", id)) {
		cout << "不存在此用户！按任意键返回上级菜单。";
		_getch();
		return;
	}
	string temp_id, temp_pwd;
	map<string, string> stuUser_map;
	ifstream fin("student_user.txt");
	while (fin){
		fin >> temp_id; fin.get(); fin >> temp_pwd; fin.get();
		if (fin)
			stuUser_map.insert(make_pair(temp_id, temp_pwd));
	}
	fin.close();
	stuUser_map.erase(stuUser_map.find(id));
	ofstream fout("student_user.txt");
	output(stuUser_map.begin(), stuUser_map.end(), fout);
	fout.close();
	cout << "已删除该生账号信息。" << endl;

	StudentInfo stuInfo;
	list<StudentInfo> stuInfo_lst;
	fin.open("student_info.txt");
	while (fin >> stuInfo){
		stuInfo_lst.push_back(stuInfo);
	}
	fin.close();
	stuInfo_lst.remove_if(FindThisStuNumber(id));
	fout.open("student_info.txt");
	output(stuInfo_lst.begin(), stuInfo_lst.end(), fout);
	fout.close();
	cout << "已删除该生基本信息" << endl;

	Reward_Punishment stuPunish;
	list<Reward_Punishment> stuPunish_lst;
	fin.open("reward_punishment.txt");
	while (fin >> stuPunish){
		stuPunish_lst.push_back(stuPunish);
	}
	fin.close();
	stuPunish_lst.remove_if(FindThisStuNumber(id));
	fout.open("reward_punishment.txt");
	output(stuInfo_lst.begin(), stuInfo_lst.end(), fout);
	fout.close();
	cout << "已删除该生奖惩信息" << endl;

	Score stuScore;
	list<Score> stuScore_lst;
	fin.open("score.txt");
	while (fin >> stuScore){
		stuScore_lst.push_back(stuScore);
	}
	fin.close();
	stuScore_lst.remove_if(FindThisStuNumber(id));
	fout.open("score.txt");
	output(stuScore_lst.begin(), stuScore_lst.end(), fout);
	fout.close();
	cout << "已删除该生成绩信息" << endl;
	cout << "该用户所有相关信息已删除，按任意键继续操作。";
	_getch();
	return;
}

void Admin::delete_teacherUser(){
	string id;
	cout << "请输入教师工号：";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("teacher_user.txt", id)) {
		cout << "不存在此用户！按任意键返回上级菜单。";
		_getch();
		return;
	}
	Teacher teacherInfo;
	list<Teacher> teacherInfo_lst;
	ifstream fin("teacher_user.txt");
	while (fin >> teacherInfo){
		teacherInfo_lst.push_back(teacherInfo);
	}
	fin.close();
	teacherInfo_lst.remove_if(FindThisUser(id));
	ofstream fout("teacher_user.txt");
	output(teacherInfo_lst.begin(), teacherInfo_lst.end(), fout);
	fout.close();
	cout << "该用户所有相关信息已删除，按任意键继续操作。";
	_getch();
	return;
}

void Admin::delete_counsellorUser(){
	string id;
	cout << "请输入辅导员工号：";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("counsellor_user.txt", id)) {
		cout << "不存在此用户！按任意键返回上级菜单。";
		_getch();
		return;
	}
	Counsellor counsellorInfo;
	list<Counsellor> counsellorInfo_lst;
	ifstream fin("counsellor_user.txt");
	while (fin >> counsellorInfo){
		counsellorInfo_lst.push_back(counsellorInfo);
	}
	fin.close();
	counsellorInfo_lst.remove_if(FindThisUser(id));
	ofstream fout("counsellor_user.txt");
	output(counsellorInfo_lst.begin(), counsellorInfo_lst.end(), fout);
	fout.close();
	cout << "该用户所有相关信息已删除，按任意键继续操作。";
	_getch();
	return;
}

void Admin::delete_adminUser(){
	string id;
	cout << "请输入管理员帐号：";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("admin_user.txt", id)) {
		cout << "不存在此用户！按任意键返回上级菜单。";
		_getch();
		return;
	}
	string temp_id, temp_pwd;
	map<string, string> admin_map;
	ifstream fin("admin_user.txt");
	while (fin){
		fin >> temp_id; fin.get(); fin >> temp_pwd; fin.get();
		if (fin)
			admin_map.insert(make_pair(temp_id, temp_pwd));
	}
	fin.close();
	admin_map.erase(admin_map.find(id));
	ofstream fout("admin_user.txt");
	output(admin_map.begin(), admin_map.end(), fout);
	fout.close();
	cout << "该用户所有相关信息已删除，按任意键继续操作。";
	_getch();
	return;
}