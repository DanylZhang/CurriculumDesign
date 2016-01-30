#include "Student.h"

void Student::Login(){
	ifstream fin("student_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ��밴���������������";
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
		cout << "������ѧ�ţ�";
		cin >> id;
		cin.sync(); cin.clear();
		if (student_map.count(id) == 0)
			cout << "�޴��û�������������ѧ�š�" << endl;
		else
			break;
	} while (true);
	do{
		cout << "���������룺";
		pwd = input_pwd();
		if (student_map[id] == pwd){
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

void Student::change_PWD(){
	ifstream fin("student_user.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
	cout << "��������ɹ���������ѡ�������";
	return;
}

void Student::updata_Info(){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
			<< "\n\t\t\t    1���޸�����" << endl
			<< "\n\t\t\t    2���޸��Ա�" << endl
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
		case '1':cout << "������������"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->Name; break;
		case '2':cout << "�������Ա�"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->Sex; break;
		case '3':cout << "���������֤�ţ�"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->IdNumber; break;
		case '4':cout << "������绰���룺"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->PhoneNumber; break;
		case '5':cout << "�������ͥסַ��"; cin >> find_if(vectStuInfo.begin(), vectStuInfo.end(), FindThisStuNumber(this->ID))->Address; break;
		case '6':{ofstream fout("student_info.txt"); output(vectStuInfo.begin(), vectStuInfo.end(), fout); fout.close(); cout << "�޸��ѱ��棡����������ز˵���"; _getch(); flag = false; break; }
		case '7':flag = false; break;
		default:cout << "�������������ѡ��"; break;
		}
	} while (flag);
}

void Student::query_Info(){
	ifstream fin("student_info.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
		return;
	}
	StudentInfo stuInfo;
	while (fin >> stuInfo){
		if (stuInfo.stuNumber == this->ID)//�ҵ���ǰ��¼�û��ļ�¼������
			break;
	}
	fin.close();
	if (stuInfo.stuNumber != this->ID)
		cout << "δ�ҵ�ѧ����Ϣ��";
	else
		stuInfo.print();
	cout << "\n����������ز˵���" << endl;
	_getch();
	return;
}

void Student::query_Score(){
	ifstream fin("score.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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
	cout << "�γ�\t\t\t�ɼ�\n\n";
	for (auto i : stuScore_set){
		cout << i.Subject << "\t\t" << i.mScore << endl<<endl;
	}
	cout << "������������ϼ��˵�";
	_getch();
	return;
}

void Student::query_Punishment(){
	ifstream fin("reward_punishment.txt");
	if (!fin){
		cout << "�ļ���ȡʧ�ܣ�������ѡ�������";
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