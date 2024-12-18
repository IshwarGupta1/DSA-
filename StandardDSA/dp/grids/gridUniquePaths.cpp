class Solution {
public:
    int solve(vector<vector<int>>&dp, int m, int n)
    {
        if(m==0&&n==0)
            return dp[0][0]=1;
        if(dp[m][n]!=-1)
            return dp[m][n];
        int u=0;
        if(m>0)
            u=solve(dp,m-1,n);
        int l=0;
        if(n>0)
            l=solve(dp,m,n-1);
        return dp[m][n]=u+l;
    }
    int uniquePaths(int m, int n) {
        vector<vector<int>>dp(m,vector<int>(n,-1));
        return solve(dp,m-1,n-1);
    }
};




class Solution {
public:
    int uniquePaths(int m, int n) {
        vector<vector<int>>dp(m,vector<int>(n,0));
        dp[0][0]=1;
        for(int i=0;i<m;i++)
        {
            for(int j=0;j<n;j++)
            {
                if(i==0&&j==0)
                {
                    dp[i][j]=1;
                    continue;
                }
                int l=0,u=0;
                if(j>0)
                    u=dp[i][j-1];
                if(i>0)
                    l=dp[i-1][j];
                dp[i][j]=l+u;
            }
        }
        return dp[m-1][n-1];
    }
};




class Solution {
public:
    int uniquePaths(int m, int n) {
        vector<int>prev(n,0);
        for(int i=0;i<m;i++)
        {
            vector<int>temp(n,0);
            for(int j=0;j<n;j++)
            {
                if(i==0&&j==0)
                {
                    temp[j]=1;
                    continue;
                }
                int l=0,u=0;
                if(i>0)
                    u=prev[j];
                if(j>0)
                    l=temp[j-1];
                temp[j]=l+u;
            }
            prev=temp;
        }
        return prev[n-1];
    }
};