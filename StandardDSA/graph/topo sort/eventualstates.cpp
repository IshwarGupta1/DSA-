class Solution {
public:
    vector<int> eventualSafeNodes(vector<vector<int>>& graph) {
        int n = graph.size();
        vector<vector<int>> adj(n); // Adjacency list for reversed graph
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < graph[i].size(); j++) {
                adj[graph[i][j]].push_back(i); // Reverse the edge
            }
        }

        vector<int> indeg(n, 0); // In-degree of each node
        for (int i = 0; i < n; i++) {
            for (auto it : adj[i]) {
                indeg[it]++;
            }
        }

        queue<int> q;
        for (int i = 0; i < n; i++) {
            if (indeg[i] == 0) {
                q.push(i); // Terminal nodes
            }
        }

        vector<int> res;
        while (!q.empty()) {
            int node = q.front();
            q.pop();
            res.push_back(node);
            for (auto it : adj[node]) {
                indeg[it]--;
                if (indeg[it] == 0) {
                    q.push(it);
                }
            }
        }

        sort(res.begin(), res.end()); // Sort the result
        return res;
    }
};
