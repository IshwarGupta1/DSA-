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
    int gcdoftwo(int a,int b)
    {
        if(a==0)
            return b;
        if(b==0)
            return a;
        if(a==b)
            return a;
        if(a>b)
            return gcdoftwo(a-b,b);
        return gcdoftwo(a,b-a);
    }
    ListNode* insertGreatestCommonDivisors(ListNode* head) {
        ListNode* temp=head;
        while(temp->next)
        {
            int val=gcdoftwo(temp->val,temp->next->val);
            ListNode* newL = new ListNode(val);
            ListNode* nxt=temp->next;
            temp->next=newL;
            newL->next=nxt;
            temp=temp->next->next;
        }
        return head;
    }
};