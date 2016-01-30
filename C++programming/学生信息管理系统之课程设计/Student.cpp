#include "Student.h"

void Student::Login(){
	ifstream fin("student_user.txt");
	if (!fin){
		cout << "文件读取失败！请按任意键继续操作。";
		_getch();
		return;
	}
	string id, pwd;
	map<string, string> student_map;
	while (fin){
		fin >> id; fin.get(); fin >> pwd; fin.get();
		if (fin)
			student_map.insert(make_pair(id, pwd));
	}
	fin.close();
	do{
		cout << "请输入学号：";
		cin >> id;
		cin.sync(); cin.clear();
		if (student_map.count(id) == 0)
			cout << "无此用户！请重新输入学号。" << endl;
		else
			break;
	} while (true);
	do{
		cout << "请输入密码：";
		pwd = input_pwd();
		if (student_map[id] == pwd){
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

void Student::change_PWD(){
	ifstream fin("student_user.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	string temp_id, temp_pwd;
	map<string, string> stuUser_map;
	while (fin){
		fin >> temp_id; fin.get(); fin >> temp_pwd; fin.get();
		if (fin)
			stuUser_map.insert(make_pair(temp_id, temp_pwd));
	}
	fin.close();
	stuUser_map[this->ID] = getNewPWD();
	ofstream fout("student_user.txt");
	output(stuUser_map.begin(), stuUser_map.end(), fout);
	fout.close();
	cout << "更改密码成功，请重新选择操作。";
	return;
}

void Student::updata_Info(){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	StudentInfo stuInfo;
	vector<StudentInfo> vectStuInfo;
	while (fin >> stuInfo){
		vectStuInfo.push_back(stuInfo);
	}
	fin.close();
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t☆☆ 高校学籍管理系统 ☆☆" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " 已登录" << endl
			<< "\n\t\t\t    1、修改姓名" << endl
			<< "\n\t\t\t    2、修改性别" << endl
			<< "\n\t\t\t    3、修改身份证号" << endl
			<< "\n\t\t\t    4、修改电话号码" << endl
			<< "\n\t\t\t    5、修改家庭住址" << endl
			<< "\n\t\t\t    6、保存并返回菜单" << endl
			<< "\n\t\t\t    7、取消更改并返回菜单" << endl
			<< "\n请选择 1~7: ";
		char ch;
		cin >> ch;
		cin.sync(); cin.clear();
		switch (ch)
		{
		case '1':cout << "请输入姓名："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->Name; break;
		case '2':cout << "请输入性别："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->Sex; break;
		case '3':cout << "请输入身份证号："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->IdNumber; break;
		case '4':cout << "请输入电话号码："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->PhoneNumber; break;
		case '5':cout << "请输入家庭住址："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->Address; break;
		case '6':{ofstream fout("student_info.txt"); output(vectStuInfo.begin(), vectStuInfo.end(), fout); fout.close(); cout << "修改已保存！按任意键返回菜单。"; _getch(); flag = false; break; }
		case '7':flag = false; break;
		default:cout << "输入错误！请重新选择："; break;
		}
	} while (flag);
}

void Student::query_Info(){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	StudentInfo stuInfo;
	while (fin >> stuInfo){
		if (stuInfo.stuNumber == this->ID)//找到当前登录用户的记录则跳出
			break;
	}
	fin.close();
	if (stuInfo.stuNumber != this->ID)
		cout << "未找到学生信息！";
	else
		stuInfo.print();
	cout << "\n按任意键返回菜单。" << endl;
	_getch();
	return;
}

void Student::query_Score(){
	ifstream fin("score.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	system("cls");
	Score stuScore;
	set<Score> stuScore_set;
	while (fin >> stuScore){
		if (stuScore.stuNumber == this->ID)
			stuScore_set.insert(stuScore);
	}
	fin.close();
	cout << "课程\t\t\t成绩\n\n";
	for (auto i : stuScore_set){
		cout << i.Subject << "\t\t" << i.mScore << endl<<endl;
	}
	cout << "按任意键返回上级菜单";
	_getch();
	return;
}

void Student::query_Punishment(){
	ifstream fin("reward_punishment.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	Reward_Punishment stuPunish;
	vector<Reward_Punishment> vectstuPunish;
	while (fin >> stuPunish){
		if (stuPunish.stuNumber != this->ID)
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