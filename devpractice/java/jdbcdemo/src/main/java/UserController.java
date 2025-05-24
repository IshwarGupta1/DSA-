import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/users")
public class UserController {

    @Autowired
    private JdbcTemplate jdbc;

    @PostMapping
    public String addUser(@RequestBody User user) {
        String sql = "INSERT INTO users (name, email) VALUES (?, ?)";
        jdbc.update(sql, user.getName(), user.getEmail());
        return "User added";
    }

    @GetMapping
    public List<User> getAllUsers() {
        return jdbc.query("SELECT * FROM users", new BeanPropertyRowMapper<>(User.class));
    }

    @PutMapping("/{id}")
    public String updateUser(@PathVariable int id, @RequestBody User user) {
        String sql = "UPDATE users SET name = ?, email = ? WHERE id = ?";
        jdbc.update(sql, user.getName(), user.getEmail(), id);
        return "User updated";
    }

    @DeleteMapping("/{id}")
    public String deleteUser(@PathVariable int id) {
        jdbc.update("DELETE FROM users WHERE id = ?", id);
        return "User deleted";
    }
}
