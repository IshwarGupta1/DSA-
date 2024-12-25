class Solution {
public:
    int kDistinctChars(int k, vector<int>& str)
    {
        int i=0,j=0,res=0;
        unordered_map<int,int>mpp;
        while(j<str.size())
        {
            mpp[str[j]]++;
            if(mpp.size()<=k)
            {
                res=res+j-i+1;
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
                res=res+j-i+1;
                j++;
            }
        }
        return res;
    }
    int subarraysWithKDistinct(vector<int>& nums, int k) {
        return kDistinctChars(k,nums)-kDistinctChars(k-1,nums);
    }
};