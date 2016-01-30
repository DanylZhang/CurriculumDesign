#ifndef COUNSELLOR_H
#define COUNSELLOR_H
#include "User.h"
#include "Score.h"
#include "StudentInfo.h"
#include "Reward_Punishment.h"

class Counsellor :public User{
public:
	string Department;						//��λ/ѧԺ
	string Class;							//�༶
private:
	void query_StudentInfoByID(const string &stuID);			//��ѧ�Ų�ѯ
	void query_StudentInfoByName(const string &stuName);		//��������ѯ
public:
	Counsellor(){}
	Counsellor(const Counsellor &counsellor){
		ID = counsellor.ID;
		PWD = counsellor.PWD;
		Department=counsellor.Department;
		Class=counsellor.Class;
	}
	~Counsellor(){}

	void Login();
	void change_PWD();
	void query_StudentInfo();
	//��ѯѧ��
	void query_StudentScore();
	//��ѯѧ���ɼ�
	void query_StudentPunishment();
	//��ѯ������Ϣ
	void update_StudentInfo();
	//����ѧ��������Ϣ
	void update_StudentPunishment();
	//���½�����Ϣ
	friend ostream &operator<<(ostream &out, const Counsellor &counsellor){
		return out << counsellor.ID << '\t'
			<< counsellor.PWD << '\t'
			<< counsellor.Department << '\t'
			<< counsellor.Class;
	}
	friend istream &operator>>(istream &in, Counsellor &counsellor) {
		in >> counsellor.ID; in.get();
		in >> counsellor.PWD; in.get();
		in >> counsellor.Department; in.get();
		in >> counsellor.Class; in.get();
		return in;
	}
};

#endif //COUNSELLOR_H