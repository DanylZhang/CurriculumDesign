#ifndef STUDENT_H
#define STUDENT_H
#include "User.h"
#include "Score.h"
#include "StudentInfo.h"
#include "Reward_Punishment.h"

class Student :public User{
public:
	Student(){}
	~Student(){}

	void Login();
	void change_PWD();
	void updata_Info();
	void query_Info();
	void query_Score();
	void query_Punishment();
};

#endif //STUDENT_H