#include <iostream>
using namespace std;

class human{
private:
	int x, y;
public:
	human(int x = 1, int y = 2);
	~human();
	void setXY(int x = 1, int y = 2);
	void showXY();
};