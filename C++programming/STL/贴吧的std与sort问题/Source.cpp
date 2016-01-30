//恭喜LZ发现c++关于函数调用的一层黑幕……
//出现这种情况是由于使用了Argument - Dependent Lookup（ADL，参数依赖查找），
//编译器根据参数vi.begin()和vi.end()的类型查找到了在相同命名空间中的sort函数，
//由于内置数组没有相关命名空间，所以ADL无法找到std命名空间的函数……
#include <iostream>
#include <algorithm>

int main()
{
	int arr[10] = {5,6,3,7,2,8,9,0,1,4};
	for (auto i : arr)
		std::cout << i << " ";

	//小于原数组只对前面的排序
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(&arr[0], &arr[9]);
	for (auto i : arr)
		std::cout << i << " ";

	//有数组下标越界的嫌疑
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(&arr[0], &arr[10]);
	for (auto i : arr)
		std::cout << i << " ";

	//还算合适的距离相加
	std::cout << std::endl << "***********************" << std::endl;
	std::sort(arr,arr+10);
	for (auto i : arr)
		std::cout << i << " ";

	//最合理的写法：begin(arr),end(arr)
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