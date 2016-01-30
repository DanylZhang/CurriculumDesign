//unique_ptr����ָ�룬�µ�ָ��ָ��ԭ���������Ƴ�ԭָ��
//shared_ptr����ָ�룬�������������ϵ�ָ��ͬʱָ��һ������ֱ��ɾ������ָ��ʱ���������ɾ��
#include <iostream>
#include <memory>
#include <utility>
using namespace std;

int main()
{
	unique_ptr<int> up(new int(1729));
	cout << *up << endl;
	unique_ptr<int> up2 = move(up);	//up2(up)���󣬸��ƹ��캯����˽�л�
	if (up)
		cout << "uh oh" << endl;
	else
		cout << "yay" << endl;
	cout << *up2 << endl;

	shared_ptr<int> sp(new int(1234));
	shared_ptr<int> sp2(sp);
	cout << *sp << endl;
	sp.reset();		//cout << *sp << endl;
	cout << *sp2 << endl;

	auto sp3 = make_shared<int>(123);
	cout << *sp3 << endl;
	return 0;
}