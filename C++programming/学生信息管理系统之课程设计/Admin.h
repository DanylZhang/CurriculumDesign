#ifndef ADMIN_H
#define ADMIN_H
#include "User.h"
#include "StudentInfo.h"
#include "Teacher.h"
#include "Counsellor.h"

class Admin:public User{
private:
	void add_studentUser();
	void add_teacherUser();
	void add_counsellorUser();
	void add_adminUser();
	void delete_studentUser();
	void delete_teacherUser();
	void delete_counsellorUser();
	void delete_adminUser();
public:
	Admin(){}
	~Admin(){}

	void Login();
	void change_PWD();
	void add_User();
	//新建用户
	void delete_User();
	//删除用户
	void backup_Data();
	//备份当前数据库数据
	void recovery_Data();
	//数据恢复
};

#endif //ADMIN_H