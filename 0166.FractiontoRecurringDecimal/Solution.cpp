#include "Solution.h"
#include <vector> 
#include <hash_map>
using std::vector;
using std::hash_map;

Solution::Solution()
{
}


Solution::~Solution()
{
}


string Solution::fractionToDecimal(long numerator, long denominator)
{
	string ret = "";

	bool sign = true;
	if (numerator < 0)numerator = -numerator, sign = !sign;
	if (denominator < 0)denominator = -denominator, sign = !sign;
	if (!sign&&numerator != 0)
		ret += "-";

	//最大公因数
	long gcd = GCD(numerator, denominator);
	numerator /= gcd;
	denominator /= gcd;

	ret += ToString(numerator / denominator);
	numerator %= denominator;

	if (numerator == 0)
	{
		return ret;
	}

	ret += ".";
	vector<long> v;
	hash_map<long, long> hm;
	int index = 0;
	while (true)
	{
		if (numerator == 0)
		{
			for (int i = 0; i < index; i++)
			{
				ret += v[i] + '0';
			}
			break;
		}

		if (hm.find(numerator) == hm.end())
		{
			hm[numerator] = index;
			v.push_back(numerator*10/denominator);
			numerator = numerator * 10 % denominator;
			index++;
		}
		else
		{
			for (int i = 0; i < hm[numerator]; i++)
			{
				ret += v[i] + '0';
			}
			ret += '(';
			for (int i = hm[numerator]; i < index; i++)
			{
				ret += v[i] + '0';
			}
			ret += ')';
			
			break;
		}

	}


	return ret;
}
string Solution::ToString(long x)
{
	string reverse = "";
	if (x == 0)
		return "0";
	while (x != 0)
	{
		reverse += '0' + x % 10;
		x /= 10;
	}
	string ret(reverse.rbegin(), reverse.rend());
	return ret;
}
long Solution::GCD(long x, long y)
{
	if (y == 0)
		return x;

	if (x < y)
		return GCD(y, x);
	else
		return GCD(y, x%y);
}