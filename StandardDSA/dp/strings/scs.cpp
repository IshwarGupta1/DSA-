class Solution {
public:
    string longestCommonSubsequence(string text1, string text2) {
        int m = text1.size(), n = text2.size();
        vector<vector<int>> dp(m + 1, vector<int>(n + 1, 0));

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (text1[i - 1] == text2[j - 1]) {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                } else {
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        string res;
        int i = m, j = n;
        while (i > 0 && j > 0) {
            if (text1[i - 1] == text2[j - 1]) {
                res.push_back(text1[i - 1]);
                i--;
                j--;
            } else if (dp[i - 1][j] > dp[i][j - 1]) {
                i--;
            } else {
                j--;
            }
        }
        reverse(res.begin(), res.end());
        return res;
    }

    string shortestCommonSupersequence(string str1, string str2) {
        string lcs = longestCommonSubsequence(str1, str2);
        string res;
        int i = 0, j = 0;

        for (char c : lcs) {
            while (i < str1.size() && str1[i] != c) {
                res.push_back(str1[i]);
                i++;
            }
            while (j < str2.size() && str2[j] != c) {
                res.push_back(str2[j]);
                j++;
            }
            res.push_back(c);
            i++;
            j++;
        }

        while (i < str1.size()) res.push_back(str1[i++]);
        while (j < str2.size()) res.push_back(str2[j++]);

        return res;
    }
};