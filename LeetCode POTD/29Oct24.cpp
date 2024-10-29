class Solution {
public:
    bool isValid(int x,int y, int n, int m)
    {
        return ((x>=0&&x<n)&&(y>=0&&y<m));
    }
    int solve(int i, int j,vector<vector<int>>& grid, vector<vector<int>>&dp)
    {
        if(j==grid[0].size()-1)
            return dp[i][j]=0;
        if(dp[i][j]!=-1)
            return dp[i][j];
        int a=0,b=0,c=0;
        if(isValid(i-1,j+1,grid.size(),grid[0].size())&&grid[i][j]<grid[i-1][j+1])
            a=1+solve(i-1,j+1,grid,dp);
        if(isValid(i+1,j+1,grid.size(),grid[0].size())&&grid[i][j]<grid[i+1][j+1])
            b=1+solve(i+1,j+1,grid,dp);
        if(isValid(i,j+1,grid.size(),grid[0].size())&&grid[i][j]<grid[i][j+1])
            c=1+solve(i,j+1,grid,dp);
        return dp[i][j]=max(a,max(b,c));
    }
    int maxMoves(vector<vector<int>>& grid) {
        int res=0;
        int n=grid.size(),m=grid[0].size();
        vector<vector<int>>dp(n,vector<int>(m,-1));
        for(int i=0;i<grid.size();i++)
        {
            res=max(res,solve(i,0,grid,dp));
        }
        return res;
    }
};