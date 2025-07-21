class Solution {
public:
    bool isPossible(vector<int>& nums) {
        unordered_map<int, int> mpp1;
        unordered_map<int, int> mpp2;

        for (int i = 0; i < nums.size(); i++) {
            mpp1[nums[i]]++;
        }

        for (int i = 0; i < nums.size(); i++) {
            if (mpp1[nums[i]] == 0) continue;

            if (mpp2[nums[i]] > 0) {
                mpp2[nums[i]]--;
                mpp2[nums[i] + 1]++;
            } else if (mpp1[nums[i] + 1] > 0 && mpp1[nums[i] + 2] > 0) {
                mpp1[nums[i] + 1]--;
                mpp1[nums[i] + 2]--;
                mpp2[nums[i] + 3]++;
            } else {
                return false;
            }

            mpp1[nums[i]]--;
        }

        return true;
    }
};
