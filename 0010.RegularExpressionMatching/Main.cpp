#include<iostream>
using namespace std;
#include "Solution.h"

void main()
{
	Solution solution;
	cout << solution.isMatch("ab", ".*c") << endl
		<< solution.isMatch("aa", "aa") << endl
		<< solution.isMatch("aaa", "aa") << endl
		<< solution.isMatch("aa", "a*") << endl
		<< solution.isMatch("aa", ".*") << endl
		<< solution.isMatch("ab", ".*") << endl
		<< solution.isMatch("aab", "c*a*b") << endl;


}