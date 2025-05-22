import java.util.*;

public class Collections {

    // 1. Arrays
    public void workWithArray() {
        String[] array = {"Java", "Python", "C++"};
        System.out.println("Array: " + Arrays.toString(array));
    }

    // 2. List
    public void workWithList() {
        List<String> list = new ArrayList<>();
        list.add("Apple");
        list.add("Banana");
        list.add("Mango");
        System.out.println("List: " + list);
    }

    // 3. Dictionary (Legacy)
    public void workWithDictionary() {
        Dictionary<Integer, String> dict = new Hashtable<>();
        dict.put(1, "One");
        dict.put(2, "Two");
        System.out.println("Dictionary: " + dict);
        System.out.println("Value for key 1: " + dict.get(1));
    }

    // 4. Map
    public void workWithMap() {
        Map<String, Integer> map = new HashMap<>();
        map.put("Alice", 25);
        map.put("Bob", 30);
        System.out.println("Map: " + map);
        System.out.println("Age of Bob: " + map.get("Bob"));
    }

    // 5. Set
    public void workWithSet() {
        Set<String> set = new HashSet<>();
        set.add("Red");
        set.add("Blue");
        set.add("Green");
        set.add("Red"); // Duplicate, ignored
        System.out.println("Set: " + set);
    }
}
