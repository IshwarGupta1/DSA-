class Solution {
public:
    vector<int> finalPrices(vector<int>& prices) {
        vector<int>res;
        for(int i=0;i<prices.size()-1;i++)
        {
            priority_queue<int,vector<int>,greater<int>>pq;
            int j=i+1;
            while(j<prices.size())
            {
                if(prices[j]<=prices[i])
                    pq.push(j);
                j++;
            }
            if(pq.size()>0)
                res.push_back(prices[i]-prices[pq.top()]);
            else
                res.push_back(prices[i]);
        }
        res.push_back(prices[prices.size()-1]);
        return res;
    }

};