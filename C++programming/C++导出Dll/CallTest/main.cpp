#include "..\新建Dll工程\新建Dll工程.h"
#pragma comment(lib,"新建Dll工程.lib")//导出时编译器会改变导出的函数名，但变换会记录在一个叫引入库的文件里*.lib，在使用该dll时添加预处理指令即可

using namespace std;

int main()
{
	C新建Dll工程 test;
	test.execute("1.txt");
	return 0;
}