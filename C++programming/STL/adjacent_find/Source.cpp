/*adjacent_find(pos_beg,pos_end)
���ҷ�Χ��������ȵ�����Ԫ�أ��ҵ��򷵻ص�һ��Ԫ�صĵ����������򷵻�end()
*/
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int main()
{
	vector<int> vecIntA;
	vecIntA.push_back(1);
	vecIntA.push_back(2);
	vecIntA.push_back(2);
	vecIntA.push_back(3);
	vecIntA.push_back(4);
	vecIntA.push_back(5);

	vector<int>::iterator  vit = adjacent_find(vecIntA.begin(), vecIntA.end());
	cout << *vit << endl;
	return 0;
}