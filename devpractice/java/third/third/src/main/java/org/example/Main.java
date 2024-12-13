package org.example;
import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        var list = new ArrayList<Integer>(4);
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        var liststream = list.stream();
        liststream.forEach(System.out::println);
        var list1 = list.stream().filter(x -> x % 2 == 0).map(x-> x*x).sorted(Comparator.reverseOrder()).collect(Collectors.toList());
        list1.forEach(System.out::println);
    }
}