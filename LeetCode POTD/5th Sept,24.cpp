class Solution {
public:
    vector<int> missingRolls(vector<int>& rolls, int mean, int n) {
        int m=rolls.size();
        int sumM=0;
        for(auto it:rolls)
        {
            sumM=sumM+it;
        }
        int totalSum=mean*(n+m);
        int sumN=totalSum-sumM;
        if(sumN>6*n || sumN<=0)
            return {};
        vector<int>res(n,0);
        int di=sumN/n;
        if(di==0)
            return {};
        int dr=sumN%n;
        cout<<di<<" "<<dr<<endl;
        for(int i=0;i<n;i++)
            res[i]=di;
        int j=n-1;
        if(res[n-1]+dr<=6)
            res[n-1]=res[n-1]+dr;
        else
        {
            int i=n-1;
            while(dr>0)
            {
                dr--;
                res[j]++;
                j--;
            }
        }
        return res;
    }
};