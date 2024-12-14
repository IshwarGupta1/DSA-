void topoSort(vector<pair<int,int>>adj[], vector<int>&vis, stack<int>&st, int node)
    {
        vis[node]=1;
        for(auto it:adj[node])
        {
            if(!vis[it.first])
                topoSort(adj,vis,st,it.first);
        }
        st.push(node);
    }
    vector<int> shortestPath(int V, int E, vector<vector<int>>& edges) {
        // code here
        vector<int>vis(V,0);
        stack<int>st;
        vector<pair<int,int>>adj[V];
        for(int i=0;i<E;i++)
        {
            adj[edges[i][0]].push_back({edges[i][1],edges[i][2]});
        }
        for(int i=0;i<V;i++)
        {
            if(!vis[i])
                topoSort(adj,vis,st,i);
        }
        vector<int>dist(V,1e9);
        dist[0]=0;
        while(st.size()>0)
        {
            int node=st.top();
            st.pop();
            for(auto it:adj[node])
            {
                if(dist[it.first]>dist[node]+it.second)
                {
                    dist[it.first]=dist[node]+it.second;
                }
            }
        }
        for(int i=0;i<V;i++)
        {
            if(dist[i]==1e9)
                dist[i]=-1;
        }
        return dist;
        
    }