vector<int> merge(vector<int>&v1, vector<int>&v2)
    {
        int i=0,j=0;
        vector<int>res;
        while(i<v1.size()&&j<v2.size())
        {
            if(v1[i]<v2[j])
            {
                res.push_back(v1[i]);
                i++;
            }
            else
            {
                res.push_back(v2[j]);
                j++;
            }
        }
        while(i<v1.size())
        {
            res.push_back(v1[i]);
            i++;
        }
        while(j<v2.size())
        {
            res.push_back(v2[j]);
            j++;
        }
        return res;
    }
    vector<int> mergeKArrays(vector<vector<int>> arr, int K)
    {
        //code here
        vector<int>res=arr[0];
        for(int i=1;i<arr.size();i++)
        {
            res=merge(res,arr[i]);
        }
        return res;
    }
	
	
	
	#include <iostream>
#include <vector>
#include <queue>
using namespace std;

vector<int> mergeKArrays(vector<vector<int>> &arr, int K) {
    // Min-heap: stores {value, array index, element index within array}
    priority_queue<pair<int, pair<int, int>>, vector<pair<int, pair<int, int>>>, greater<>> minHeap;

    // Insert the first element of each array into the heap
    for (int i = 0; i < K; i++) {
        if (!arr[i].empty()) {
            minHeap.push({arr[i][0], {i, 0}});
        }
    }

    vector<int> result;

    while (!minHeap.empty()) {
        // Extract the smallest element
        auto [val, pos] = minHeap.top();
        minHeap.pop();
        result.push_back(val);

        int arrayIndex = pos.first;
        int elementIndex = pos.second;

        // Push the next element from the same array into the heap
        if (elementIndex + 1 < arr[arrayIndex].size()) {
            minHeap.push({arr[arrayIndex][elementIndex + 1], {arrayIndex, elementIndex + 1}});
        }
    }

    return result;
}
