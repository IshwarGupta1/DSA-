class Solution {
public:
    string repeatLimitedString(string s, int repeatLimit) {
        // Count character frequencies
        unordered_map<char, int> freq;
        for (char c : s) {
            freq[c]++;
        }
        priority_queue<pair<char, int>> pq;
        for (auto &[ch, count] : freq) {
            pq.push({ch, count});
        }

        string result = "";
        char lastUsed = '\0';

        while (!pq.empty()) {
            auto [ch, count] = pq.top();
            pq.pop();

            if (ch == lastUsed && pq.empty()) {
                break;
            }

            if (ch == lastUsed) {
                auto [nextCh, nextCount] = pq.top();
                pq.pop();

                result += nextCh;
                lastUsed = nextCh;

                if (--nextCount > 0) {
                    pq.push({nextCh, nextCount});
                }
                pq.push({ch, count});
            } else {
                int addCount = min(count, repeatLimit);
                result += string(addCount, ch);
                lastUsed = ch;
                if (count > repeatLimit) {
                    pq.push({ch, count - repeatLimit});
                }
            }
        }
        return result;
    }
};