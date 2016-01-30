#ifndef SCORE_H
#define SCORE_H
#include <string>
using namespace std;

class Score{
public:
	string stuNumber;		//学号
	string Subject;			//科目
	int mScore;				//得分
public:
	bool operator<(const Score &score)const{
		return (this->stuNumber < score.stuNumber || this->Subject < score.Subject);
	}

	friend ostream &operator<<(ostream &out, const Score &stuScore){
		return out << stuScore.stuNumber << ' '
			<< stuScore.Subject << '\t'
			<< stuScore.mScore;
	}
	friend istream &operator>>(istream &in, Score &stuScore){
		in >> stuScore.stuNumber; in.get();
		in >> stuScore.Subject; in.get();
		in >> stuScore.mScore; in.get();
		return in;
	}
};

#endif //SCORE_H