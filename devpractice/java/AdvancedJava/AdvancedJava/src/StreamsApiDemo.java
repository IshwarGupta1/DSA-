import java.util.*;
import java.util.stream.Collectors;

public class StreamsApiDemo {

    private List<String> names = Arrays.asList("Alice", "Bob", "Charlie", "David", "Daniel", "Amy");

    public void basicStreamOperations() {
        System.out.println("Original List:");
        names.forEach(System.out::println);

        // 1. Filter names starting with 'A'
        List<String> startsWithA = names.stream()
                .filter(name -> name.startsWith("A"))
                .collect(Collectors.toList());
        System.out.println("Names starting with A: " + startsWithA);

        // 2. Convert names to uppercase
        List<String> upperCaseNames = names.stream()
                .map(String::toUpperCase)
                .collect(Collectors.toList());
        System.out.println("Uppercase names: " + upperCaseNames);

        // 3. Sort names
        List<String> sortedNames = names.stream()
                .sorted()
                .collect(Collectors.toList());
        System.out.println("Sorted names: " + sortedNames);

        // 4. Count names with length > 4
        long count = names.stream()
                .filter(name -> name.length() > 4)
                .count();
        System.out.println("Count of names with length > 4: " + count);
    }

    public void sumOfNumbers() {
        List<Integer> numbers = Arrays.asList(1, 2, 3, 4, 5);

        int sum = numbers.stream()
                .reduce(0, Integer::sum);
        System.out.println("Sum of numbers: " + sum);
    }
}
