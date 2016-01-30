#include <iostream>
#include <stack>
#include <typeinfo>
using namespace std;

int main()
{
	stack<int> stackInt;
	stackInt.push(1);
	stackInt.push(3);
	stackInt.push(5);
	stackInt.push(7);
	stackInt.push(9);

	stack<char> stackChar;
	stackChar.push('a');
	stackChar.push('b');
	stackChar.push('c');
	stackChar.push('d');

	cout << typeid(stackInt).name() << endl;
	cout << typeid(stackChar).name() << endl;
}