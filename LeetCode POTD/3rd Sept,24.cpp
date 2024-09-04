class Solution {
public:
    string getAxis(string currentAxis, int shift)
    {
        if(shift==-2)
        {
            if(axis=="y")
            {
                axis="-x";
            }
            else if(axis=="-y")
            {
                axis="x";   
            }
            else if(axis=="x")
            {
                axis="y";
            }
            else if(axis=="-x")
            {
                axis="-y";
            }
        }
        else
        {
            if(axis=="y")
            {
                axis="x";
            }
            else if(axis=="-y")
            {
                axis="-x";   
            }
            else if(axis=="x")
            {
                axis="-y";
            }
            else if(axis=="-x")
            {
                axis="y";
            }
        }
        return axis;
    }
    
    bool checkObstacle(vector<vector<int>>& obstacles, int cx, int cy)
    {
        for(auto it:obstacles)
        {
            if(cx==it[0] || cy==it[1])
                return true;
        }
        return false;
    }
    pair<int,int> update(pair<int,int> c,int dist,string axis)
    {
        if(axis=="y")
            c.second+=dist;
        else if(axis=="-y")
            c.second-=dist;
        else if(axis=="x")
            c.first+=dist;
        else
            c.first-=dist;
        return c;
    }
    int robotSim(vector<int>& commands, vector<vector<int>>& obstacles) {
        pair<int,int>origin;
        origin.first=0;
        origin.second=0;
        string axis = "y";
        for(int i=0;i<commands.size();i++)
        {
            if(commands[i]==-1||commands[i]==-2)
            {
                axis=getAxis(axis,commands[i]);
            }
            else
            {
                pair<int,int> c=update(origin,dist,axis);
                if(!checkObstacle(obstacles,c.first,c.second))
                {
                    origin.first=c.first;
                    origin.second=c.second;
                }
                else
                {
                   continue;
                }
            }
        }
        return ((origin.first)*(origin.first))+((origin.second)*(origin.second));

    }
};