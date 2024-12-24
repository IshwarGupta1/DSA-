class Solution {
public:
    bool isValid(string s) {
        stack<char>st;
        for(int i=0;i<s.size();i++)
        {
            if(st.size()==0)
                st.push(s[i]);
            else if(s[i]=='}'||s[i]==']'||s[i]==')')
            {
                if(s[i]=='}')
                {
                    if(st.top()=='{')
                        st.pop();
                    else
                        return false;
                }
                else if(s[i]==']')
                {
                    if(st.top()=='[')
                        st.pop();
                    else
                        return false;
                }
                else
                {
                    if(st.top()=='(')
                        st.pop();
                    else
                        return false;
                }
            }
            else
                st.push(s[i]);
        }
        return st.size()==0;
    }
};