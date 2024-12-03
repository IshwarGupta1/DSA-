package org.example;

public class Player {
    String name;
    Character character;

    public Player(String name, Character character) {
        this.name = name;
        this.character = character;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Character getCharacter() {
        return character;
    }

    public void setCharacter(Cell cell) {
        if(cell.status == Status.Available)
            cell.character = this.character;
    }
}
