#ifndef STUDENT_H
#define STUDENT_H
#pragma once
#include <iostream>
#include <string>
using namespace std;

class Student
{
public:
	Student();
	Student(int ID, string Name) :ID(ID), Name(Name){}
	~Student();
public:
	int ID;
	string Name;
};

#endif