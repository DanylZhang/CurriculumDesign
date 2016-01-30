/*特殊容器：stack,queue,priority_queue
push(element),pop(),empty()
不同之处：
stack:.top(),queue:.front(),queue:.back(),priority_queue:.top()
没有迭代器
*/
#include <iostream>
#include <queue>
using namespace std;

int main()
{
	priority_queue<int> pq;//优先级队列，内部堆调整；大根堆，最大元素做根；小根堆
	pq.push(50); pq.push(80);
	pq.push(20); pq.push(70);
	pq.push(60); pq.push(30);
	while (!pq.empty()){
		cout << pq.top() << endl;
		pq.pop();
	}
	return 0;
}