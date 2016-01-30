#ifndef REWARD_PUNISHMENT_H
#define REWARD_PUNISHMENT_H
#include <string>
#include "Date.h"
using namespace std;

class Reward_Punishment
{
public:
	string stuNumber;			//学号
	string Name;				//姓名
	string Reason;				//奖惩原因
	string Remark;				//奖惩说明
	Date recordDate;			//记录日期
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