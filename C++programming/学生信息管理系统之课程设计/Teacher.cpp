#include "Teacher.h"

void Teacher::Login(){
	ifstream fin("teacher_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ��밴���������������";
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
		cout << "�������û�����";
		cin >> id;
		cin.sync(); cin.clear();
		if (teacher_map.count(id) == 0)
			cout << "�޴��û��������������û�����" << endl;
		else
			break;
	} while (true);
	do{
		cout << "���������룺";
		pwd = input_pwd();
		if (teacher_map[id].PWD == pwd){
			*this = teacher_map[id];
			this->Online = true;
			cout << "��¼�ɹ�!�����������������" << endl;
			_getch();
			system("cls");
		}
		else
			cout << "��������������������롣" << endl;
	} while (!Online);
}

void Teacher::change_PWD(){
	ifstream fin("teacher_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
	cout << "��������ɹ���������ѡ�������";
	return;
}

void Teacher::query_StudentInfoByID(const string &stuID){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
		return;
	}
	StudentInfo stuInfo;
	while (fin >> stuInfo){
		if (stuInfo.stuNumber == stuID)//�ҵ���¼������
			break;
	}
	fin.close();
	if (stuInfo.stuNumber != stuID)
		cout << "δ�ҵ�ѧ����Ϣ��";
	else
		stuInfo.print();
	cout << "\n����������ز˵���" << endl;
	_getch();
	return;
}

void Teacher::query_StudentInfoByName(const string &stuName){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
		return;
	}
	StudentInfo stuInfo;
	while (fin >> stuInfo){
		if (stuInfo.Name == stuName)//�ҵ���¼������
			break;
	}
	fin.close();
	if (stuInfo.Name != stuName)
		cout << "δ�ҵ�ѧ����Ϣ��";
	else
		stuInfo.print();
	cout << "\n����������ز˵���" << endl;
	_getch();
	return;
}

void Teacher::add_Score(){
	Score stuScore;
	set<Score> stuScore_set;
	bool flag = true;
	do{
		cout << "�����뿼��ѧ�ţ�";
		cin >> stuScore.stuNumber;
		cin.sync(); cin.clear();
		if (!existThisID("student_user.txt", stuScore.stuNumber)){
			cout << "�޴�ѧ��������Ϊ����ӿ��Գɼ���";
			continue;
		}
		stuScore.Subject = this->Subject;
		cout << "������ɼ���";
		cin >> stuScore.mScore;
		cin.sync(); cin.clear();
		stuScore_set.insert(stuScore);
		cout << "������ӿ��Գɼ�����Y��";
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
	cout << "�ɼ��ѳɹ����棬������ѡ�������";
	_getch();
	return;
}

void Teacher::query_StudentInfo(){
	bool flag = true;
	do{
		system("cls");
		cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " �ѵ�¼" << endl
			<< "\n\t\t\t\t1����ѧ�Ų�ѯ" << endl
			<< "\n\t\t\t\t2����������ѯ" << endl
			<< "\n\t\t\t\t3�����ز˵�" << endl
			<< "\n��ѡ�� 1~3: ";
		char ch;
		cin >> ch;
		cin.sync(); cin.clear();
		switch (ch)
		{
		case '1':{cout << "������Ҫ��ѯ��ѧ��ѧ�ţ�"; string stuID; cin >> stuID; query_StudentInfoByID(stuID); break; }
		case '2':{cout << "������Ҫ��ѯ��ѧ��������";  string stuName; cin >> stuName; query_StudentInfoByName(stuName); break; }
		case '3':flag = false; break;
		default:cout << "�������������ѡ��"; break;
		}
	} while (flag);
}

void Teacher::query_StudentScore(){
	ifstream fin("score.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
	cout << "  ѧ��\t�γ�\t\t�ɼ�\n";
	output(stuScore_set.begin(), stuScore_set.end(), cout);
	cout << "������������ϼ��˵�";
	_getch();
	return;
}

void Teacher::query_StudentPunishment(){
	ifstream fin("reward_punishment.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ���������������˵���";
		_getch();
		return;
	}
	Reward_Punishment stuPunish;
	vector<Reward_Punishment> vectstuPunish;
	string stuID;
	cout << "������ѧ����ѧ�ţ�"; cin >> stuID;
	cin.sync(); cin.clear();
	while (fin >> stuPunish){
		if (stuPunish.stuNumber != stuID)
			continue;
		vectstuPunish.push_back(stuPunish);
	}
	fin.close();
	if (vectstuPunish.size() == 0){
		system("cls");
		cout << "��û������Ϣ��";
	}
	else{
		system("cls");
		cout << "\n\t\t  ѧ��\t  ����\t  ԭ��\t  ����\t  ��������\n";
		output(vectstuPunish.begin(), vectstuPunish.end(), cout, "\n\t\t");
	}
	cout << "\n����������ز˵���" << endl;
	_getch();
	return;
}