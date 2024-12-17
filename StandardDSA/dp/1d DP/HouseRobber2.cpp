class Solution {
public:
    int f(vector<int>&v,int ind,vector<int>&dp)
    {
        if(ind==0)
            return v[0];
        if(ind<0)
            return 0;
        if(dp[ind]!=-1)
            return dp[ind];
        int np=0+f(v,ind-1,dp);
        int p=v[ind]+f(v,ind-2,dp);
        return dp[ind]=max(p,np);
    }
    int rob(vector<int>& nums) {
        if(nums.size()==1)
            return nums[0];
        vector<int>a;
        vector<int>b;
        for(int i=0;i<nums.size()-1;i++)
            a.push_back(nums[i]);
        for(int i=1;i<nums.size();i++)
            b.push_back(nums[i]);
        vector<int>dp1(a.size(),-1);
        vector<int>dp2(b.size(),-1);
        int x=f(a,a.size()-1,dp1);
        int y=f(b,b.size()-1,dp2);
        return max(x,y);
    }
};