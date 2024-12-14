class Solution
{
	public:
	//Function to find the shortest distance of all the vertices
    //from the source vertex S.
    vector <int> dijkstra(int V, vector<vector<int>> adj[], int S)
    {
        // Code here
        priority_queue<pair<int,int>,vector<pair<int,int>>,greater<pair<int,int>>>pq;
        vector<int>dist(V,1e9);
        dist[S]=0;
        pq.push({0,S});
        while(!pq.empty())
        {
            auto p=pq.top();
            pq.pop();
            int d=p.first;
            int n=p.second;
            for(auto it:adj[n])
            {
                int v=it[0];
                int w=it[1];
                if(d+w<dist[v])
                {
                    dist[v]=d+w;
                    pq.push({d+w,v});
                }
            }
        }
        return dist;
    }
};