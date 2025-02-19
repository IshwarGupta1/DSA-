package org.example;

public class Developer extends Employee{
    private String lang;
    public Developer(String lang, String name, int empId){
        super(name, empId);
        this.lang = lang;
    }

    @Override
    public void work() {
        System.out.println(this.name + " develops using language "+ this.lang);
    }
}
