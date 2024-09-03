class Solution {
public:
    int chalkReplacer(vector<int>& chalk, int k) {
        int len=chalk.size();
        long long sum=0;
        for(auto it:chalk)
        {
            sum=sum+it;
        }
        long long rem=k%sum;
        if(rem==0)
            return 0;
        int s=0;
        for(int i=0;i<len;i++)
        {
            if(rem<chalk[i])
                return i;
            rem=rem-chalk[i];
        }
        return 0;
    }
};
