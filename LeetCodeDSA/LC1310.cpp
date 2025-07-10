class Solution {
public:
    vector<int> xorQueries(vector<int>& arr, vector<vector<int>>& queries) {
        vector<int>pre(arr.size(),0);
        pre[0]=arr[0];
        for(int i=1;i<arr.size();i++)
        {
            pre[i]=pre[i-1]^arr[i];
        }
        vector<int>res;
        for(int i=0;i<queries.size();i++)
        {
            if(queries[i][0]==0)
                res.push_back(pre[queries[i][1]]);
            else
            {
                int ans=pre[queries[i][0]-1]^pre[queries[i][1]];
                res.push_back(ans);
            }
        }
        return res;
    }
};