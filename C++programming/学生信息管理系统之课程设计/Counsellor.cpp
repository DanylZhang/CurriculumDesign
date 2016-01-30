#include "Counsellor.h"

void Counsellor::Login(){
	ifstream fin("counsellor_user.txt");
	if (!fin){
		cout << "文件读取失败！请按任意键继续操作。";
		_getch();
		return;
	}
	Counsellor counsellor;
	map<string, Counsellor> counsellor_map;
	while (fin >> counsellor){
		counsellor_map.insert(make_pair(counsellor.ID, counsellor));
	}
	fin.close();

	string id, pwd;
	do{
		cout << "请输入用户名：";
		cin >> id;
		cin.sync(); cin.clear();
		if (counsellor_map.count(id) == 0)
			cout << "无此用户！请重新输入用户名。" << endl;
		else
			break;
	} while (true);
	do{
		cout << "请输入密码：";
		pwd = input_pwd();
		if (counsellor_map[id].PWD == pwd){
			*this = counsellor_map[id];
			this->Online = true;
			cout << "登录成功!按任意键继续操作。" << endl;
			_getch();
			system("cls");
		}
		else
			cout << "密码错误！请重新输入密码。" << endl;
	} while (!Online);
}

void Counsellor::change_PWD(){
	ifstream fin("counsellor_user.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	Counsellor counsellorInfo;
	list<Counsellor> counsellorInfo_lst;
	while (fin>>counsellorInfo){
		counsellorInfo_lst.push_back(counsellorInfo);
	}
	fin.close();
	find_if(counsellorInfo_lst.begin(), counsellorInfo_lst.end(), FindThisUser(this->ID))->PWD = getNewPWD();
	ofstream fout("counsellor_user.txt");
	output(counsellorInfo_lst.begin(), counsellorInfo_lst.end(), fout);
	fout.close();
	cout << "更改密码成功，请重新选择操作。";
	return;
}

void Counsellor::update_StudentInfo(){
	cout << "请输入学生学号：";
	string stuID; cin >> stuID;	cin.sync(); cin.clear();
	if (!existThisID("student_user.txt", stuID)) {
		cout << "无此学生，不能更改此学生信息！请重新选择操作。";
		return;
	}
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "文件读取失败！按任意键返回上级菜单。";
		_getch();
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
			<< "\n\t\t\t    1、修改学生姓名" << endl
			<< "\n\t\t\t    2、修改学生性别" << endl
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
		case '1':cout << "请输入姓名："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->Name; break;
		case '2':cout << "请输入性别："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->Sex; break;
		case '3':cout << "请输入身份证号："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->IdNumber; break;
		case '4':cout << "请输入电话号码："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->PhoneNumber; break;
		case '5':cout << "请输入家庭住址："; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->Address; break;
		case '6':{ofstream fout("student_info.txt"); output(vectStuInfo.begin(), vectStuInfo.end(), fout); fout.close(); cout << "修改已保存！按任意键返回上级菜单。"; _getch(); flag = false; break; }
		case '7':flag = false; break;
		default:cout << "输入错误！请重新选择："; break;
		}
	} while (flag);
}

void Counsellor::update_StudentPunishment(){
	system("cls");
	Reward_Punishment stuPunish;
	vector<Reward_Punishment> vectStuPunish;
	bool flag1 = true;
	do{
		cout << "请输入学生学号：";
		cin >> stuPunish.stuNumber;	cin.sync(); cin.clear();
		if (!existThisID("student_user.txt", stuPunish.stuNumber)){
			cout << "无此学生，不能为其添加奖惩信息！";
			continue;
		}
		cout << "请输入学生姓名：";
		cin >> stuPunish.Name;
		cin.sync(); cin.clear();
		cout << "请输入奖惩原因：";
		cin >> stuPunish.Reason;
		cin.sync(); cin.clear();
		cout << "请输入奖惩说明：";
		cin >> stuPunish.Remark;
		cin.sync(); cin.clear();
		cout << "请输入处理日期(格式2012-1-1)：";
		bool flag2 = false;
		do{
			try{
				flag2 = false;
				cin >> stuPunish.recordDate;
			}
			catch (exception &e){
				flag2 = true;
				cout << e.what();
				cin.sync(); cin.clear();
			}
		} while (flag2);
		vectStuPunish.push_back(stuPunish);
		cout << "继续添加奖惩信息？（Y）";
		char ch; cin >> ch;
		cin.sync(); cin.clear();
		if (ch == 'y' || ch == 'Y')
			flag1 = true;
		else
			flag1 = false;
	} while (flag1);
	ofstream fout("reward_punishment.txt", ios_base::app);
	output(vectStuPunish.begin(), vectStuPunish.end(), fout);
	fout.close();
	cout << "奖惩信息已保存，按任意键返回上级菜单。";
	_getch();
	return;
}

void Counsellor::query_StudentInfoByID(const string &stuID){
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

void Counsellor::query_StudentInfoByName(const string &stuName){
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

void Counsellor::query_StudentInfo(){
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

void Counsellor::query_StudentScore(){
	ifstream fin("score.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
		return;
	}
	bool flag = true;
	do{
		cout << "请输入要查询成绩的学号：";
		string id; cin >> id;	cin.sync(); cin.clear();
		if (!existThisID("student_user.txt", id)){
			cout << "无此学生，查询成绩失败！";
			continue;
		}
		system("cls");
		Score stuScore;
		set<Score> stuScore_set;
		while (fin >> stuScore){
			if (stuScore.stuNumber == id)
				stuScore_set.insert(stuScore);
		}
		fin.close();
		cout << id << "的成绩信息：\n\n课程\t\t\t成绩\n\n";
		for (auto i : stuScore_set){
			cout << i.Subject << "\t\t" << i.mScore << endl<<endl;
		}
		cout << "继续查询成绩？（Y）";
		char ch;
		cin >> ch;
		cin.sync(); cin.clear();
		if (ch == 'y' || ch == 'Y')
			flag = true;
		else
			flag = false;
	} while (flag);
}

void Counsellor::query_StudentPunishment(){
	ifstream fin("reward_punishment.txt");
	if (!fin){
		cout << "文件读取失败！请重新选择操作。";
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