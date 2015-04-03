#include<iostream>
using namespace std;
#include "Solution.h"
#include "SolutionDP.h"
void main()
{
	Solution solution;
	cout << solution.isMatch("ab", ".*c") << endl
		<< solution.isMatch("aa", "aa") << endl
		<< solution.isMatch("aaa", "aa") << endl
		<< solution.isMatch("aa", "a*") << endl
		<< solution.isMatch("aa", ".*") << endl
		<< solution.isMatch("ab", ".*") << endl
		<< solution.isMatch("aab", "c*a*b") << endl
		<< solution.isMatch("bbbba", ".*a*a") << endl;

	cout << "--------------------" << endl;

	SolutionDP solutionDP;
	cout << solutionDP.isMatch("ab", ".*c") << endl
		<< solutionDP.isMatch("aa", "aa") << endl
		<< solutionDP.isMatch("aaa", "aa") << endl
		<< solutionDP.isMatch("aa", "a*") << endl
		<< solutionDP.isMatch("aa", ".*") << endl
		<< solutionDP.isMatch("ab", ".*") << endl
		<< solutionDP.isMatch("aab", "c*a*b") << endl 
		<< solutionDP.isMatch("bbbba", ".*a*a") << endl;

}