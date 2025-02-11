class Solution {
public:
    string clearDigits(string s) {
        stack<char>st;
        for(int i=0;i<s.size();i++)
        {
            if('0'<=s[i]&&s[i]<='9')
            {
                if(st.size()>0)
                    st.pop();
            }
            else
                st.push(s[i]);
        }
        string res;
        while(st.size()>0)
        {
            res.push_back(st.top());
            st.pop();
        }
        reverse(res.begin(),res.end());
        return res;
    }
};