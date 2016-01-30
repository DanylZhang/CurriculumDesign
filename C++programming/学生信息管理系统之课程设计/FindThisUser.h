#ifndef FINDTHISUSER_H
#define FINDTHISUSER_H
#include <string>

class FindThisUser{				//º¯Êý¶ÔÏó
private:
	std::string m_id;
public:
	FindThisUser(std::string id) :m_id(id){}
	template<typename T>
	bool operator() (T &element){
		return element.ID == m_id;
	}
};
#endif //FINDTHISUSER_H