class Solution {
public:
    bool checkVowel(char ch)
    {
        return ch=='a'||ch=='e'||ch=='i'||ch=='o'||ch=='u';
    }
    bool isValid(string s)
    {
        int n=s.size();
        return checkVowel(s[0])&&checkVowel(s[n-1]);
    }
    vector<int> vowelStrings(vector<string>& words, vector<vector<int>>& queries) {
        vector<int>pref(words.size(),0);
        if(isValid(words[0]))
            pref[0]=1;
        for(int i=1;i<words.size();i++)
        {
            if(isValid(words[i]))
                pref[i]=pref[i-1]+1;
            else
                pref[i]=pref[i-1];
        }
        for(auto it: pref)
            cout<<it<<" ";
        vector<int> res;
        for (const auto& q : queries) {
            int l = q[0], r = q[1];
            int totalCount = pref[r] - (l > 0 ? pref[l - 1] : 0);
            res.push_back(totalCount);
        }
        return res;
    }
};