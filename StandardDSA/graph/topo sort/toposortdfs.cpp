class Solution {
  public:
    // Function to return list containing vertices in Topological order.
    void dfs(vector<int>adjl[], vector<int>&vis, int node, stack<int>&st)
    {
        vis[node]=1;
        for(auto it:adjl[node])
            dfs(adjl,vis,it,st);
        st.push(node);
    }
    vector<int> topologicalSort(vector<vector<int>>& adj) {
        // Your code here
        stack<int>st;
        int n=adj.size();
        vector<int>adjl[n];
        for(int i=0;i<n;i++)
        {
            for(int j=0;j<adj[i].size();j++)
            {
                adjl[i].push_back(adj[i][j]);
            }
        }
        vector<int>vis(n,0);
        for(int i=0;i<n;i++)
        {
            if(!vis[i])
                dfs(adjl,vis,i,st);
        }
        vector<int>res;
        while(st.size()>0)
        {
            res.push_back(st.top());
            st.pop();
        }
        return res;
    }
};