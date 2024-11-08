import java.time.LocalDateTime;

public class Session {
    User user;
    ATMMachine atm;
    LocalDateTime sessionStartTime;
    boolean isAuthenticated;

    public Session(User user, ATMMachine atm) {
        this.user = user;
        this.atm = atm;
        this.sessionStartTime = LocalDateTime.now();
        this.isAuthenticated = false;  // Initially not authenticated
    }

    public void authenticate(String pin) {
        if (user.card.strip.ATMPin.equals(pin)) {
            isAuthenticated = true;
            System.out.println("Authentication successful.");
        } else {
            throw new RuntimeException("Incorrect PIN!");
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
