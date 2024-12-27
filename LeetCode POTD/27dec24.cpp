class Solution {
public:
    int maxScoreSightseeingPair(vector<int>& values) {
        int n=values.size();
        vector<int>maxl(n,0);
        maxl[0]=values[0];
        int res=0;
        for(int i=1;i<n;i++)
        {
            res=max(res,maxl[i-1]+values[i]-i);
            maxl[i]=max(maxl[i-1],values[i]+i);
        }
        return res;
    }
};