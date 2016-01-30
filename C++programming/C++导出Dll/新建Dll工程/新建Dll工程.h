// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the DLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// DLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
#define DLL_API __declspec(dllimport)
#endif

#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// This class is exported from the 新建Dll工程.dll
class DLL_API C新建Dll工程 {
public:
	C新建Dll工程(void);
	int execute(char *str);
};

extern DLL_API int n新建Dll工程;

//extern "C" 指定 C++编译器编译为 C语言调用风格，便于C程序调用
//_stdcall为Windows API标准调用，另外还有_fastcall _cdecl
//使用该动态链接库时，VC提供 #pragma comment(lib,"*.lib")引入库预处理指令
extern "C" DLL_API int _stdcall Execute(string str);