class Solution {
public:
    int countConsistentStrings(string allowed, vector<string>& words) {
       unordered_map<char,int>mpp;
       for(int i=0;i<allowed.size();i++)
       {
            mpp[allowed[i]]=i;
       } 
       int res=0;
       for(int i=0;i<words.size();i++)
       {
            int flag=1;
            for(int j=0;j<words[i].size();j++)
            {
                if(mpp.find(words[i][j])==mpp.end())
                {
                    flag=0;
                    break;
                }
            }
            if(flag)
                res++;
       }
       return res;
    }
};