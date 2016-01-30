#ifndef COUNSELLOR_H
#define COUNSELLOR_H
#include "User.h"
#include "Score.h"
#include "StudentInfo.h"
#include "Reward_Punishment.h"

class Counsellor :public User{
public:
	string Department;						//单位/学院
	string Class;							//班级
private:
	void query_StudentInfoByID(const string &stuID);			//按学号查询
	void query_StudentInfoByName(const string &stuName);		//按姓名查询
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
	//查询学生
	void query_StudentScore();
	//查询学生成绩
	void query_StudentPunishment();
	//查询奖惩信息
	void update_StudentInfo();
	//更新学生基本信息
	void update_StudentPunishment();
	//更新奖惩信息
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