class Solution {
public:
    int minimumObstacles(vector<vector<int>>& grid) {
        int rows = grid.size();
        int cols = grid[0].size();
        vector<vector<int>>dist(rows ,vector<int>(cols ,1e9));
        priority_queue<tuple<int, int, int>, vector<tuple<int, int, int>>, greater<>> pq;
        vector<int> directions = {-1, 0, 1, 0, -1};
        pq.emplace(0, 0, 0);
        dist[0][0] = 0;
        while(pq.size()>0)
        {
            auto [cost, x, y] = pq.top();
            pq.pop();
            if (x == rows - 1 && y == cols - 1) return cost;
            for (int k = 0; k < 4; ++k) {
                int nx = x + directions[k];
                int ny = y + directions[k + 1];

                if (nx >= 0 && ny >= 0 && nx < rows && ny < cols) {
                    int newCost = cost + grid[nx][ny];
                    if (newCost < dist[nx][ny]) {
                        dist[nx][ny] = newCost;
                        pq.emplace(newCost, nx, ny);
                    }
                }
            }
        }
        return -1;
    }
};