package org.example;

import java.util.*;

public class Grid {
    int boardSize;

    ArrayList<ArrayList<Cell>> cells;

    public Grid(int boardSize) {
        this.boardSize = boardSize;
    }

    public int getBoardSize() {
        return boardSize;
    }

    public void setCells() {
        this.cells  = new ArrayList<>();
        for(int i=0;i<boardSize;i++) {
            {
                ArrayList<Cell> cellList = new ArrayList<>();
                for(int j=0;j<boardSize;j++)
                {
                    cellList.add(new Cell());
                }
                this.cells.add(cellList);
            }
        }
    }
}
