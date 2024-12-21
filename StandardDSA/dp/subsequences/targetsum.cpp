class Solution {
public:
    int findTargetSumWays(vector<int>& nums, int target) {
        int sum=0;
        for(auto it:nums)
            sum=sum+it;
        if((sum-target)%2)
            return 0;
        int s=(sum-target)/2;
        if(s<0)
            return 0;
        int n=nums.size();
        vector<vector<int>>dp(n,vector<int>(s+1,0));
        if (nums[0] == 0)
            dp[0][0] = 2;
        else
            dp[0][0] = 1;
        if (nums[0] != 0 && nums[0] <= s)
            dp[0][nums[0]] = 1;
        for(int i=1;i<n;i++)
        {
            for(int j=0;j<=s;j++)
            {
                int nt=0,t=0;
                if(i>0)
                nt=dp[i-1][j];
                if(nums[i]<=j)
                    t=dp[i-1][j-nums[i]];
                dp[i][j]=t+nt;
            }
        }
        return dp[n-1][s];
    }
};