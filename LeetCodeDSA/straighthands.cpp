class Solution {
public:
    bool isNStraightHand(vector<int>& hand, int groupSize) {
        if(hand.size()%groupSize!=0)
            return false;
        map<int,int>mpp;
        for(int i=0;i<hand.size();i++)
            mpp[hand[i]]++;
        while(!mpp.empty())
        {
            int h=mpp.begin()->first;
            for(int i=0;i<groupSize;i++)
            {
                if(mpp[h+i]==0)
                    return false;
                mpp[h+i]--;
                if(mpp[h+i]==0)
                    mpp.erase(h+i);
            }
        }
        return true;
    }
};