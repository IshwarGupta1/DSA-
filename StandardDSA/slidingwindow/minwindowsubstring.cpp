class Solution {
public:
    string minWindow(string s, string t) {
        unordered_map<char, int> mpp1; 
        unordered_map<char, int> mpp2;
        int ri = -1, rj = -1;         

        
        for (char c : t) {
            mpp2[c]++;
        }

        int i = 0, j = 0, cnt = 0;    
        int res = 1e9;              
        int required = mpp2.size();   
        while (j < s.size()) {
            char endChar = s[j];
            mpp1[endChar]++;

            if (mpp2.count(endChar) && mpp1[endChar] == mpp2[endChar]) {
                cnt++;
            }

            
            while (cnt == required) {
                if (j - i + 1 < res) {
                    res = j - i + 1;
                    ri = i;
                    rj = j;
                }

                char startChar = s[i];
                mpp1[startChar]--;

               
                if (mpp2.count(startChar) && mpp1[startChar] < mpp2[startChar]) {
                    cnt--;
                }

                i++; 
            }

            j++;
        }
        if (res == 1e9) return "";
        return s.substr(ri, res);
    }
};