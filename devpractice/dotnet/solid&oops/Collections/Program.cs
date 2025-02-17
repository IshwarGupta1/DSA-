// See https://aka.ms/new-console-template for more information
using Collections;

Console.WriteLine("Hello, World!");
var lib = new Library();
var b1 = new Book("I1", "A1", "T1", "G1");
var b2 = new Book("I2", "A2", "T2", "G2");
var b3 = new Book("I3", "A3", "T3", "G3");
var b4 = new Book("I4", "A4", "T4", "G4");
lib.addBook(b1);
lib.addBook(b2);
lib.addBook(b3);
lib.addBook(b4);
lib.DisplayGenres();
lib.searchByISBN("I4");
lib.removeBook();