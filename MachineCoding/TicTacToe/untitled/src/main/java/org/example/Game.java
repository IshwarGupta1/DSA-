package org.example;

import java.util.*;

public class Game {
    HashMap<Character, Player> players;
    Grid grid;
    GridManagerInterface gridManager;

    public Game(HashMap<Character, Player> players, Grid grid, GridManagerInterface gridManager) {
        this.players = players;
        this.grid = grid;
        this.gridManager = gridManager;
    }

    public void play()
    {
        int boardSize = grid.getBoardSize();
        while(true)
        {
            for(Player player : players.values())
            {
                if(gridManager.Winner(grid, players) != null)
                {
                    String name = gridManager.Winner(grid, players).name;
                    System.out.println("Player "+ name + " Won!!");
                    return;
                }
                if(gridManager.CheckGrid(grid))
                {
                    if(gridManager.Winner(grid, players)==null)
                    {
                        System.out.println("Game is drawn");
                        return;
                    }
                }
                Random random = new Random();
                int randomX = -1, randomY = -1;
                randomX = random.nextInt(((boardSize - 1) - 0) + 1);
                randomY = random.nextInt(((boardSize - 1) - 0) + 1);
                while(grid.cells.get(randomX).get(randomY).getStatus() != Status.Available)
                {
                    randomX = random.nextInt(((boardSize - 1) - 0) + 1);
                    randomY = random.nextInt(((boardSize - 1) - 0) + 1);
                }
                Cell cell = grid.cells.get(randomX).get(randomY);
                cell.markCell(player);
            }
        }
    }

}
