vector<int> shortestPath(vector<vector<int>>& edges, int N,int M, int src){
        // code here
        vector<int>adj[N];
        for(int i=0;i<edges.size();i++)
        {
            adj[edges[i][0]].push_back(edges[i][1]); 
            adj[edges[i][1]].push_back(edges[i][0]);
        }
        vector<int>vis(N,1e9);
        vis[src]=0;
        queue<int>q;
        q.push(src);
        while(q.size()>0)
        {
            int node=q.front();
            q.pop();
            for(auto it:adj[node])
            {
                if(vis[it]>1+vis[node])
                {
                    vis[it]=vis[node]+1;
                    q.push(it);
                }
            }
        }
        for(int i=0;i<vis.size();i++)
        {
            if(vis[i]==1e9)
                vis[i]=-1;
        }
        return vis;
    }