class Solution {
public:
    int minBitFlips(int start, int goal) {
        int n=start^goal;
        int cnt=0;
        while(n)
        {
            if(n&1)
                cnt++;
            n=n>>1;
        }
        return cnt;
    }
};