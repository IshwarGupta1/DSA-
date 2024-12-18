class Solution {
public:
    int uniquePathsWithObstacles(vector<vector<int>>& obstacleGrid) {
        int m = obstacleGrid.size();
        int n = obstacleGrid[0].size();

        if (obstacleGrid[0][0] == 1) // Starting point is blocked
            return 0;

        vector<int> prev(n, 0);

        for (int i = 0; i < m; i++) {
            vector<int> temp(n, 0);
            for (int j = 0; j < n; j++) {
                if (obstacleGrid[i][j] == 1) {
                    temp[j] = 0; // Cell is blocked
                    continue;
                }
                if (i == 0 && j == 0) {
                    temp[j] = 1; // Start point
                } else {
                    int up = 0, left = 0;
                    if (i > 0) up = prev[j];
                    if (j > 0) left = temp[j - 1];
                    temp[j] = up + left;
                }
            }
            prev = temp;
        }

        return prev[n - 1];
    }
};
