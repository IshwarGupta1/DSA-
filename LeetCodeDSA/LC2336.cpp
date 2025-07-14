class SmallestInfiniteSet {
public:
    set<int>s;
    SmallestInfiniteSet() {
        for(int i=1;i<=1000;i++)
            s.insert(i);
    }
    
    int popSmallest() {
        auto res = s.begin();
        int ans = *res;
        s.erase(*res);
        return ans;
    }
    
    void addBack(int num) {
        if(!s.count(num))
            s.insert(num);
        return;
    }
};

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet* obj = new SmallestInfiniteSet();
 * int param_1 = obj->popSmallest();
 * obj->addBack(num);
 */