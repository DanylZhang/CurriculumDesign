#ifndef COMPARER_H
#define COMPARER_H
using namespace std;

class Comparer
{
public:
	double m_S;//����������ľ���
	double m_V;//���������ʱ�������ٶ�
public:
	Comparer() {}
	virtual ~Comparer() {}

	friend istream &operator>>(istream &in, Comparer &comparer)
	{
		in >> comparer.m_S;
		in >> comparer.m_V;
		return in;
	}
	//�ж��Ƿ�Ӧ�ñ���
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
		//������������ľ���С�ڻ���ڰ�ȫ����ʱ����true
		double s0= 1.2*(0.3535*m_V + 2 * m_V*m_V / 165.1104 + 5);//��ȫ����
		return m_S <= s0;
	}
	void Alarm()
	{
		cout << "������������\7";
	}
	void print()
	{
		cout << "���������(m)��" << m_S << "\t�����ٶ�(km/s)��" << m_V << endl;
	}
};
#endif //COMPARER_H