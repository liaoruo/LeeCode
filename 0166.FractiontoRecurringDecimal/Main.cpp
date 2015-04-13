#include<iostream>
using namespace std;
#include "Solution.h"
void main()
{
	Solution solution;
	cout << solution.fractionToDecimal(5, 5) << endl
		<< solution.fractionToDecimal(50, 5) << endl
		<< solution.fractionToDecimal(5, 2) << endl
		<< solution.fractionToDecimal(1, 5) << endl
		<< solution.fractionToDecimal(3, 25) << endl
		<< solution.fractionToDecimal(7, 1024) << endl
		<< solution.fractionToDecimal(70099, 99) << endl
		<< solution.fractionToDecimal(1, 137) << endl
		<< solution.fractionToDecimal(-1,-2147483648) << endl;
}