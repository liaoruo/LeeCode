#include "Solution.h"


Solution::Solution()
{
}


Solution::~Solution()
{
}


vector<vector<string>> Solution::findLadders(string start, string end, unordered_set<string> &dict)
{
	//new container
	unordered_set<string> list(dict);
	list.insert(start);
	list.insert(end);

	unordered_multimap<string, string> hm;
	unordered_set<string> layer;
	queue<string> q;
	q.push(end);	
	list.erase(end);
	q.push("");
	bool finish = false;
	while (!q.empty()&&!finish)
	{
		string a=q.front();
		q.pop();
		if (a != "")
		{
			vector<string> candidates=GetConnectCandidates(a);
			for (vector<string>::iterator it = candidates.begin(); it != candidates.end();it++)
			{
				if (list.count(*it) == 0)
					continue;
				hm.insert(pair<string, string>(*it, a));
				layer.insert(*it);
			}
		}
		else
		{
			if (layer.size() == 0)
				break;

			for (unordered_set<string>::iterator it = layer.begin(); it != layer.end(); it++)
			{
				q.push(*it);
				list.erase(*it);
				if (*it == start)
					finish = true;
			}
			q.push("");
			layer.clear();
		}
	}
	vector<string> current; 
	vector<vector<string>> ret;
	BSF(start, end, hm, current, ret);
	return ret;
}
void Solution::BSF(string start, string end, unordered_multimap<string, string> &hm, vector<string>& current, vector<vector<string>>& vv)
{
	if (start == end)
	{
		current.push_back(end);
		vector<string> clone(current);
		vv.push_back(clone);
		current.pop_back();
		return;
	}

	current.push_back(start);
	unordered_multimap<string, string>::iterator it = hm.find(start);
	int cnt = hm.count(start);
	for (int i = 1; i <= cnt;i++)
	{
		BSF((*it).second, end, hm, current, vv);
		it++;
	}
	current.pop_back();
}
vector<string> Solution::GetConnectCandidates(string a)
{
	vector<string> list;
	string charArr = a;
	for (int i = 0; i < a.length(); i++)
	{
		char check = charArr[i];
		for (char c = 'a'; c <= 'z'; c++)
		{
			if (c != check)
			{
				charArr[i] = c;
				list.push_back(charArr);
			}
		}
		charArr[i] = check;
	}
	return list;
}