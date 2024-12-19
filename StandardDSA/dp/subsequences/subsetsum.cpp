// User function template for C++

class Solution {
  public:
    bool solve(vector<int>&arr, int target, int ind)
    {
        if(target==0)
            return true;
        if(ind==0)
            return target==arr[ind];
        bool nt=solve(arr, target, ind-1);
        bool t=solve(arr, target-arr[ind],ind-1);
        return t||nt;
    }
    bool isSubsetSum(vector<int>& arr, int target) {
        // code here
        return solve(arr,target,arr.size()-1);
    }
};




// User function template for C++

class Solution {
  public:
    bool solve(vector<int>&arr, vector<vector<int>>&dp, int target, int ind)
    {
        if(target==0)
            return dp[ind][target]=true;
        if(ind==0)
            return dp[ind][target]=(target==arr[ind]);
        if(dp[ind][target]!=-1)
            return dp[ind][target];
        bool nt=solve(arr, dp, target, ind-1);
        bool t=false;
        if(target>=arr[ind])
            t=solve(arr, dp, target-arr[ind],ind-1);
        return dp[ind][target]=t||nt;
    }
    bool isSubsetSum(vector<int>& arr, int target) {
        // code here
        int n=arr.size();
        vector<vector<int>>dp(n,vector<int>(target+1,-1));
        return solve(arr,dp,target,arr.size()-1);
    }
};




bool isSubsetSum(vector<int>& arr, int target) {
        // code here
        int n=arr.size();
        vector<vector<int>>dp(n,vector<int>(target+1,0));
        for(int i=0;i<n;i++)
            dp[i][0]=1;
        if(arr[0]<=target)
            dp[0][arr[0]]=1;
        for(int i=1;i<n;i++)
        {
            for(int j=1;j<=target;j++)
            {
                bool nt = dp[i-1][j];
                bool t=false;
                if(arr[i]<=j)
                    t= dp[i-1][j-arr[i]];
                dp[i][j]=t||nt;
            }
        }
        return dp[arr.size()-1][target];
    }
	
	
	
// User function template for C++

class Solution {
  public:
    bool isSubsetSum(vector<int>& arr, int target) {
        // code here
        int n=arr.size();
        vector<bool>prev(target+1,false);
        prev[0]=true;
        if(arr[0]<=target)
            prev[arr[0]]=true;
        for(int i=1;i<n;i++)
        {
            vector<bool>curr(target+1,false);
            curr[0]=true;
            for(int j=1;j<=target;j++)
            {
                bool nt=prev[j];
                bool t=false;
                if(arr[i]<=j)
                    t=prev[j-arr[i]];
                curr[j]=t||nt;
            }
            prev=curr;
        }
        return prev[target];
    }
};