class Solution {
public:
    int findMaxLength(vector<int>& nums) {
        vector<int> prefixSum(nums.size());
        unordered_map<int, int> mp;
        int sum = 0;
        for (int i = 0; i < nums.size(); i++) {
            sum += (nums[i] == 0) ? -1 : 1;
            prefixSum[i] = sum;
        }

        int maxLen = 0;
        mp[0] = -1;

        for (int i = 0; i < prefixSum.size(); i++) {
            int s = prefixSum[i];
            if (mp.count(s)) {
                maxLen = max(maxLen, i - mp[s]);
            } else {
                mp[s] = i;
            }
        }
        return maxLen;
    }
};
