class Solution {
public:
    int solve(vector<int>&nums,vector<vector<int>>&dp,int prev,int curr)
    {
        if(curr==nums.size())
            return 0;
        if(dp[prev+1][curr]!=-1)
            return dp[prev+1][curr];
        int nt=solve(nums,dp,prev,curr+1);
        int t=0;
        if(prev==-1||nums[curr]>nums[prev])
            t=1+solve(nums,dp,curr,curr+1);
        return dp[prev+1][curr]=max(t,nt);
    }
    int lengthOfLIS(vector<int>& nums) {
        int n=nums.size();
        vector<vector<int>>dp(n+1,vector<int>(n,-1));
        return solve(nums,dp,-1,0);
    }
};







int longestIncreasingSubsequence(int arr[], int n){
    
    vector<vector<int>> dp(n+1,vector<int>(n+1,0));
    
    for(int ind = n-1; ind>=0; ind --){
        for (int prev_index = ind-1; prev_index >=-1; prev_index --){
            
            int notTake = 0 + dp[ind+1][prev_index +1];
    
            int take = 0;
    
            if(prev_index == -1 || arr[ind] > arr[prev_index]){
                
                take = 1 + dp[ind+1][ind+1];
            }
    
            dp[ind][prev_index+1] = max(notTake,take);
            
        }
    }
    
    return dp[0][0];
}