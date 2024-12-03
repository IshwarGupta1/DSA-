package org.example;

import java.util.ArrayList;
import java.util.HashMap;

public class GridManager implements GridManagerInterface{

    @Override
    public boolean CheckGrid(Grid grid) {
        int n = grid.getBoardSize();
        for(int i = 0; i<n ; i++)
        {
            for(int j=0;j<n;j++)
            {
                if(grid.cells.get(i).get(j).getStatus() == Status.Available)
                    return false;
            }
        }
        return true;
    }

    @Override
    public Player Winner(Grid grid, HashMap<Character, Player> players) {
        int i=0,j=0;
        int n = grid.getBoardSize();
        ArrayList<Character> list = new ArrayList<>();
        while(i<n && j<n)
        {
            if(grid.cells.get(i).get(j).character!=Character.E)
            {
                list.add(grid.cells.get(i).get(j).character);
            }
            i++;
            j++;
        }
        if(areAllElementsSame(list))
        {
            return players.get(list.get(0));
        }
        list.clear();
        i=0;
        j=n-1;
        while(i<n&&j>=0)
        {
            if(grid.cells.get(i).get(j).character!=Character.E) {
                list.add(grid.cells.get(i).get(j).character);
            }
            i++;
            j--;

        }
        if(areAllElementsSame(list))
        {
            return players.get(list.get(0));
        }

        i=0;
        j=0;
        for(i = 0 ;i < n; i++)
        {
            list.clear();
            for(j = 0;j < n; j++)
            {
                if(grid.cells.get(i).get(j).character!=Character.E) {
                    list.add(grid.cells.get(i).get(j).character);
                }
            }
            if(areAllElementsSame(list))
            {
                return players.get(list.get(0));
            }
        }
        for(i = 0 ;i < n; i++)
        {
            list.clear();
            for(j = 0;j < n; j++)
            {
                if(grid.cells.get(i).get(j).character!=Character.E) {
                    list.add(grid.cells.get(j).get(i).character);
                }
            }
            if(areAllElementsSame(list))
            {
                return players.get(list.get(0));
            }
        }
        return null;
    }

    private boolean areAllElementsSame(ArrayList<Character> list) {
        if (list == null || list.size() <= 1) {
            return false; // Empty list or single element list is trivially "all the same"
        }

        Character firstElement = list.get(0);
        for (Character element : list) {
            if (!element.equals(firstElement)) {
                return false;
            }
        }

        return true;
    }
}
