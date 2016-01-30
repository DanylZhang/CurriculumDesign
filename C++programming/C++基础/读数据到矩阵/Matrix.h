#pragma once
#include <string>
#include <vector>
using namespace std;

class Matrix
{
public:
	double matrix[3][3];
public:
	Matrix(){};
	~Matrix(){};
	friend ostream &operator<<(ostream &out, const Matrix &matrix){
		for (int i = 0; i < 3; ++i){
			for (int j = 0; j < 3; ++j){
				out << matrix.matrix[i][j]<<" ";
			}
			out << endl;
		}
		return out;
	}
	friend istream &operator>>(istream &in, Matrix &matrix) {
		double elem;
		for (int i = 0; i < 3; ++i){
			for (int j = 0; j < 3; ++j){
				in >> elem;
				matrix.matrix[i][j] = elem;
			}
		}
		return in;
	}
};