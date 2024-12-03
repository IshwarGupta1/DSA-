package org.example;

import java.util.HashMap;

public interface GridManagerInterface {
    public boolean CheckGrid(Grid grid);
    public Player Winner(Grid grid, HashMap<Character, Player> players);
}
