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
	void show() const { cout << Year << "年" << Month << "月" << Day << "日" << endl; }

	friend ostream &operator<<(ostream &out, const Date &date){
		return out << date.Year << '-' << date.Month << '-' << date.Day;
	}
	friend istream &operator>>(istream &in, Date &date){//不能加const，因为函数中对其进行了更改
		char ch1, ch2;
		in >> date.Year; in >> ch1;//过滤'-'
		in >> date.Month; in >> ch2;//过滤'-'
		in >> date.Day;
		if (in.fail() || ch1 != '-' || ch2 != '-')
			throw runtime_error("错误的日期格式！请重新输入：");
		return in;
	}
};

#endif //DATE_H