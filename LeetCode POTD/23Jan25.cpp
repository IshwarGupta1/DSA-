class Solution {
public:
    int countServers(vector<vector<int>>& grid) {
        int cnt=0;
        int m=grid.size(),n=grid[0].size();
        vector<int>rc(m,0);
        vector<int>cc(n,0);
        for(int i=0;i<grid.size();i++)
        {
            for(int j=0;j<grid[0].size();j++)
            {
                if(grid[i][j]==1)
                {
                    rc[i]++;
                    cc[j]++;
                }
            }
        }
        for(int i=0;i<grid.size();i++)
        {
            for(int j=0;j<grid[0].size();j++)
            {
                if(grid[i][j]==1&&(rc[i]>1||cc[j]>1))
                    cnt++;
            }
        }
        return cnt;
    }
};