import java.time.LocalDateTime;

public class Session {
    User user;
    LocalDateTime sessionStartTime;
    boolean isAuthenticated;

    public Session(User user) {
        this.user = user;
        this.sessionStartTime = LocalDateTime.now();
        this.isAuthenticated = false;  // Initially not authenticated
    }

    public void authenticate(String password) {
        if (user.password.equals(password)) {
            isAuthenticated = true;
            System.out.println("Authentication successful.");
        } else {
            throw new RuntimeException("Incorrect password!");
        }
    }

    public boolean isSessionActive() {
        // Optionally, check for session timeout here
        return isAuthenticated; // Simplified for now
    }

    public void endSession() {
        isAuthenticated = false;
        System.out.println("Session ended.");
    }
}