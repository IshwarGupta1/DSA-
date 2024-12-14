class Solution {
public:
    int minimumEffortPath(vector<vector<int>>& heights) {
        int n=heights.size();
        int m=heights[0].size();
        priority_queue<pair<pair<int,int>,int>,vector<pair<pair<int,int>,int>>,greater<pair<pair<int,int>,int>>>pq;
        vector<vector<int>>distTo(n,vector<int>(m,1e9));
        distTo[0][0]=0;
        pq.push({{0,0},0});
        int res=1e9;
        int dr[4]={-1,0,1,0};
        int dc[4]={0,1,0,-1};
        while(pq.size()>0)
        {
            auto node=pq.top();
            pq.pop();
            int x=node.first.first;
            int y=node.first.second;
            int d=node.second;
            if(x==n-1&&y==m-1)
                res=min(res,d);
            for(int i=0;i<4;i++)
            {
                int dx=x+dr[i];
                int dy=y+dc[i];
                if(dx>=0&&dx<n&&dy>=0&&dy<m)
                {
                    int md=max(abs(heights[dx][dy]-heights[x][y]),d);
                    if(md<distTo[dx][dy])
                    {
                        distTo[dx][dy]=md;
                        pq.push({{dx,dy},md});
                    }
                }
            }
        }
        return res==1e9?-1:res;
    }
};