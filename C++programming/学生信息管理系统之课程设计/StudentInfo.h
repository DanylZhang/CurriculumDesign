#ifndef STUDENTINFO_H
#define STUDENTINFO_H
#include <string>
#include <windows.h>
#include "Date.h"
using namespace std;

class StudentInfo{
public:
	string stuNumber;			//ѧ��
	string Name;				//����
	string Sex;					//�Ա�
	Date intendTime;			//��ѧ����
	string NormalMajor;			//�Ƿ�ʦ��
	string Department;			//��λ/ѧԺ
	string Major;				//רҵ
	string Class;				//�༶
	string IdNumber;			//���֤��
	string PhoneNumber;			//�绰����
	string Address;				//��ͥסַ
private:
	string getNianJi();			//�õ��꼶
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