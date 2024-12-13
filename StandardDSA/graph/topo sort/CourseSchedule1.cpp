class Solution {
public:
    bool canFinish(int numCourses, vector<vector<int>>& prerequisites) {
        vector<int>adj[numCourses];
        for(int i=0;i<prerequisites.size();i++)
        {
           adj[prerequisites[i][1]].push_back(prerequisites[i][0]);
        }
        vector<int>vis(numCourses,0);
        vector<int>indeg(numCourses,0);
        queue<int>q;
        for(int i=0;i<numCourses;i++)
        {
            for(auto it:adj[i])
            {
                indeg[it]++;
            }
        }
        for(int i=0;i<numCourses;i++)
        {
            if(indeg[i]==0)
                q.push(i);
        }
        vector<int>res;
        while(q.size()>0)
        {
            int node=q.front();
            q.pop();
            res.push_back(node);
            for(auto it:adj[node])
            {
                indeg[it]--;
                if(indeg[it]==0)
                    q.push(it);
            }
        }
        return res.size()==numCourses;
    }
};