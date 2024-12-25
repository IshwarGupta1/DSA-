#include<bits/stdc++.h>
using namespace std;
int kDistinctChars(int k, string &str)
{
    // Write your code here
    int i=0,j=0,res=0;
    unordered_map<char,int>mpp;
    while(j<str.size())
    {
        mpp[str[j]]++;
        if(mpp.size()<=k)
        {
            res=max(res,j-i+1);
            j++;
        }
        else
        {
            while(mpp.size()>k)
            {
                mpp[str[i]]--;
                if(mpp[str[i]]==0)
                    mpp.erase(str[i]);
                i++;
            }
            res=max(res,j-i+1);
            j++;
        }
    }
    return res;
}