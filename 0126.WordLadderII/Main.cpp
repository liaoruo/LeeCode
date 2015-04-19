
#include "Solution.h"

void main()
{
	Solution solution;
	unordered_set<string> set;
	
	//"hot","dot","dog","lot","log"
	set.insert("hot");
	set.insert("dot");
	set.insert("dog");
	set.insert("lot");
	set.insert("log");
	vector<vector<string>> vv = solution.findLadders("hit", "cog", set);
	
	//vector<vector<string>> vv = solution.findLadders("hit", "cog", set);
	for (vector<vector<string>>::iterator i=vv.begin(); i != vv.end(); i++)
	{
		for (vector<string>::iterator j=i->begin(); j != i->end(); j++)
		{
			cout<<*j<<" ";
		}
		cout << endl;
	}

}