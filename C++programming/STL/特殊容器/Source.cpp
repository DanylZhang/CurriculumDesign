/*����������stack,queue,priority_queue
push(element),pop(),empty()
��֮ͬ����
stack:.top(),queue:.front(),queue:.back(),priority_queue:.top()
û�е�����
*/
#include <iostream>
#include <queue>
using namespace std;

int main()
{
	priority_queue<int> pq;//���ȼ����У��ڲ��ѵ���������ѣ����Ԫ��������С����
	pq.push(50); pq.push(80);
	pq.push(20); pq.push(70);
	pq.push(60); pq.push(30);
	while (!pq.empty()){
		cout << pq.top() << endl;
		pq.pop();
	}
	return 0;
}