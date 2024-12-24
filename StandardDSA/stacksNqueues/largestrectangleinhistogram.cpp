vector<int>left=nextSmallestToLeft(heights,n);
            vector<int>right=nextSmallestToRight(heights,n);
            vector<int>width(n);
            vector<int>area(n);
            for(int i=0;i<n;i++)
                width[i]=right[i]-left[i]-1;
            for(int i=0;i<n;i++)
                area[i]=width[i]*heights[i];
            int max_area=*max_element(area.begin(),area.end());