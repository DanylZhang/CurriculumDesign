#ifndef REWARD_PUNISHMENT_H
#define REWARD_PUNISHMENT_H
#include <string>
#include "Date.h"
using namespace std;

class Reward_Punishment
{
public:
	string stuNumber;			//ѧ��
	string Name;				//����
	string Reason;				//����ԭ��
	string Remark;				//����˵��
	Date recordDate;			//��¼����
public:
	friend ostream &operator<<(ostream &out, const Reward_Punishment &stuPunish){
		return out << stuPunish.stuNumber << ' '
			<< stuPunish.Name << '\t'
			<< stuPunish.Reason << '\t'
			<< stuPunish.Remark << '\t'
			<< stuPunish.recordDate;
	}
	friend istream &operator>>(istream &in, Reward_Punishment &stuPunish){
		in >> stuPunish.stuNumber; in.get();
		in >> stuPunish.Name; in.get();
		in >> stuPunish.Reason; in.get();
		in >> stuPunish.Remark; in.get();
		try{
			in >> stuPunish.recordDate;
		}
		catch (exception e){
			in.get();
		}
		return in;
	}
};

#endif //REWARD_PUNISHMENT_H