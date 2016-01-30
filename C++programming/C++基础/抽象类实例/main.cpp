#include <iostream>
using namespace std;

class Shape{
public:
	virtual double area() const = 0;
};

class Trigon :public Shape{
protected:
	double h, w;//高和底
public:
	Trigon(){}
	Trigon(double h, double w) :h(h), w(w){}
	double area() const { return h*w / 2; }
};

class Square :public Trigon{
public:
	Square(){}
	Square(double h, double w) :Trigon(h, w){}
	double area() const { return h*w; }
};

class Circle :public Shape{
protected:
	double radius;
public:
	Circle(){}
	Circle(double r) :radius(r){}
	double area() const { return 3.14*radius*radius; }
};

int main()
{
	Shape *p;
	int choice = 0;
	while (true)
	{
		bool quite = false;
		cout << "(0)退出(1)三角形(2)正方形(3)圆：" << endl;
		cout << "请选择：";
		cin >> choice;
		switch (choice)
		{
		case 0:
			quite = true;
			break;
		case 1:
			p = new Trigon(3, 4);
			cout << "三角形的面积是：" << p->area() << endl << endl;
			delete p;
			break;
		case 2:
			p = new Square(2, 2);
			cout << "正方形的面积是：" << p->area() << endl << endl;
			delete p;
			break;
		case 3:
			p = new Circle(3);
			cout << "圆的面积是：" << p->area() << endl << endl;
			delete p;
			break;
		default:
			cout << "请输入0、1、2或3：";
			break;
		}
		if (quite)
			break;
	}
	return 0;
}