package org.example;

public class Cell {
    Status status = Status.Available;
    Character character = Character.E;
    public Status getStatus() {
        return status;
    }

    public void setStatus(Status status) {
        this.status = status;
    }

    public Character getCharacter() {
        return character;
    }

    public void markCell(Player player)
    {
        this.character = player.getCharacter();
        this.status = Status.Unavailable;
    }
}
