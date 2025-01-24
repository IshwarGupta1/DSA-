class Solution {
public:
    vector<int> eventualSafeNodes(vector<vector<int>>& graph) {
        int n = graph.size();
        vector<vector<int>> reverseGraph(n);
        vector<int> indegree(n, 0);
        queue<int> q;
        vector<int> safeNodes;
        
        // Build the reverse graph and calculate the in-degrees
        for (int i = 0; i < n; i++) {
            for (int neighbor : graph[i]) {
                reverseGraph[neighbor].push_back(i);
                indegree[i]++;
            }
        }
        
        // Start with nodes that have zero in-degrees
        for (int i = 0; i < n; i++) {
            if (indegree[i] == 0) {
                q.push(i);
            }
        }
        
        // Perform BFS/Topological sorting
        while (!q.empty()) {
            int node = q.front();
            q.pop();
            safeNodes.push_back(node);
            for (int neighbor : reverseGraph[node]) {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    q.push(neighbor);
                }
            }
        }
        
        // Sort the result to meet the problem's requirement
        sort(safeNodes.begin(), safeNodes.end());
        return safeNodes;
    }
};