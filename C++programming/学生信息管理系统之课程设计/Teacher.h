#ifndef TEACHER_H
#define TEACHER_H
#include "User.h"
#include "Score.h"
#include "StudentInfo.h"
#include "Reward_Punishment.h"

class Teacher :public User{
public:
	string Department;						//单位/学院
	string Class;							//班级
	string Subject;							//课程
private:
	void query_StudentInfoByID(const string &stuID);			//按学号查询
	void query_StudentInfoByName(const string &stuName);		//按姓名查询
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
	//添加成绩
	void query_StudentInfo();
	//查询数据库信息
	void query_StudentScore();
	//查询成绩信息
	void query_StudentPunishment();
	//查询奖惩信息
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