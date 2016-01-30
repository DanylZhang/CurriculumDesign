#ifndef TEACHER_H
#define TEACHER_H
#include "User.h"
#include "Score.h"
#include "StudentInfo.h"
#include "Reward_Punishment.h"

class Teacher :public User{
public:
	string Department;						//��λ/ѧԺ
	string Class;							//�༶
	string Subject;							//�γ�
private:
	void query_StudentInfoByID(const string &stuID);			//��ѧ�Ų�ѯ
	void query_StudentInfoByName(const string &stuName);		//��������ѯ
public:
	Teacher(){}
	Teacher(const Teacher &teacher){
	ID = teacher.ID;
	PWD = teacher.PWD;
	Department=teacher.Department;
	Class=teacher.Class;
	Subject=teacher.Subject;
	}
	~Teacher(){}

	void Login();
	void change_PWD();
	void add_Score();
	//��ӳɼ�
	void query_StudentInfo();
	//��ѯ���ݿ���Ϣ
	void query_StudentScore();
	//��ѯ�ɼ���Ϣ
	void query_StudentPunishment();
	//��ѯ������Ϣ
	friend ostream &operator<<(ostream &out, const Teacher &teacher){
		return out << teacher.ID << '\t'
			<< teacher.PWD << '\t'
			<< teacher.Department << '\t'
			<< teacher.Class << '\t'
			<< teacher.Subject;
	}
	friend istream &operator>>(istream &in, Teacher &teacher) {
		in >> teacher.ID; in.get();
		in >> teacher.PWD; in.get();
		in >> teacher.Department; in.get();
		in >> teacher.Class; in.get();
		in >> teacher.Subject; in.get();
		return in;
	}
};

#endif //TEACHER_H