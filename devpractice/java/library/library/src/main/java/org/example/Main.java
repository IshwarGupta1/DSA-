package org.example;

public class Main {
    public static void main(String[] args) {
        Library lib = new Library();
        lib.addBook(1, "Effective Java");
        lib.addBook(2, "Java Concurrency in Practice");

        lib.findBook(1); // Should print: Book Found: Effective Java
        lib.removeBook(1);
        lib.findBook(1); // Should print: Book Not Found
    }
}