class Solution {
public:
    int solve(string t1, string t2, int i, int j)
    {
        if(i<0||j<0)
            return 0;
        if(t1[i]==t2[j])
            return 1+solve(t1,t2,i-1,j-1);
        return max(solve(t1,t2,i-1,j),solve(t1,t2,i,j-1));
    }
    int longestCommonSubsequence(string text1, string text2) {
        return solve(text1,text2,text1.size()-1,text2.size()-1);
    }
};

class Solution {
public:
    int solve(string t1, string t2, vector<vector<int>>&dp, int i, int j)
    {
        if(i<0||j<0)
            return 0;
        if(dp[i][j]!=-1)
            return dp[i][j];
        if(t1[i]==t2[j])
            return dp[i][j]=1+solve(t1,t2,dp,i-1,j-1);
        return dp[i][j]=max(solve(t1,t2,dp,i-1,j),solve(t1,t2,dp,i,j-1));
    }
    int longestCommonSubsequence(string text1, string text2) {
        int m=text1.size(),n=text2.size();
        vector<vector<int>>dp(m,vector<int>(n,-1));
        return solve(text1,text2,dp,m-1,n-1);
    }
};


class Solution {
public:
    int longestCommonSubsequence(string text1, string text2) {
        int m=text1.size(),n=text2.size();
        vector<vector<int>>dp(m+1,vector<int>(n+1,-1));
        for(int i=0;i<=m;i++)
            dp[i][0]=0;
        for(int i=0;i<=n;i++)
            dp[0][i]=0;
        for(int i=1;i<=m;i++)
        {
            for(int j=1;j<=n;j++)
            {
                if(text1[i-1]==text2[j-1])
                    dp[i][j]=1+dp[i-1][j-1];
                else
                    dp[i][j]=max(dp[i][j-1],dp[i-1][j]);
            }
        }
        return dp[m][n];
    }
};