class Solution {
public:
    vector<vector<int>> threeSum(vector<int>& nums) {
        sort(nums.begin(),nums.end());
        set<vector<int>>res;
        for(int i=0;i<nums.size();i++)
        {
            int t=nums[i];
            int j=i+1,k=nums.size()-1;
            while(j<k)
            {
                int s=nums[j]+nums[k];
                if(s+t==0)
                {
                    vector<int>v;
                    v.push_back(nums[i]);
                    v.push_back(nums[j]);
                    v.push_back(nums[k]);
                    res.insert(v);
                    j++;
                    k--;
                }
                else if(s+t>0)
                {
                    k--;
                }
                else
                    j++;
            }
        }
        vector<vector<int>>ans;
        for(auto it:res)
            ans.push_back(it);
        return ans;
    }
};