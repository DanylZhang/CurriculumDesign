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
	//�½��û�
	void delete_User();
	//ɾ���û�
	void backup_Data();
	//���ݵ�ǰ���ݿ�����
	void recovery_Data();
	//���ݻָ�
};

#endif //ADMIN_H