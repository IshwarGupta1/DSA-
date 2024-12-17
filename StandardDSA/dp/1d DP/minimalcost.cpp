int solve(vector<int>&dp, vector<int>& arr, int k, int ind)
    {
        if(ind==0)
            return 0;
        if(dp[ind]!=-1)
            return dp[ind];
        int minVal=1e9;
        for(int i=1;i<=k;i++)
        {
            if(ind-i>=0)
            {
                int diff = abs(arr[ind]-arr[ind-i]);
                minVal= min(minVal,diff+solve(dp,arr,k,ind-i));   
            }
        }
        return dp[ind]=minVal;
    }
    int minimizeCost(int k, vector<int>& arr) {
        // Code here
        int n = arr.size();
        vector<int>dp(n,-1);
        return solve(dp,arr, k,n-1);
    }