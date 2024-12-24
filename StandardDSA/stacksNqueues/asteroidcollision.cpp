class Solution {
public:
    bool check(int a, int b)
    {
        return a>0&&b<0;
    }
    vector<int> asteroidCollision(vector<int>& asteroids) {
        stack<int>s;
        s.push(asteroids[0]);
        for(int i=1;i<asteroids.size();i++)
        {
            bool collide=false;
            while(s.size()>0&&check(s.top(),asteroids[i]))
            {
                collide=true;
                if(s.top()>abs(asteroids[i]))
                {
                    asteroids[i]=0;
                }
                else if(s.top()==abs(asteroids[i]))
                {
                    s.pop();
                    asteroids[i]=0;
                }
                else
                {
                    s.pop();
                }
            }
            if(asteroids[i]!=0||!collide)
                s.push(asteroids[i]);
        }
        vector<int>res;
        while(!s.empty())
        {
            res.push_back(s.top());
            s.pop();
        }
        reverse(res.begin(),res.end());
        return res;
    }
};