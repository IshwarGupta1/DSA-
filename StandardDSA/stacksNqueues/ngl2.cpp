class Solution {
public:
    vector<int> nextGreaterElements(vector<int>& nums) {
        vector<int>v=nums;
        for(auto it:nums)
            v.push_back(it);
        stack<int>s;
        vector<int>res;
        for(int i=v.size()-1;i>=0;i--)
        {
                while(s.size()>0&&s.top()<=v[i])
                    s.pop();
                if(s.size()==0)
                {
                    res.push_back(-1);
                }
                else
                    res.push_back(s.top());
            s.push(v[i]);
        } 
        reverse(res.begin(),res.end());
        vector<int>ans;
        for(int i=0;i<nums.size();i++)
            ans.push_back(res[i]);
        return ans;
    }
};