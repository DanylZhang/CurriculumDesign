// �½�Dll����.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "�½�Dll����.h"
#include "DataInfo.h"
#include <vector>
using namespace std;

// This is an example of an exported variable
DLL_API int n�½�Dll����=0;

// This is an example of an exported function.
extern "C" DLL_API int _stdcall Execute(string str)
{
	ifstream fin(str);
	if (!fin) {
		cout << "�ļ���ȡʧ�ܣ�";
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

int C�½�Dll����::execute(char *str)
{
	ifstream fin(str);
	if (!fin) {
		cout << "�ļ���ȡʧ�ܣ�";
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
// see �½�Dll����.h for the class definition
C�½�Dll����::C�½�Dll����()
{
	return;
}