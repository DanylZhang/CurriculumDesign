#ifndef COMPARER_H
#define COMPARER_H
using namespace std;

class Comparer
{
public:
	double m_S;//超声波测出的距离
	double m_V;//超声波测距时汽车的速度
public:
	Comparer() {}
	virtual ~Comparer() {}

	friend istream &operator>>(istream &in, Comparer &comparer)
	{
		in >> comparer.m_S;
		in >> comparer.m_V;
		return in;
	}
	//判断是否应该报警
	void ShouldAlarm()
	{
		if (Judge())
		{
			Alarm();
		}
		print();
	}
private:
	bool Judge()
	{
		//当超声波测出的距离小于或等于安全距离时返回true
		double s0= 1.2*(0.3535*m_V + 2 * m_V*m_V / 165.1104 + 5);//安全距离
		return m_S <= s0;
	}
	void Alarm()
	{
		cout << "警报！警报！\7";
	}
	void print()
	{
		cout << "超声波测距(m)：" << m_S << "\t汽车速度(km/s)：" << m_V << endl;
	}
};
#endif //COMPARER_H