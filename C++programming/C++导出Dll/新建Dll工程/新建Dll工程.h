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

// This class is exported from the �½�Dll����.dll
class DLL_API C�½�Dll���� {
public:
	C�½�Dll����(void);
	int execute(char *str);
};

extern DLL_API int n�½�Dll����;

//extern "C" ָ�� C++����������Ϊ C���Ե��÷�񣬱���C�������
//_stdcallΪWindows API��׼���ã����⻹��_fastcall _cdecl
//ʹ�øö�̬���ӿ�ʱ��VC�ṩ #pragma comment(lib,"*.lib")�����Ԥ����ָ��
extern "C" DLL_API int _stdcall Execute(string str);