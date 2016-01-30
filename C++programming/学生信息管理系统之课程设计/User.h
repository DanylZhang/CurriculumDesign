#ifndef USER_H
#define USER_H
#include <iostream>
#include <fstream>
#include <string>
#include <stdexcept>
#include <vector>
#include <list>
#include <set>
#include <map>
#include <algorithm>
#include <conio.h>
#include "FindThisUser.h"
#include "FindThisStuNumber.h"
using namespace std;

class User{
public:
	string ID;					//用户名
	string PWD;					//密码
	bool Online = false;		//在线状态

	string input_pwd();
	string getNewPWD();
	bool existThisID(const string &filename,const string &id);
public:
	User(){}
	User(string ID, string PWD);
	virtual ~User();

	virtual void Login() = 0;
	virtual void change_PWD() = 0;
	void Logout(){ Online = false; }
	string getID() const { return ID; }
	bool getState() const { return Online; }
};

template<typename T,typename Q>
void output(T b, T e, Q &out, const string &prefix = "", const string &suffix=""){
	ostream *pout = &out;
	while (b != e)
		*pout << prefix << *(b++) << suffix << endl;
}

template<typename K, typename V>
ostream &operator<<(ostream &out, const pair<K, V> &p){
	return out << p.first << '\t' << p.second;
}

#endif //USER_H