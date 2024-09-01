Complexity
Time complexity: O(m*n)

Space complexity: O(1)

Code
class Solution {
public:
    vector<vector<int>> construct2DArray(vector<int>& original, int m, int n) {
        int originalSize=original.size();
        if(m*n!=originalSize)
            return {};
        int lowerBound=0,upperBound=n-1;
        vector<vector<int>>res(m,vector<int>(n,0));
        for(int i=0;i<m;i++)
        {
            if(upperBound>=originalSize)
                break;
            for(int j=lowerBound;j<=upperBound;j++)
            {
                res[i][j-lowerBound]=original[j];
            }
            lowerBound=lowerBound+n;
            upperBound=upperBound+n;
        }
        return res;
    }
};
Complexity
Time complexity: O(n)

Space complexity: O(1)

Code
class Solution {
public:
    vector<vector<int>> construct2DArray(vector<int>& original, int m, int n) {
        int originalSize=original.size();
        if(m*n!=originalSize)
            return {};
        int lowerBound=0,upperBound=n-1;
        vector<vector<int>>res(m,vector<int>(n,0));
        for(int i=0;i<m;i++)
        {
            if(upperBound>=originalSize)
                break;
            for(int j=lowerBound;j<=upperBound;j++)
            {
                res[i][j-lowerBound]=original[j];
            }
            lowerBound=lowerBound+n;
            upperBound=upperBound+n;
        }
        return res;
    }
};
