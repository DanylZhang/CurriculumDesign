#include "Counsellor.h"

void Counsellor::Login(){
	ifstream fin("counsellor_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ��밴���������������";
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
		cout << "�������û�����";
		cin >> id;
		cin.sync(); cin.clear();
		if (counsellor_map.count(id) == 0)
			cout << "�޴��û��������������û�����" << endl;
		else
			break;
	} while (true);
	do{
		cout << "���������룺";
		pwd = input_pwd();
		if (counsellor_map[id].PWD == pwd){
			*this = counsellor_map[id];
			this->Online = true;
			cout << "��¼�ɹ�!�����������������" << endl;
			_getch();
			system("cls");
		}
		else
			cout << "��������������������롣" << endl;
	} while (!Online);
}

void Counsellor::change_PWD(){
	ifstream fin("counsellor_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
	cout << "��������ɹ���������ѡ�������";
	return;
}

void Counsellor::update_StudentInfo(){
	cout << "������ѧ��ѧ�ţ�";
	string stuID; cin >> stuID;	cin.sync(); cin.clear();
	if (!existThisID("student_user.txt", stuID)) {
		cout << "�޴�ѧ�������ܸ��Ĵ�ѧ����Ϣ��������ѡ�������";
		return;
	}
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������������ϼ��˵���";
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
		cout << "\n\t\t\t��� ��Уѧ������ϵͳ ���" << endl
			<< "\t\t\t\t\t\t\t\t" << this->ID << " �ѵ�¼" << endl
			<< "\n\t\t\t    1���޸�ѧ������" << endl
			<< "\n\t\t\t    2���޸�ѧ���Ա�" << endl
			<< "\n\t\t\t    3���޸����֤��" << endl
			<< "\n\t\t\t    4���޸ĵ绰����" << endl
			<< "\n\t\t\t    5���޸ļ�ͥסַ" << endl
			<< "\n\t\t\t    6�����沢���ز˵�" << endl
			<< "\n\t\t\t    7��ȡ�����Ĳ����ز˵�" << endl
			<< "\n��ѡ�� 1~7: ";
		char ch;
		cin >> ch;
		cin.sync(); cin.clear();
		switch (ch)
		{
		case '1':cout << "������������"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->Name; break;
		case '2':cout << "�������Ա�"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->Sex; break;
		case '3':cout << "���������֤�ţ�"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->IdNumber; break;
		case '4':cout << "������绰���룺"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->PhoneNumber; break;
		case '5':cout << "�������ͥסַ��"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(stuID))->Address; break;
		case '6':{ofstream fout("student_info.txt"); output(vectStuInfo.begin(), vectStuInfo.end(), fout); fout.close(); cout << "�޸��ѱ��棡������������ϼ��˵���"; _getch(); flag = false; break; }
		case '7':flag = false; break;
		default:cout << "�������������ѡ��"; break;
		}
	} while (flag);
}

void Counsellor::update_StudentPunishment(){
	system("cls");
	Reward_Punishment stuPunish;
	vector<Reward_Punishment> vectStuPunish;
	bool flag1 = true;
	do{
		cout << "������ѧ��ѧ�ţ�";
		cin >> stuPunish.stuNumber;	cin.sync(); cin.clear();
		if (!existThisID("student_user.txt", stuPunish.stuNumber)){
			cout << "�޴�ѧ��������Ϊ����ӽ�����Ϣ��";
			continue;
		}
		cout << "������ѧ��������";
		cin >> stuPunish.Name;
		cin.sync(); cin.clear();
		cout << "�����뽱��ԭ��";
		cin >> stuPunish.Reason;
		cin.sync(); cin.clear();
		cout << "�����뽱��˵����";
		cin >> stuPunish.Remark;
		cin.sync(); cin.clear();
		cout << "�����봦������(��ʽ2012-1-1)��";
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
		cout << "������ӽ�����Ϣ����Y��";
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
	cout << "������Ϣ�ѱ��棬������������ϼ��˵���";
	_getch();
	return;
}

void Counsellor::query_StudentInfoByID(const string &stuID){
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

void Counsellor::query_StudentInfoByName(const string &stuName){
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

void Counsellor::query_StudentInfo(){
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

void Counsellor::query_StudentScore(){
	ifstream fin("score.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
		return;
	}
	bool flag = true;
	do{
		cout << "������Ҫ��ѯ�ɼ���ѧ�ţ�";
		string id; cin >> id;	cin.sync(); cin.clear();
		if (!existThisID("student_user.txt", id)){
			cout << "�޴�ѧ������ѯ�ɼ�ʧ�ܣ�";
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
		cout << id << "�ĳɼ���Ϣ��\n\n�γ�\t\t\t�ɼ�\n\n";
		for (auto i : stuScore_set){
			cout << i.Subject << "\t\t" << i.mScore << endl<<endl;
		}
		cout << "������ѯ�ɼ�����Y��";
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
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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