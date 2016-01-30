#include <iostream>
#include <fstream>
#include <string>
#include "DataInfo.h"
using namespace std;

int main()
{
	ifstream fin("1.txt");
	if (!fin) {
		cout << "ÎÄ¼þ¶ÁÈ¡Ê§°Ü£¡";
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