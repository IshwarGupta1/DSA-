/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    vector<int> largestValues(TreeNode* root) {
        if(!root)
            return {};
        vector<int>res;
        queue<TreeNode*>q;
        q.push(root);
        while(q.size()>0)
        {
            int n=q.size();
            int m=-2147483648;
            for(int i=0;i<n;i++)
            {
                TreeNode* node=q.front();
                q.pop();
                m=max(m,node->val);
                if(node->left)
                    q.push(node->left);
                if(node->right)
                    q.push(node->right);
            }
            res.push_back(m);
        }
        return res;
    }
};