import java.util.*;

public class ATMMachine {
    Bank bank;
    Map<User, Session> activeSessions;  // Track active sessions

    public ATMMachine(Bank bank) {
        this.bank = bank;
        this.activeSessions = new HashMap<>();
    }

    // Authenticate the user and start the session
    public void authenticate(User user, String pin) {
        if (activeSessions.containsKey(user) && activeSessions.get(user).isSessionActive()) {
            System.out.println("User already authenticated for this session.");
            return;
        }

        Session newSession = new Session(user, this);
        newSession.authenticate(pin);
        activeSessions.put(user, newSession);
    }

    // Check if the user is authenticated before performing an operation
    public boolean isAuthenticated(User user) {
        Session session = activeSessions.get(user);
        return session != null && session.isSessionActive();
    }

    public void withdrawMoney(User user, double amount, String pin) {
        if (!isAuthenticated(user)) {
            throw new RuntimeException("Please authenticate first!");
        }

        bank.withdrawMoney(user, this, amount);
    }

    public void depositMoney(User user, double amount, String pin) {
        if (!isAuthenticated(user)) {
            throw new RuntimeException("Please authenticate first!");
        }

        bank.depositMoney(user, this, amount);
    }

    public void transferMoney(User user, User toUser, double amount, String pin) {
        if (!isAuthenticated(user)) {
            throw new RuntimeException("Please authenticate first!");
        }

        bank.transferMoney(user, this, toUser, amount);
    }

    public void balanceEnquiry(User user, String pin) {
        if (!isAuthenticated(user)) {
            throw new RuntimeException("Please authenticate first!");
        }

        bank.balanceInquiry(user, this);
    }

    public void endSession(User user) {
        Session session = activeSessions.get(user);
        if (session != null) {
            session.endSession();
            activeSessions.remove(user);
        }
    }
}
