package org.example;

import java.util.HashMap;

public class Main {
    public static void main(String[] args) {
        Player ishwar = new Player("Ishwar", Character.X);
        Player priya = new Player("Priya", Character.O);
        HashMap<Character, Player> players = new HashMap<>();
        players.put(Character.X, ishwar);
        players.put(Character.O, priya);
        Grid grid = new Grid(3);
        grid.setCells();
        GridManager gridManager = new GridManager();
        Game game = new Game(players, grid, gridManager);
        game.play();

    }
}