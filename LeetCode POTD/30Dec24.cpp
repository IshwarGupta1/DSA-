class Solution {
public:
    int mod=1e9+7;
    int solve(vector<int>& dp, int len, int low, int high, int zero, int one)
    {
        if(len>high)
            return 0;
        int res=0;
        if(len>=low&&len<=high)
            res = 1;
        if(dp[len]!=-1)
            return dp[len];
        res=res%mod+solve(dp,len+zero,low,high,zero,one)%mod;
        res=res%mod+solve(dp,len+one,low,high,zero,one)%mod;
        return dp[len]=res%mod;
    }
    int countGoodStrings(int low, int high, int zero, int one) {
        vector<int>dp(high+1,-1);
        return solve(dp,0,low,high,zero,one);
    }
};