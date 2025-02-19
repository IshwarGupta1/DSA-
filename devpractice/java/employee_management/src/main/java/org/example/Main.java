package org.example;

public class Main {
    public static void main(String[] args) {

        System.out.println("Hello world!");
        Employee manager = new Manager("DP", "Manager", 01);
        Employee developer = new Developer("C#", "developer", 02);
        manager.work();
        developer.work();
    }
}