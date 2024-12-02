package com.example.helloWorld.Rest.Controller;

import org.springframework.web.bind.annotation.*;

@RestController
public class MyRestController {

    @GetMapping("/hello")
    public String sayHello() {
        return "Hello, World!";
    }

    @PostMapping("/greet")
    public String greet(@RequestBody String name) {
        return "Hello, " + name + "!";
    }

    @PutMapping("/update")
    public String update(@RequestBody String data) {
        return "Updated: " + data;
    }

    @DeleteMapping("/delete")
    public String delete(@RequestParam String id) {
        return "Deleted ID: " + id;
    }
}
