using System;
using System.Collections.Generic;
using ATM.Models;

namespace ATM
{ 
    public class Atm
    {
        private Dictionary<string, Session> _activeSessions; // Active sessions by sessionId
        private List<Models.User> _users; // Simulating a database of users

        public Atm()
        {
            _activeSessions = new Dictionary<string, Session>();
            _users = new List<Models.User>
    {
        new Models.User("user1", "123456", "0000", new Models.Account("123-456-789", 1000)),
        new Models.User("user2", "654321", "1111", new Models.Account("987-654-321", 500))
    };
        }

        // Start a session for the user
        public Session StartSession(string cardNumber, string pin)
        {
            Models.User user = Authenticate(cardNumber, pin);
            if (user != null)
            {
                Session session = new Session(user);
                _activeSessions.Add(session.SessionId, session);
                return session;
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
                return null;
            }
        }

        // Authenticate the user based on card number and pin
        private Models.User Authenticate(string cardNumber, string pin)
        {
            foreach (var user in _users)
            {
                if (user.CardNumber == cardNumber && user.Pin == pin)
                {
                    return user;
                }
            }
            return null; // Authentication failed
        }

        // Check if the session is valid (not timed out)
        public bool IsSessionValid(Session session)
        {
            if (session == null)
            {
                return false;
            }

            if (session.IsSessionTimedOut())
            {
                EndSession(session.SessionId);  // End session if it's timed out
                return false;
            }

            session.UpdateLastActivity();  // Update last activity time
            return true;
        }

        // End the session
        public void EndSession(string sessionId)
        {
            if (_activeSessions.ContainsKey(sessionId))
            {
                _activeSessions.Remove(sessionId);
                Console.WriteLine("Session ended.");
            }
        }

        // Perform a withdrawal transaction
        public void Withdraw(Session session, double amount)
        {
            if (IsSessionValid(session))
            {
                Models.Account account = session.User.Account;
                if (account.Withdraw(amount))
                {
                    Console.WriteLine($"Withdrawal successful. Remaining balance: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Session has expired.");
            }
        }

        // Perform a deposit transaction
        public void Deposit(Session session, double amount)
        {
            if (IsSessionValid(session))
            {
                session.User.Account.Deposit(amount);
                Console.WriteLine($"Deposit successful. New balance: {session.User.Account.Balance}");
            }
            else
            {
                Console.WriteLine("Session has expired.");
            }
        }
    }
}