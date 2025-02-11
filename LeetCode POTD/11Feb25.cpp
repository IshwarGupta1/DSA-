class Solution {
public:
    string removeOccurrences(string s, string part) {
        stack<char>st;
        int i=0;
        int len=s.size();
        while(i<len)
        {
            st.push(s[i]);
            if(st.size()>=part.size())
            {
                string checkPart;
                for(int j=0;j<part.size();j++)
                {
                    checkPart.push_back(st.top());
                    st.pop();
                }
                reverse(checkPart.begin(),checkPart.end());
                if(checkPart!=part)
                {
                    for(int j=0;j<checkPart.size();j++)
                    {
                        st.push(checkPart[j]);
                    }
                    checkPart.clear();
                }
            }
            i++;
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