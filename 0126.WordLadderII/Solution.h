#pragma once
#include <vector>
#include <unordered_set>
#include <unordered_map>
#include <queue>
#include <string>
#include <iostream>
using namespace std;
class Solution
{
public:
	Solution();
	~Solution();
	vector<vector<string>> findLadders(string start, string end, unordered_set<string> &dict);
	void BSF(string start, string end, unordered_multimap<string, string> &hm, vector<string>& current, vector<vector<string>>& vv);
	vector<string> GetConnectCandidates(string a);
};

