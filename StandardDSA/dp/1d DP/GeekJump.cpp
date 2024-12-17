class Solution {
  public:
    int solve(vector<int>&dp, vector<int>&height, int n)
    {
        if(n==0)
            return 0;
        if(n==1)
            return abs(height[1]-height[0]);
        if(dp[n]!=-1)
            return dp[n];
        int jump1=abs(height[n]-height[n-1]);
        int jump2=abs(height[n]-height[n-2]);
        return dp[n]=min(jump1+solve(dp,height,n-1),jump2+solve(dp,height,n-2));
    }
    int minimumEnergy(vector<int>& height, int n) {
        // Code here
        vector<int>dp(n,-1);
        return solve(dp,height,n-1);
    }
};