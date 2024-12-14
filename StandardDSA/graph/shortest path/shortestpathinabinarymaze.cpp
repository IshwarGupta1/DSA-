class Solution {
public:
    int shortestPathBinaryMatrix(vector<vector<int>>& grid) {
        int m=grid.size();
        int n=grid.size();
        if(grid[0][0]==1||grid[m-1][n-1]==1)
            return -1;
        vector<vector<int>>dist(m,vector<int>(n,1e9));
        queue<pair<int,int>>q;
        q.push({0,0});
        dist[0][0]=1;
        while(q.size()>0)
        {
            auto p=q.front();
            q.pop();
            int x=p.first;
            int y=p.second;
            for(int i=-1;i<=1;i++)
            {
                for(int j=-1;j<=1;j++)
                {
                    int nx=x+i;
                    int ny=y+j;
                    if(nx>=0&&nx<m&&ny>=0&&ny<n&&grid[nx][ny]==0)
                    {
                        if(dist[nx][ny]>1+dist[x][y])
                        {
                            dist[nx][ny]=1+dist[x][y];
                            q.push({nx,ny});
                        }
                    }
                }
            }
        }
        return dist[m-1][n-1]==1e9?-1:dist[m-1][n-1];
    }
};