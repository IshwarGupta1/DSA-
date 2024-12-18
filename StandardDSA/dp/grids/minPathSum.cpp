class Solution {
public:
    int f(int i,int j,vector<vector<int>>&g,vector<vector<int>>&dp)
    {
        if(i==0&&j==0)
            return g[0][0];
        if(i<0||j<0)
            return 1e9;
        if(dp[i][j]!=-1)
            return dp[i][j];
        int u=g[i][j]+f(i-1,j,g,dp);
        int l=g[i][j]+f(i,j-1,g,dp);
        return dp[i][j]=min(u,l);
    }
    int minPathSum(vector<vector<int>>& grid) {
        int n=grid.size(),m=grid[0].size();
        vector<vector<int>>dp(n,vector<int>(m,-1));
        return f(n-1,m-1,grid,dp);
    }
};




class Solution {
public:
    int minPathSum(vector<vector<int>>& grid) {
        int m=grid.size(),n=grid[0].size();
        vector<vector<int>>dp(m,vector<int>(n,0));
        for(int i=0;i<m;i++)
        {
            for(int j=0;j<n;j++)
            {
                if(i==0&&j==0)
                {
                    dp[i][j]=grid[i][j];
                    continue;
                }
                int l=1e9,u=1e9;
                if(i>0)
                    u=grid[i][j]+dp[i-1][j];
                if(j>0)
                    l=grid[i][j]+dp[i][j-1];
                dp[i][j]=min(u,l);                
            }
        }
        return dp[m-1][n-1];
    }
};


class Solution {
public:
    int minPathSum(vector<vector<int>>& grid) {
        int m=grid.size(),n=grid[0].size();
        vector<int>prev(n,0);
        for(int i=0;i<m;i++)
        {
            vector<int>temp(n,0);
            for(int j=0;j<n;j++)
            {
                if(i==0&&j==0)
                {
                    temp[j]=grid[i][j];
                    continue;
                }
                int l=1e9,u=1e9;
                if(i>0)
                    u=grid[i][j]+prev[j];
                if(j>0)
                    l=grid[i][j]+temp[j-1];
                temp[j]=min(u,l);                
            }
            prev=temp;
        }
        return prev[n-1];
    }
};