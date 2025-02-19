package org.example;

public abstract class Employee {
    protected String name;
    protected int empId;

    public Employee(String name, int empId) {
        this.name = name;
        this.empId = empId;
    }

    public abstract void work();
}
