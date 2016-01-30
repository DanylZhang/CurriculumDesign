#ifndef DATE_H
#define DATE_H
#include <iostream>
#include <fstream>
#include <stdexcept>
using namespace std;

class Date {
private:
	int Year;
	int Month;
	int Day;
public:
	Date(){}
	Date::Date(int year, int month, int day) :Year(year), Month(month), Day(day){}
	~Date(){}

	void setYear(int year){ this->Year = year; }
	void setMonth(int month){ this->Month = month; }
	void setDay(int day){ this->Day = day; }
	int getYear() const { return Year; }
	int getMonth() const { return Month; }
	int getDay() const { return Day; }
	void show() const { cout << Year << "��" << Month << "��" << Day << "��" << endl; }

	friend ostream &operator<<(ostream &out, const Date &date){
		return out << date.Year << '-' << date.Month << '-' << date.Day;
	}
	friend istream &operator>>(istream &in, Date &date){//���ܼ�const����Ϊ�����ж�������˸���
		char ch1, ch2;
		in >> date.Year; in >> ch1;//����'-'
		in >> date.Month; in >> ch2;//����'-'
		in >> date.Day;
		if (in.fail() || ch1 != '-' || ch2 != '-')
			throw runtime_error("��������ڸ�ʽ�����������룺");
		return in;
	}
};

#endif //DATE_H