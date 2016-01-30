// 新建Dll工程.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "新建Dll工程.h"
#include "DataInfo.h"
#include <vector>
using namespace std;

// This is an example of an exported variable
DLL_API int n新建Dll工程=0;

// This is an example of an exported function.
extern "C" DLL_API int _stdcall Execute(string str)
{
	ifstream fin(str);
	if (!fin) {
		cout << "文件读取失败！";
		return 0;
	}
	DataInfo dataInfo;
	vector<DataInfo> vectInfo;
	while (fin >> dataInfo) {
		vectInfo.push_back(dataInfo);
	}
	fin.close();

	for each (DataInfo var in vectInfo)
	{
		cout << var << endl;
	}
	return 0;
}

int C新建Dll工程::execute(char *str)
{
	ifstream fin(str);
	if (!fin) {
		cout << "文件读取失败！";
		return 0;
	}
	DataInfo dataInfo;
	vector<DataInfo> vectInfo;
	while (fin >> dataInfo) {
		vectInfo.push_back(dataInfo);
	}
	fin.close();

	for each (DataInfo var in vectInfo)
	{
		cout << var << endl;
	}
	return 0;
}

// This is the constructor of a class that has been exported.
// see 新建Dll工程.h for the class definition
C新建Dll工程::C新建Dll工程()
{
	return;
}