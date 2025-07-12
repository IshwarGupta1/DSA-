class Solution {
public:
    vector<int> minOperations(string boxes) {
        vector<int>res(boxes.size(),0);
        for(int i=0;i<boxes.size();i++)
        {
            int s=0;
            for(int j=0;j<boxes.size();j++)
            {
                if(boxes[j]=='1')
                {
                    s=s+abs(j-i);
                }
            }
            res[i]=s;
        }
        return res;
    }
};