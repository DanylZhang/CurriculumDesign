#ifndef STUDENTINFO_H
#define STUDENTINFO_H
#include <string>
#include <windows.h>
#include "Date.h"
using namespace std;

class StudentInfo{
public:
	string stuNumber;			//学号
	string Name;				//姓名
	string Sex;					//性别
	Date intendTime;			//入学日期
	string NormalMajor;			//是否师范
	string Department;			//单位/学院
	string Major;				//专业
	string Class;				//班级
	string IdNumber;			//身份证号
	string PhoneNumber;			//电话号码
	string Address;				//家庭住址
private:
	string getNianJi();			//得到年级
public:
	void print();
	friend ostream &operator<<(ostream &out, const StudentInfo &stuInfo){
		return out << stuInfo.stuNumber << '\t'
			<< stuInfo.Name << '\t'
			<< stuInfo.Sex << '\t'
			<< stuInfo.intendTime << '\t'
			<< stuInfo.NormalMajor << '\t'
			<< stuInfo.Department << '\t'
			<< stuInfo.Major << '\t'
			<< stuInfo.Class << '\t'
			<< stuInfo.IdNumber << '\t'
			<< stuInfo.PhoneNumber << '\t'
			<< stuInfo.Address;
	}
	friend istream &operator>>(istream &in, StudentInfo &stuInfo) {
		in >> stuInfo.stuNumber; in.get();
		in >> stuInfo.Name; in.get();
		in >> stuInfo.Sex; in.get();
		try{
			in >> stuInfo.intendTime;
		}
		catch (exception e){
			in.get();
		}
		in >> stuInfo.NormalMajor; in.get();
		in >> stuInfo.Department; in.get();
		in >> stuInfo.Major; in.get();
		in >> stuInfo.Class; in.get();
		in >> stuInfo.IdNumber; in.get();
		in >> stuInfo.PhoneNumber; in.get();
		in >> stuInfo.Address; in.get();
		return in;
	}
};

#endif //STUDENTINFO_H