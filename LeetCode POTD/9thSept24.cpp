/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
public:
    vector<vector<int>> spiralMatrix(int m, int n, ListNode* head) {
        vector<vector<int>>res(m,vector<int>(n));
        int t=0,l=0,b=m-1,r=n-1;
        ListNode* temp=head;
        while(t<=b&&l<=r)
        {
            for(int i=l;i<=r;i++)
            {
                if(temp)
                {
                    res[t][i]=temp->val;
                    temp=temp->next;
                }
                else
                    res[t][i]=-1;
            }
            t++;
            for(int i=t;i<=b;i++)
            {
                if(temp)
                {
                    res[i][r]=temp->val;
                    temp=temp->next;
                }
                else
                    res[i][r]=-1;
            }
            r--;
            if(t<=b)
            {
                for(int i=r;i>=l;i--)
                {
                    if(temp)
                    {
                        res[b][i]=temp->val;
                        temp=temp->next;
                    }
                    else
                        res[b][i]=-1;
                }
                b--;
            }
            if(l<=r)
            {
                for(int i=b;i>=t;i--)
                {
                    if(temp)
                    {
                        res[i][l]=temp->val;
                        temp=temp->next;
                    }
                    else
                        res[i][l]=-1;
                }
                l++;
            }
        }
        return res;      
    }
};