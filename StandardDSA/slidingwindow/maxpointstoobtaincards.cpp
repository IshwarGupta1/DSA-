class Solution {
public:
    int maxScore(vector<int>& c, int k) {
        int s=0;
        int n=c.size();
        for(int i=0;i<n;i++)
            s=s+c[i];
        int t=n-k;
        int s1=1e9;
        int i=0,j=0;
        int s2=0;
        while(j<n)
        {
            s2=s2+c[j];
            if((j-i+1)<t)
                j++;
            else if((j-i+1)==t)
            {
                s1=min(s1,s2);
                j++;
            }
            else
            {
                while((j-i+1)>t)
                {
                    s2=s2-c[i];
                    i++;
                }
                s1=min(s1,s2);
                j++;
            }
        }
        return s-s1;

    }
};