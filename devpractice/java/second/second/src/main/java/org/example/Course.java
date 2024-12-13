package org.example;

import java.util.Set;

public class Course {
    String courseId;
    String courseName;
    Set<Student> students;

    public Course(String courseId, String courseName, Set<Student> students) {
        this.courseId = courseId;
        this.courseName = courseName;
        this.students = students;
    }
}
