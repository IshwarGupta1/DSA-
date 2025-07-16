class Solution {
public:
    bool checkSubarraySum(vector<int>& nums, int k) {
        int sum=0;
        for(int i=0;i<nums.size()-1;i++)
        {
            sum=nums[i];
            for(int j=i+1;j<nums.size();j++)
            {
                sum=sum+nums[j];
                if(sum%k==0)
                    return true;
            }
        }
        return false;
    }
};