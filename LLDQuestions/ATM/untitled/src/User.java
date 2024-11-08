public class User {
    String userName;
    Account account;
    ATMCard card;

    public User(String userName) {
        this.userName = userName;
    }

    public void withdrawMoney(double amount, ATMMachine atm, String PIN)
    {
        atm.withdrawMoney(this, amount, PIN);
    }

    public void depositMoney(double amount, ATMMachine atm, String PIN)
    {
        atm.depositMoney(this, amount, PIN);
    }

    public void transferMoney(User toUser, double amount, ATMMachine atm, String PIN)
    {
        atm.transferMoney(this, toUser, amount, PIN);
    }

    public void balanceInquiry(ATMMachine atm, String PIN)
    {
        atm.balanceEnquiry(this, PIN);
    }
}
