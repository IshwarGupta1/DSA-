//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        //variables data types simple ones
        int var1 = 3;
        double var2 = 3.4;
        char var3 = 'I';
        float var4 = 3f;
        boolean var5 = false;
        String var6 = "Ishwar";
        System.out.println(var1);
        System.out.println(var2);
        System.out.println(var3);
        System.out.println(var4);
        System.out.println(var5);
        System.out.println(var6);

        //Type casting
        int a = 3;
        byte b = (byte)a;
        float c = 4.5f;
        int d = (int)c;
        System.out.println(b);
        System.out.println(d);

        //Arithmetic operators
        int num1 = 3;
        int num2 = 4;
        System.out.println(num1+num2);
        System.out.println(num1-num2);
        System.out.println(num1*num2);
        System.out.println(num2/num1);
        System.out.println(num1%num2);
        num1++;
        num2--;
        System.out.println(num1);
        System.out.println(num2);

        //relation operators
        int x=1;
        int y=2;
        boolean z = (x+1)>=y;
        System.out.println(z);

        /*
        if,else, if else, if elseif else, ternary, switch and loops are same
         */
        int time = 22;
        if (time < 10) {
            System.out.println("Good morning.");
        } else if (time < 18) {
            System.out.println("Good day.");
        } else {
            System.out.println("Good evening.");
        }

        int day = 4;
        switch (day) {
            case 1:
                System.out.println("Monday");
                break;
            case 2:
                System.out.println("Tuesday");
                break;
            case 3:
                System.out.println("Wednesday");
                break;
            case 4:
                System.out.println("Thursday");
                break;
            case 5:
                System.out.println("Friday");
                break;
            case 6:
                System.out.println("Saturday");
                break;
            case 7:
                System.out.println("Sunday");
                break;
        }

        String result = (time < 18) ? "Good day." : "Good evening.";
        System.out.println(result);

        //classes & objects
        sumnum S = new sumnum();
        S.sum(7,8);
        S.sum(1,2,3);

        //arrays
        int[] myNum = {10, 20, 30, 40};
        System.out.println(myNum[0]);
        System.out.println(myNum.length);
        int[][] myNumbers = { {1, 2, 3, 4}, {5, 6, 7} };
        System.out.println(myNumbers[1][2]);

        //strings
        String greeting = "Hello";
        String txt = "Please locate where 'locate' occurs!";
        System.out.println("The length of the txt string is: " + txt.length());
        System.out.println(txt.toUpperCase());   // Outputs "HELLO WORLD"
        System.out.println(txt.toLowerCase());   // Outputs "hello world"
        System.out.println(txt.indexOf("locate"));
        String firstName = "John";
        String lastName = "Doe";
        System.out.println(firstName + " " + lastName);
        String x1 = "10";
        int y1 = 20;
        String z1 = x1 + y1;



        System.out.println("== Upcasting ==");
        Vehicle v = new Car(); // Upcasting
        v.startEngine();
        // v.playMusic(); // Not allowed in upcast reference

        System.out.println("\n== Downcasting ==");
        if (v instanceof Car) {
            Car c1 = (Car) v; // Downcasting
            c1 .playMusic();   // Now allowed
        }

        System.out.println("\n== Invalid Downcasting ==");
        Vehicle vehicle = new Vehicle();
        if (vehicle instanceof Car) {
            Car car = (Car) vehicle; // Unsafe: won't run
            car.playMusic();
        } else {
            System.out.println("Cannot downcast: vehicle is not a Car");
        }

        System.out.println("\n== Wrapper Class Example ==");
        double price = 99.99;

        // Boxing
        Double boxedPrice = Double.valueOf(price);

        // Unboxing
        double rawPrice = boxedPrice.doubleValue();

        // Auto-boxing and auto-unboxing
        Double discount = 10.5; // auto-boxing
        double finalPrice = boxedPrice - discount; // auto-unboxing

        System.out.println("Boxed Price: " + boxedPrice);
        System.out.println("Raw Price: " + rawPrice);
        System.out.println("Final Price after Discount: " + finalPrice);
    }
}