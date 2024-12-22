class Solution {
public:
    int maxProfit(vector<int>& prices) {
        int res=0;
        int p=prices[0];
        for(int i=1;i<prices.size();i++)
        {
            if(p<=prices[i])
                res=max(res,prices[i]-p);
            else
                p=prices[i];
        }   
        return res;
    }
};