class Solution {
public:
    int minFallingPathSum(vector<vector<int>>& matrix) {
        int n=matrix.size();
        vector<vector<int>> dp(n,vector<int>(n,INT_MIN));
        int ans=INT_MAX;
        for(int i=0;i<n;i++){
            ans=min(ans,f(matrix,0,i,dp));
        }
        return ans;
    }
private:
    int f(vector<vector<int>>& matrix,int i,int j,vector<vector<int>>& dp){
        if(j<0) return INT_MAX;
        if(j>=matrix.size()) return INT_MAX;
        if(i==matrix.size()-1) return matrix[i][j];
        if(dp[i][j]!=INT_MIN) return dp[i][j];
        int a=f(matrix,i+1,j-1,dp);
        int b=f(matrix,i+1,j,dp);
        int c=f(matrix,i+1,j+1,dp);
        return dp[i][j]=min(a,min(b,c))+matrix[i][j];
    }
};


class Solution3 {
public:
    int minFallingPathSum(vector<vector<int>>& matrix) {
        int n=matrix.size();
        vector<vector<int>> dp(n,vector<int>(n,INT_MIN));
        for(int i=0;i<n;i++) dp[n-1][i]=matrix[n-1][i];
        for(int i=n-2;i>=0;i--){
            for(int j=0;j<n;j++){
                int a=dp[i+1][j];
                if(j-1>=0) a=min(a,dp[i+1][j-1]);
                if(j+1<n) a=min(a,dp[i+1][j+1]);
                dp[i][j]=a+matrix[i][j];
            }
        }
        int ans=INT_MAX;
        for(int i=0;i<n;i++) ans=min(ans,dp[0][i]);
        return ans;
    }