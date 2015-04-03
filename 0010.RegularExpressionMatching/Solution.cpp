#include "Solution.h"


Solution::Solution()
{
}


Solution::~Solution()
{
}

bool Solution::isMatch(const char *s, const char *p)
{
	int MaxCache = 100;
	int Map[100][100];
	for (int i = 0; i < MaxCache; i++)
		for (int j = 0; j < MaxCache; j++)
			Map[i][j] = 0;
	int eMap[100];
	for (int i = 0; i < MaxCache; i++)
	{
		eMap[i] = 0;
	}

	int r = isMatchLoop(s, p, s, p, Map, eMap);
	if (r == 1)
		return true;
	else
	{
		return false;
	}


}
int Solution::isMatchLoop(const char *s, const char *p, const char *rs, const char *rp, int Map[][100], int* eMap)
{
	if (Map[s - rs][p - rp] != 0)
		return Map[s - rs][p - rp];


	if (s[0] == '\0')
	{
		Map[s - rs][p - rp]=isMatchEmpty(p, rp, eMap);
	}
	else if (s[0] != '\0'&&p[0] == '\0')
	{
		Map[s - rs][p - rp] = -1;
	}
	else
	{
		if (p[1] == '*')
		{
			if (p[0] == '.' || p[0] == s[0])
			{
				int a = isMatchLoop(s + 1, p, rs, rp, Map, eMap);
				int b = isMatchLoop(s + 1, p + 2, rs, rp, Map, eMap);
				int c = isMatchLoop(s, p + 2, rs, rp, Map, eMap);
				Map[s - rs][p - rp] = a > b ? (a > c ? a : c) : (b > c ? b : c);				
			}
			else
			{
				Map[s - rs][p - rp]=isMatchLoop(s, p + 2, rs, rp, Map, eMap);
			}
		}
		else
		{
			if (p[0] == '.' || p[0] == s[0])
			{
				Map[s - rs][p - rp] = isMatchLoop(s + 1, p + 1, rs, rp, Map, eMap);
			}
			else
			{
				Map[s - rs][p - rp] = -1;
			}
		}

	}

	return Map[s - rs][p - rp];
}

int Solution::isMatchEmpty(const char *p, const char* r, int * eMap)
{
	if (eMap[p - r] != 0)
		return eMap[p - r];
	
	if (p[0] == '\0')
	{
		eMap[p - r] = 1;		
	}
	else if (p[0] != '*'&& p[1] == '*')
	{
		eMap[p - r] = isMatchEmpty(p + 2, r, eMap) ;		
	}
	else
	{
		eMap[p - r] = -1;		
	}

	return eMap[p - r];
}