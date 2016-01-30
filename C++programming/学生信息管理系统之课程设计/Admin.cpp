#include "Admin.h"

void Admin::Login(){
	ifstream fin("admin_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ��밴���������������";
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
		cout << "�������û�����";
		cin >> id;
		cin.sync();cin.clear();
		if (admin_map.count(id) == 0)
			cout << "�޴��û��������������û�����" << endl;
		else
			break;
	} while (true);
	do{
		cout << "���������룺";
		pwd = input_pwd();
		if (admin_map[id] == pwd){
			this->ID = id;
			this->PWD = pwd;
			this->Online = true;
			cout << "��¼�ɹ�!�����������������" << endl;
			_getch();
			system("cls");
		}
		else
			cout << "��������������������롣" << endl;
	} while (!Online);
}

void Admin::change_PWD(){
	ifstream fin("admin_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
	cout << "��������ɹ���������ѡ�������";
	return;
}

void Admin::backup_Data(){
	system("explorer");
	cout << "�����ѱ��ݣ��������������";
	_getch();
	return;
}

void Admin::recovery_Data(){
	system("explorer");
	cout << "�����ѻָ����������������";
	_getch();
	return;
}

void Admin::add_User(){
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " �ѵ�¼" << endl
			<< "\n\t\t\t    1�����ѧ���˻�" << endl
			<< "\n\t\t\t    2����ӽ�ʦ�˻�" << endl
			<< "\n\t\t\t    3����Ӹ���Ա�˻�" << endl
			<< "\n\t\t\t    4�����ϵͳ����Ա�˻�" << endl
			<< "\n\t\t\t    5�������ϼ��˵�" << endl
			<< "\n��ѡ�� 1~5: ";
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
		default:cout << "�������������ѡ��"; break;
		}
	} while (flag);
}

void Admin::delete_User(){
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " �ѵ�¼" << endl
			<< "\n\t\t\t    1��ɾ��ѧ���˻�" << endl
			<< "\n\t\t\t    2��ɾ����ʦ�˻�" << endl
			<< "\n\t\t\t    3��ɾ������Ա�˻�" << endl
			<< "\n\t\t\t    4��ɾ��ϵͳ����Ա�˻�" << endl
			<< "\n\t\t\t    5�������ϼ��˵�" << endl
			<< "\n��ѡ�� 1~5: ";
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
		default:cout << "�������������ѡ��"; break;
		}
	} while (flag);
}

void Admin::add_studentUser(){
	system("cls");
	StudentInfo stuInfo;
	cout << "������ѧ��ѧ�ţ�";
	cin >> stuInfo.stuNumber;
	cin.sync();cin.clear();
	if (existThisID("student_user.txt", stuInfo.stuNumber)){
		cout << "���û��Ѵ��ڣ�������������ϼ��˵���";
		_getch();
		return;
	}
	stuInfo.Name = "δ��";
	stuInfo.Sex = "δ��";
	cout << "��������ѧ����(��ʽ2012-1-1)��";
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
	cout << "�������Ƿ�ʦ������";
	cin >> stuInfo.NormalMajor;
	cin.sync();cin.clear();
	cout << "����������ѧԺ��";
	cin >> stuInfo.Department;
	cin.sync();cin.clear();
	cout << "������רҵ��";
	cin >> stuInfo.Major;
	cin.sync();cin.clear();
	cout << "������༶��";
	cin >> stuInfo.Class;
	cin.sync();cin.clear();
	stuInfo.IdNumber = "δ��";
	stuInfo.PhoneNumber = "δ��";
	stuInfo.Address = "δ��";
	ofstream fout("student_user.txt", ios_base::app);
	fout << stuInfo.stuNumber << '\t' << stuInfo.intendTime.getYear() << stuInfo.intendTime.getMonth() << endl;
	fout.close();
	fout.open("student_info.txt", ios_base::app);
	fout << stuInfo << endl;
	fout.close();
	cout << "�½��û���Ϣ�ѱ��棬������������ϼ��˵���";
	_getch();
	return;
}

void Admin::add_teacherUser(){
	system("cls");
	Teacher teacherInfo;
	vector<Teacher> vectTeacherInfo;
	bool flag = true;
	do{
		cout << "�������ʦ���ţ�";
		cin >> teacherInfo.ID;
		cin.sync();cin.clear();
		if (existThisID("teacher_user.txt", teacherInfo.ID)){
			cout << "���û��Ѵ��ڣ�";
			continue;
		}
		cout << "�������ʦ���룺";
		teacherInfo.PWD = input_pwd();
		cout << "������������ѧ��λ��";
		cin >> teacherInfo.Department;
		cin.sync(); cin.clear();
		cout << "������༶��";
		cin >> teacherInfo.Class;
		cin.sync();cin.clear();
		cout << "��������ڿ�Ŀ��";
		cin >> teacherInfo.Subject;
		cin.sync();cin.clear();
		vectTeacherInfo.push_back(teacherInfo);
		cout << "������ӽ�ʦ�û�����Y��";
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
	cout << "�½��û���Ϣ�ѱ��棬������������ϼ��˵���";
	_getch();
	return;
}

void Admin::add_counsellorUser(){
	system("cls");
	Counsellor counsellorInfo;
	vector<Counsellor> vectCounsellorInfo;
	bool flag = true;
	do{
		cout << "�����븨��Ա���ţ�";
		cin >> counsellorInfo.ID;
		cin.sync();cin.clear();
		if (existThisID("counsellor_user.txt", counsellorInfo.ID)){
			cout << "���û��Ѵ��ڣ�";
			continue;
		}
		cout << "�����븨��Ա���룺";
		counsellorInfo.PWD = input_pwd();
		cout << "������������ѧ��λ��";
		cin >> counsellorInfo.Department;
		cin.sync();cin.clear();
		cout << "���������༶��";
		cin >> counsellorInfo.Class;
		cin.sync();cin.clear();
		vectCounsellorInfo.push_back(counsellorInfo);
		cout << "������Ӹ���Ա�û�����Y��";
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
	cout << "�½��û���Ϣ�ѱ��棬������������ϼ��˵���";
	_getch();
	return;
}

void Admin::add_adminUser(){
	system("cls");
	Admin adminInfo;
	cout << "���������Ա��¼����";
	cin >> adminInfo.ID;
	cin.sync();cin.clear();
	if (existThisID("admin_user.txt", adminInfo.ID)){
		cout << "���û��Ѵ��ڣ�������������ϼ��˵���";
		_getch();
		return;
	}
	cout << "�������½�����Ա���룺";
	adminInfo.PWD = input_pwd();
	ofstream fout("admin_user.txt", ios_base::app);
	fout << adminInfo.ID << '\t' << adminInfo.PWD << endl;
	fout.close();
	cout << "�½��û���Ϣ�ѱ��棬������������ϼ��˵���";
	_getch();
	return;
}

void Admin::delete_studentUser(){
	string id;
	cout << "������ѧ��ѧ�ţ�";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("student_user.txt", id)) {
		cout << "�����ڴ��û���������������ϼ��˵���";
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
	cout << "��ɾ�������˺���Ϣ��" << endl;

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
	cout << "��ɾ������������Ϣ" << endl;

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
	cout << "��ɾ������������Ϣ" << endl;

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
	cout << "��ɾ�������ɼ���Ϣ" << endl;
	cout << "���û����������Ϣ��ɾ���������������������";
	_getch();
	return;
}

void Admin::delete_teacherUser(){
	string id;
	cout << "�������ʦ���ţ�";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("teacher_user.txt", id)) {
		cout << "�����ڴ��û���������������ϼ��˵���";
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
	cout << "���û����������Ϣ��ɾ���������������������";
	_getch();
	return;
}

void Admin::delete_counsellorUser(){
	string id;
	cout << "�����븨��Ա���ţ�";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("counsellor_user.txt", id)) {
		cout << "�����ڴ��û���������������ϼ��˵���";
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
	cout << "���û����������Ϣ��ɾ���������������������";
	_getch();
	return;
}

void Admin::delete_adminUser(){
	string id;
	cout << "���������Ա�ʺţ�";
	cin >> id;
	cin.sync(); cin.clear();
	if (!existThisID("admin_user.txt", id)) {
		cout << "�����ڴ��û���������������ϼ��˵���";
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
	cout << "���û����������Ϣ��ɾ���������������������";
	_getch();
	return;
}