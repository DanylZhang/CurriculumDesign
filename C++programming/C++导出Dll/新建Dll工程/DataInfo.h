#pragma once
#include <string>
#include "Matrix.h"
using namespace std;

class DataInfo
{
public:
	string filePath;
	int screenWidth;
	int screenHeight;
	Matrix matrix1;
	Matrix matrix2;
	double distance;
public:
	DataInfo(){};
	~DataInfo(){};
	friend ostream &operator<<(ostream &out, const DataInfo &info){
		return out << info.filePath << '\n'
			<< info.screenWidth << '\t'
			<< info.screenHeight << "\n\n"
			<< info.matrix1 << '\n'
			<< info.matrix2 << '\n'
			<< info.distance;
	}
	friend istream &operator>>(istream &in, DataInfo &info) {
		in >> info.filePath;
		in >> info.screenWidth;
		in >> info.screenHeight; in.get();
		in >> info.matrix1; in.get();
		in >> info.matrix2; in.get();
		in >> info.distance;
		return in;
	}
};