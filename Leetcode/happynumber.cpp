class Solution {
public:
    int getNextNumber(int n) {
        int output = 0;
        
        while (n > 0) {
            int digit = n % 10;
            output += digit * digit;
            n = n / 10;
        }
        
        return output;
    }

    bool isHappy(int n) {
        unordered_set<int>vis;
        while(vis.find(n)==vis.end())
        {
            vis.insert(n);
            n=getNextNumber(n);
            if(n==1)
                return true;
        }
        return false;
    }
};