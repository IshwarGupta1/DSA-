class Solution {
public:
    int change(int s, vector<int>& nums) {
        int n=nums.size();
        vector<vector<int>>dp(n,vector<int>(s+1,0));
        for(int i=0;i<=s;i++)
        {
            if(i%nums[0]==0)
                dp[0][i]=1;
        }
        for(int i=1;i<n;i++)
        {
            for(int j=0;j<=s;j++)
            {
                int nt=0,t=0;
                if(i>0)
                nt=dp[i-1][j];
                if(nums[i]<=j)
                    t=dp[i][j-nums[i]];
                dp[i][j]=t+nt;
            }
        }
        return dp[n-1][s];

    }
};