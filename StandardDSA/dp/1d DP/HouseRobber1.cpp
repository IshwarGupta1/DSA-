class Solution {
public:
    int solve(vector<int>&dp, vector<int>& nums, int ind)
    {
        if(ind<=1)
        {
            if(ind==1)
                return max(nums[0],nums[1]);
            return nums[0];
        }
        if(dp[ind]!=-1)
            return dp[ind];
        int rob1=nums[ind]+solve(dp,nums,ind-2);
        int rob2=solve(dp,nums,ind-1);
        return dp[ind]=max(rob1,rob2);
    }
    int rob(vector<int>& nums) {
        int n=nums.size();
        vector<int>dp(n,-1);
        return solve(dp,nums,n-1);
    }
};