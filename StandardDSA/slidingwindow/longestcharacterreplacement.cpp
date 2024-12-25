class Solution {
public:
    int characterReplacement(string s, int k) {
        vector<int>freq(26,0);
        int i=0,j=0,res=1;
        while(j<s.size())
        {
            freq[s[j]-'A']++;
            int m=*max_element(freq.begin(),freq.end());
            if((j-i+1)-m<=k)
            {
                res=max(res,(j-i+1));
                j++;
            }
            else
            {
                while((j-i+1)-m>k)
                {
                    freq[s[i]-'A']--;
                    i++;
                }
                res=max(res,(j-i+1));
                j++;
            }
        }
        return res;
    }
};