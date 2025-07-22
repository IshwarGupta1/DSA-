class Solution {
public:
    int numSubarrayProductLessThanK(vector<int>& nums, int k) {
		long long prod=1;
		int res=0;
		int j=0;
		for(int i=0;i<nums.size();i++)
		{
			prod=prod*nums[i];
			while(prod>=k)
			{
				prod=prod/nums[j];
				j++;
			}
			res=res+(j-i+1);
		}
		return res;
	}	
}