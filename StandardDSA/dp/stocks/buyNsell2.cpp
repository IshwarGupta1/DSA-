class Solution {
public:
    int solve(vector<int>&prices, vector<vector<int>>&dp, int ind, int buy)
    {
        if(ind==prices.size())
            return 0;
        if(dp[ind][buy]!=-1)
            return dp[ind][buy];
        int op1=0,op2=0;
        if(buy)
        {
            op1=solve(prices,dp,ind+1,1);
            op2=prices[ind]+solve(prices,dp,ind+1,0);
        }
        else
        {
            op1=solve(prices,dp,ind+1,0);
            op2=-prices[ind]+solve(prices,dp,ind+1,1);
        }
        return dp[ind][buy]=max(op1,op2);
    }
    int maxProfit(vector<int>& prices) {
        int n=prices.size();
        vector<vector<int>>dp(n,vector<int>(2,-1));
        return solve(prices,dp,0,0);
    }
};



class Solution {
public:
    int maxProfit(vector<int>& prices) {
        int n=prices.size();
        vector<vector<int>>dp(n+1,vector<int>(2,-1));
        dp[n][0]=0;
        dp[n][1]=0;
        for(int i=n-1;i>=0;i--)
        {
            for(int j=0;j<=1;j++)
            {
                int op1=0,op2=0;
                if(j==0)
                {
                    op1=dp[i+1][0];
                    op2=-prices[i]+dp[i+1][1];
                }
                else
                {
                    op1=dp[i+1][1];
                    op2=prices[i]+dp[i+1][0];
                }
                dp[i][j]=max(op1,op2);
            }
        }
        return dp[0][0];
    }
};