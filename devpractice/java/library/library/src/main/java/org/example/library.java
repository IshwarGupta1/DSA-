package org.example;

import java.util.HashMap;

class Library {
    private HashMap<Integer, String> books = new HashMap<>();

    public void addBook(int id, String name) {
        books.put(id, name);
    }

    public void removeBook(int id) {
        books.remove(id);
    }

    public void findBook(int id) {
        if (books.containsKey(id)) {
            System.out.println("Book Found: " + books.get(id));
        } else {
            System.out.println("Book Not Found");
        }
    }
}