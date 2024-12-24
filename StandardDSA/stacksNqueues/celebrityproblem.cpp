class Solution {
  public:
    // Function to find if there is a celebrity in the party or not.
    int celebrity(vector<vector<int> >& mat) {
        // code here
        stack<int>st;
        for(int i=0;i<mat.size();i++)
            st.push(i);
        while(st.size()>1)
        {
            int a=st.top();
            st.pop();
            int b=st.top();
            st.pop();
            if(mat[a][b]==1&&mat[b][a]==0)
                st.push(b);
            else if(mat[a][b]==0&&mat[b][a]==1)
                st.push(a);
            else
                continue;
        }
        if(st.size()==0)
            return -1;
        int c=st.top();
        //cout<<c;
        for(int i=0;i<mat.size();i++)
        {
            if((mat[i][c]==0||mat[c][i]==1)&&i!=c)
                return -1;
        }
        return c;
        
    }
};