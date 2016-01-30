#include <iostream>
using namespace std;
//��һ��������һ�����ϵʮ������ʱ����һ���������һ����ʹ��ʱ��ʹ��Ƕ����
//Ƕ������Կ������ⲿ�������е�һ���������ͣ����Ƕ���һЩ���еĺ���
class Rectangle{
public:
	class Point{
	public:
		void setX(double x){ this->x = x; }
		void setY(double y){ this->y = y; }
		double getX(){ return x; }
		double getY(){ return y; }
	private:
		double x, y;
	};

	Rectangle(double left, double right, double top, double bottom);

	void setUpleft(){ upleft.setX(left); upleft.setY(top); }
	void setLowerleft(){ lowerleft.setX(left); lowerleft.setY(bottom); }
	void setUpright(){ upright.setX(right); upright.setY(top); }
	void setLowerright(){ lowerright.setX(right); lowerright.setY(bottom); }

	Point getUpleft()const{ return upleft; }
	Point getLowerleft()const{ return lowerleft; }
	Point getUpright()const{ return upright; }
	Point getLowerright()const{ return lowerright; }

	void setLeft(double left){ this->left = left; }
	void setRight(double right){ this->right = right; }
	void setTop(double top){ this->top = top; }
	void setBottom(double bottom){ this->bottom = bottom; }

	double getLeft()const{ return left; }
	double getRight()const{ return right; }
	double getTop()const{ return top; }
	double getBottom()const{ return bottom; }

	double getArea()const{
		double height = top - bottom;
		double width = right - left;
		return (height*width);
	}
private:
	Point upleft;
	Point lowerleft;
	Point upright;
	Point lowerright;
	double left, right, top, bottom;
};
Rectangle::Rectangle(double left, double right, double top, double bottom)
{
	this->left = left;
	this->right = right;
	this->top = top;
	this->bottom = bottom;
	upleft.setX(left);
	upleft.setY(top);
	lowerleft.setX(left);
	lowerleft.setY(bottom);
	upright.setX(right);
	upright.setY(top);
	lowerright.setX(right);
	lowerright.setY(bottom);
}

class Point{//֤���ⲿ����Ƕ��������Ʋ���ͻ
public:
	double getArea(Rectangle &rect){ return rect.getArea(); }
};

int main()
{
	Rectangle rect1(30, 60, 20, 10);
	cout << "��ߣ�" << rect1.getLeft() << endl;
	cout << "�±ߣ�" << rect1.getBottom() << endl;
	cout << "���µ��x���꣺" << rect1.getLowerleft().getX() << endl;
	cout << "���µ��y���꣺" << rect1.getLowerleft().getY() << endl;
	cout << "���ε�����ǣ�" << rect1.getArea() << endl;

	cout << "\n�������þ��ε�����..." << endl;
	rect1.setLeft(10);
	rect1.setRight(50);
	rect1.setTop(40);
	rect1.setBottom(20);
	rect1.setUpleft();
	rect1.setLowerleft();
	rect1.setUpright();
	rect1.setLowerright();
	cout << "��ߣ�" << rect1.getLeft() << endl;
	cout << "�±ߣ�" << rect1.getBottom() << endl;
	cout << "���µ��x���꣺" << rect1.getLowerleft().getX() << endl;
	cout << "���µ��y���꣺" << rect1.getLowerleft().getY() << endl;
	cout << "���ε�����ǣ�" << rect1.getArea() << endl;

	cout << "\n***************" << endl;
	Point point1;
	cout << "�ⲿ���������" << point1.getArea(rect1) << endl;
	return 0;
}