#include "SolutionDP.h"


SolutionDP::SolutionDP()
{
}


SolutionDP::~SolutionDP()
{
}


bool SolutionDP::isMatch(const char *s, const char *p)
{
	int ls = 0;
	for (ls = 0; s[ls] != '\0'; ls++);
	int lp = 0;
	for (lp = 0; p[lp] != '\0'; lp++);

#define MAXS 1000
#define MAXP 100

	int DP[MAXS][MAXP];
	for (int i = 0; i <= ls; i++)
		for (int j = 0; j <= lp; j++)
			DP[i][j] = -1;

	DP[ls][lp] = 1;
	for (int i = ls-1; i >=0; i--)
		DP[i][lp] = 0;
	for (int j = lp-1; j >=0; j--)
	{
		if (p[j + 1] == '*')
			DP[ls][j] = DP[ls][j + 2];
		else
			DP[ls][j] = 0;
	}

	for (int i = ls - 1; i >= 0; i--)
	{
		for (int j = lp - 1; j >= 0; j--)
		{
			if (p[j] == '*')
			{
				DP[i][j] = 0;
			}
			else if (p[j + 1] == '*')
			{
				if (p[j] == '.' || p[j] == s[i])
				{
					DP[i][j] = DP[i + 1][j + 2] | DP[i + 1][j] | DP[i][j + 2];
				}
				else
				{
					DP[i][j] = DP[i][j + 2];
				}
			}
			else if(p[j] == '.' || p[j] == s[i])
			{
				DP[i][j] = DP[i + 1][j + 1];
			}
			else
			{
				DP[i][j] = 0;
			}
		}
	}
	return DP[0][0] == 1;


}