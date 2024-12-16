public:
	//Function to find sum of weights of edges of the Minimum Spanning Tree.
    int spanningTree(int V, vector<vector<int>> adj[])
    {
        // code here
        priority_queue<pair<int,int>,vector<pair<int,int>>, greater<pair<int,int>>>pq;
        pq.push({0,0});
        int sum=0;
        vector<int>vis(V,0);
        while(pq.size()>0)
        {
            auto p=pq.top();
            pq.pop();
            int node=p.second;
            int wt=p.first;
            if(vis[node]==1)
                continue;
            vis[node]=1;
            sum=sum+wt;
            for(auto it:adj[node])
            {
                int adjNode=it[0];
                int wt=it[1];
                if(!vis[adjNode])
                    pq.push({wt,adjNode});
            }
        }
        return sum;
    }
};