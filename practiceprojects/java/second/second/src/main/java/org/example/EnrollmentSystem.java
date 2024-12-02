package org.example;

import java.util.*;

public class EnrollmentSystem {
    Map<String, Student> studentList;
    Map<String, Course> courses;

    public EnrollmentSystem() {
        this.studentList = new HashMap<>();
        this.courses = new HashMap<>();
    }

    // Add student to the system
    public void addStudent(Student student) {
        if (studentList.containsKey(student.studentId)) {
            System.out.println("Student already exists.");
        } else {
            studentList.put(student.studentId, student);
            System.out.println("Student added: " + student.name);
        }
    }

    // Add course to the system
    public void addCourse(Course course) {
        if (courses.containsKey(course.courseId)) {
            System.out.println("Course already exists.");
        } else {
            courses.put(course.courseId, course);
            System.out.println("Course added: " + course.courseName);
        }
    }

    // Enroll a student in a course
    public void enrollStudent(String studentId, String courseId) {
        Student student = studentList.get(studentId);
        Course course = courses.get(courseId);

        if (student == null) {
            System.out.println("Student not found.");
            return;
        }
        if (course == null) {
            System.out.println("Course not found.");
            return;
        }

        if (student.courses.contains(course)) {
            System.out.println("Student already enrolled in the course.");
        } else {
            student.courses.add(course);
            course.students.add(student);
            System.out.println("Student " + student.name + " enrolled in " + course.courseName);
        }
    }

    // Display all courses a student is enrolled in
    public void displayStudentCourses(String studentId) {
        Student student = studentList.get(studentId);
        if (student == null) {
            System.out.println("Student not found.");
            return;
        }

        System.out.println(student.name + " is enrolled in:");
        for (Course course : student.courses) {
            System.out.println("- " + course.courseName);
        }
    }

    // Display all students enrolled in a course
    public void displayCourseStudents(String courseId) {
        Course course = courses.get(courseId);
        if (course == null) {
            System.out.println("Course not found.");
            return;
        }

        System.out.println("Students enrolled in " + course.courseName + ":");
        for (Student student : course.students) {
            System.out.println("- " + student.name);
        }
    }
}
