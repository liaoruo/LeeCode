#pragma once
class Solution
{
public:
	Solution();
	~Solution();
	bool isMatch(const char *s, const char *p);
	int isMatchEmpty(const char *p, const char* r, int* eMap);
	int isMatchLoop(const char *s, const char *p, const char *rs, const char *rp, int Map[][100], int* eMap);
};

