class Solution {
public:
    int f(int i,int j,vector<vector<int>>&v,int n,vector<vector<int>>&dp)
    {
        if(i==n-1)
            return v[n-1][j];
        if(dp[i][j]!=-1)
            return dp[i][j];
        int down=v[i][j]+f(i+1,j,v,n,dp);
        int diag=v[i][j]+f(i+1,j+1,v,n,dp);
        return dp[i][j]=min(down,diag);
    }
    int minimumTotal(vector<vector<int>>& triangle) {
        int n=triangle.size();
        vector<vector<int>>dp(n,vector<int>(n,-1));
        return f(0,0,triangle,n,dp);
    }
};

class Solution {
public:
    int f(int i,int j,vector<vector<int>>&v,int n,vector<vector<int>>&dp)
    {
        if(i==n-1)
            return v[n-1][j];
        if(dp[i][j]!=-1)
            return dp[i][j];
        int down=v[i][j]+f(i+1,j,v,n,dp);
        int diag=v[i][j]+f(i+1,j+1,v,n,dp);
        return dp[i][j]=min(down,diag);
    }
    int minimumTotal(vector<vector<int>>& triangle) {
        int n=triangle.size();
        vector<vector<int>>dp(n,vector<int>(n,0));
        for(int i=0;i<n;i++)
            dp[n-1][i]=triangle[n-1][i];
        for(int i=n-2;i>=0;i--)
        {
            vector<int>
            for(int j=i;j>=0;j--)
            {
                int down=triangle[i][j]+dp[i+1][j];
                int diag=triangle[i][j]+dp[i+1][j+1];
                dp[i][j]=min(down,diag);
            }
        }
        return dp[0][0];
    }
};


#include <bits/stdc++.h>
using namespace std;

// Function to find the minimum path sum in the given triangle using dynamic programming
int minimumPathSum(vector<vector<int>> &triangle, int n) {
    // Create two arrays to store the current and previous row values
    vector<int> front(n, 0); // Represents the previous row
    vector<int> cur(n, 0);   // Represents the current row
    
    // Initialize the front array with values from the last row of the triangle
    for (int j = 0; j < n; j++) {
        front[j] = triangle[n - 1][j];
    }
    
    // Iterate through the triangle rows in reverse order
    for (int i = n - 2; i >= 0; i--) {
        for (int j = i; j >= 0; j--) {
            // Calculate the minimum path sum for the current cell
            int down = triangle[i][j] + front[j];
            int diagonal = triangle[i][j] + front[j + 1];
            
            // Store the minimum of the two possible paths in the current row
            cur[j] = min(down, diagonal);
        }
        // Update the front array with the values from the current row
        front = cur;
    }
    
    // The front array now contains the minimum path sum from the top to the bottom of the triangle
    return front[0];
}

int main() {
    // Define the triangle as a 2D vector
    vector<vector<int>> triangle{{1},
                                  {2, 3},
                                  {3, 6, 7},
                                  {8, 9, 6, 10}};

    // Get the number of rows in the triangle
    int n = triangle.size();

    // Call the minimumPathSum function and print the result
    cout << minimumPathSum(triangle, n);

    return 0;
}

