//unique_ptr独享指针，新的指针指向原有区域须移除原指针
//shared_ptr共享指针，两个或两个以上的指针同时指向一块区域；直至删除所有指针时，该区域才删除
#include <iostream>
#include <memory>
#include <utility>
using namespace std;

int main()
{
	unique_ptr<int> up(new int(1729));
	cout << *up << endl;
	unique_ptr<int> up2 = move(up);	//up2(up)错误，复制构造函数已私有化
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