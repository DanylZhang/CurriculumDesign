#ifndef FINDTHISSTUNUMBER_H
#define FINDTHISSTUNUMBER_H
#include <string>

class FindThisStuNumber{		//º¯Êý¶ÔÏó
private:
	std::string m_id;
public:
	FindThisStuNumber(std::string id) :m_id(id){}
	template<typename T>
	bool operator() (T &element){
		return element.stuNumber == m_id;
	}
};
#endif //FINDTHISSTUNUMBER_H