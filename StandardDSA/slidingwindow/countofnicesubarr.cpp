class Solution {
public:
    int helper(vector<int>&nums, int k)
    {
        int i=0,j=0;
        int res=0,cnt=0;
        while(j<nums.size())
        {
            if(nums[j]%2)
                cnt++;
            if(cnt<=k)
            {
                res=res+(j-i+1);
                j++;
            }
            else
            {
                while(cnt>k)
                {
                    if(nums[i]%2)
                        cnt--;
                    i++;
                }
                res=res+(j-i+1);
                j++;
            }
        }
        return res;
    }
    int numberOfSubarrays(vector<int>& nums, int k) {
        return helper(nums,k)-helper(nums,k-1);
    }
};