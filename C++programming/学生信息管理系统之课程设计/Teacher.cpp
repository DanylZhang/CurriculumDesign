#include "Teacher.h"

void Teacher::Login(){
	ifstream fin("teacher_user.txt");
	if (!fin){
		cout << "文件读取失败！请按任意键继续操作。";
		_getch();
		return;
	}
	Teacher teacher;
	map<string, Teacher> teacher_map;
	while (fin >> teacher){
		teacher_map.insert(make_pair(teacher.ID, teacher));
	}
	fin.close();

	string id, pwd;
	do{
		cout << "请输入用户名：";
		cin >> id;
		cin.sync(); cin.clear();
		if (teacher_map.count(id) == 0)
			cout << "无此用户！请重新输入用户名。" << endl;
		else
			break;
	} while (true);
	do{
		cout << "请输入密码：";
		pwd = input_pwd();
		if (teacher_map[id].PWD == pwd){
			*this = teacher_map[id];
			this->Online = true;
			cout << "登录成功!按任意键继续操作。" << endl;
			_getch();
			system("cls");
		}
		else
			cout << "密码错误！请重新输入密码。" << endl;
	} while (!Online);
}

void Teacher::change_PWD(){
	ifstream fin("teacher_user.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	Teacher teacherInfo;
	list<Teacher> teacherInfo_lst;
	while (fin >> teacherInfo){
		teacherInfo_lst.push_back(teacherInfo);
	}
	fin.close();
	find_if(teacherInfo_lst.begin(), teacherInfo_lst.end(), FindThisUser(this->ID))->PWD = getNewPWD();
	ofstream fout("teacher_user.txt");
	output(teacherInfo_lst.begin(), teacherInfo_lst.end(), fout);
	fout.close();
	cout << "更改密码成功，请重新选择操作。";
	return;
}

void Teacher::query_StudentInfoByID(const string &stuID){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	StudentInfo stuInfo;
	while (fin >> stuInfo){
		if (stuInfo.stuNumber == stuID)//找到记录则跳出
			break;
	}
	fin.close();
	if (stuInfo.stuNumber != stuID)
		cout << "未找到学生信息！";
	else
		stuInfo.print();
	cout << "\n按任意键返回菜单。" << endl;
	_getch();
	return;
}

void Teacher::query_StudentInfoByName(const string &stuName){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	StudentInfo stuInfo;
	while (fin >> stuInfo){
		if (stuInfo.Name == stuName)//找到记录则跳出
			break;
	}
	fin.close();
	if (stuInfo.Name != stuName)
		cout << "未找到学生信息！";
	else
		stuInfo.print();
	cout << "\n按任意键返回菜单。" << endl;
	_getch();
	return;
}

void Teacher::add_Score(){
	Score stuScore;
	set<Score> stuScore_set;
	bool flag = true;
	do{
		cout << "请输入考生学号：";
		cin >> stuScore.stuNumber;
		cin.sync(); cin.clear();
		if (!existThisID("student_user.txt", stuScore.stuNumber)){
			cout << "无此学生，不能为其添加考试成绩！";
			continue;
		}
		stuScore.Subject = this->Subject;
		cout << "请输入成绩：";
		cin >> stuScore.mScore;
		cin.sync(); cin.clear();
		stuScore_set.insert(stuScore);
		cout << "继续添加考试成绩？（Y）";
		char ch; cin >> ch;
		cin.sync(); cin.clear();
		if (ch == 'y'||ch=='Y')
			flag = true;
		else
			flag = false;
	} while (flag);
	ofstream fout("score.txt", ios_base::app);
	output(stuScore_set.begin(), stuScore_set.end(), fout);
	fout.close();
	cout << "成绩已成功保存，请重新选择操作。";
	_getch();
	return;
}

void Teacher::query_StudentInfo(){
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " 已登录" << endl
			<< "\n\t\t\t\t1、按学号查询" << endl
			<< "\n\t\t\t\t2、按姓名查询" << endl
			<< "\n\t\t\t\t3、返回菜单" << endl
			<< "\n请选择 1~3: ";
		char ch;
		cin >> ch;
		cin.sync(); cin.clear();
		switch (ch)
		{
		case '1':{cout << "请输入要查询的学生学号："; string stuID; cin >> stuID; query_StudentInfoByID(stuID); break; }
		case '2':{cout << "请输入要查询的学生姓名：";  string stuName; cin >> stuName; query_StudentInfoByName(stuName); break; }
		case '3':flag = false; break;
		default:cout << "输入错误！请重新选择："; break;
		}
	} while (flag);
}

void Teacher::query_StudentScore(){
	ifstream fin("score.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	system("cls");
	Score stuScore;
	set<Score> stuScore_set;
	while (fin >> stuScore){
		if (stuScore.Subject == this->Subject)
			stuScore_set.insert(stuScore);
	}
	fin.close();
	cout << "  学号\t课程\t\t成绩\n";
	output(stuScore_set.begin(), stuScore_set.end(), cout);
	cout << "按任意键返回上级菜单";
	_getch();
	return;
}

void Teacher::query_StudentPunishment(){
	ifstream fin("reward_punishment.txt");
	if (!fin){
		cout << "文件读取失败！按任意键返回主菜单。";
		_getch();
		return;
	}
	Reward_Punishment stuPunish;
	vector<Reward_Punishment> vectstuPunish;
	string stuID;
	cout << "请输入学生的学号："; cin >> stuID;
	cin.sync(); cin.clear();
	while (fin >> stuPunish){
		if (stuPunish.stuNumber != stuID)
			continue;
		vectstuPunish.push_back(stuPunish);
	}
	fin.close();
	if (vectstuPunish.size() == 0){
		system("cls");
		cout << "暂没奖惩信息！";
	}
	else{
		system("cls");
		cout << "\n\t\t  学号\t  姓名\t  原因\t  处理\t  处理日期\n";
		output(vectstuPunish.begin(), vectstuPunish.end(), cout, "\n\t\t");
	}
	cout << "\n按任意键返回菜单。" << endl;
	_getch();
	return;
}