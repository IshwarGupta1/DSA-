package org.example;

import java.util.Set;

public class Student {
    String studentId;
    String name;
    int age;
    Set<Course> courses;
    public Student(String studentId, String name, int age, Set<Course> courses) {
        this.studentId = studentId;
        this.name = name;
        this.age = age;
        this.courses = courses;
    }
}
