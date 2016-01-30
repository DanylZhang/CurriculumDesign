//��ϲLZ����c++���ں������õ�һ���Ļ����
//�����������������ʹ����Argument - Dependent Lookup��ADL�������������ң���
//���������ݲ���vi.begin()��vi.end()�����Ͳ��ҵ�������ͬ�����ռ��е�sort������
//������������û����������ռ䣬����ADL�޷��ҵ�std�����ռ�ĺ�������
#include <iostream>
#include <algorithm>

int main()
{
	int arr[10] = {5,6,3,7,2,8,9,0,1,4};
	for (auto i : arr)
		std::cout << i << " ";

	//С��ԭ����ֻ��ǰ�������
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(&arr[0], &arr[9]);
	for (auto i : arr)
		std::cout << i << " ";

	//�������±�Խ�������
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(&arr[0], &arr[10]);
	for (auto i : arr)
		std::cout << i << " ";

	//������ʵľ������
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(arr,arr+10);
	for (auto i : arr)
		std::cout << i << " ";

	//������д����begin(arr),end(arr)
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(std::begin(arr), std::end(arr));
	for (auto i : arr)
		std::cout << i << " ";
	return 0;
}

//#include <iostream>
//#include <vector>
//#include <algorithm>
//
//int main()
//{
//	std::vector<int> vi(10, 0);
//	sort(vi.begin(), vi.end());
//	for (auto i : vi)
//		std::cout << i << " ";
//	return 0;
//}