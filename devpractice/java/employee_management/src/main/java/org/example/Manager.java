package org.example;

public class Manager extends Employee{
    private String team;

    public Manager(String team, String name, int empId) {
        super(name, empId);
        this.team = team;
    }


    @Override
    public void work() {
        System.out.println(this.name + " manages team "+this.team);
    }
}
