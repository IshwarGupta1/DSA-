class Solution {
public:
    int solve(vector<int>& coins, int amnt, int ind)
    {
        if(amnt == 0)
            return 0;
        if(ind<0)
            return 1e9;
        int nt=1e9;
        int t=1e9;
        if(coins[ind]<=amnt)
        {
            t=1+solve(coins,amnt-coins[ind],ind);
        }
        nt=solve(coins,amnt,ind-1);
        return min(t,nt);
    }
    int coinChange(vector<int>& coins, int amount) {
        sort(coins.begin(),coins.end());
        int n=coins.size();
        return solve(coins,amount,n-1)==1e9?-1:solve(coins,amount,n-1);
    }
};


class Solution {
public:
    int solve(vector<int>& coins, vector<vector<int>>&dp, int amnt, int ind)
    {
        if(amnt == 0)
            return dp[0][ind]=0;
        if(ind<0)
            return 1e9;
        if(dp[amnt][ind]!=-1)
            return dp[amnt][ind];
        int nt=1e9;
        int t=1e9;
        if(coins[ind]<=amnt)
        {
            t=1+solve(coins,dp,amnt-coins[ind],ind);
        }
        nt=solve(coins,dp,amnt,ind-1);
        return dp[amnt][ind]=min(t,nt);
    }
    int coinChange(vector<int>& coins, int amount) {
        sort(coins.begin(),coins.end());
        int n=coins.size();
        vector<vector<int>>dp(amount+1,vector<int>(n,-1));
        return solve(coins,dp,amount,n-1)==1e9?-1:solve(coins,dp,amount,n-1);
    }
};



class Solution {
public:
    int coinChange(vector<int>& coins, int amnt) {
        int n = coins.size();
        vector<vector<int>> dp(amnt + 1, vector<int>(n, 1e9)); // Initialize DP table

        // Base case: 0 coins needed for amount 0
        for (int j = 0; j < n; j++) {
            dp[0][j] = 0;
        }

        // Fill the DP table
        for (int i = 1; i <= amnt; i++) {
            for (int j = 0; j < n; j++) {
                int nt = (j > 0) ? dp[i][j - 1] : 1e9; // Skip the current coin
                int t = (coins[j] <= i) ? 1 + dp[i - coins[j]][j] : 1e9; // Use the coin

                dp[i][j] = min(t, nt); // Take the minimum of both options
            }
        }

        int result = dp[amnt][n - 1];
        return (result >= 1e9) ? -1 : result; // If result is large, no solution exists
    }
};







class Solution {
public:
    int coinChange(vector<int>& coins, int amnt) {
        int n = coins.size();
        vector<int>prev(amnt+1,1e9);
        for (int i = 0; i <= amnt; i++)
        {
            if(i%coins[0]==0)
                prev[i]=i/coins[0];
        }
        for (int i = 1; i < n; i++) {
            vector<int>curr(amnt+1,1e9);
            for (int j = 0; j <= amnt; j++) {
                int nt=1e9,t=1e9;
                nt=prev[j];
                if(j>=coins[i])
                    t=1+curr[j-coins[i]];
                curr[j]=min(t,nt);
            }
            prev=curr;
        }
        int result = prev[amnt];
        return (result >= 1e9) ? -1 : result;
    }
};
