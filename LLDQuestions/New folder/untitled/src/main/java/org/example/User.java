package org.example;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class User {
    String userName;
    String userEmail;
    List<group> groupList = new ArrayList<>();
    HashMap<Expense, HashMap<User, Double>> expenseList = new HashMap<>();

    public User(String userName, String userEmail) {
        this.userName = userName;
        this.userEmail = userEmail;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String userEmail) {
        this.userEmail = userEmail;
    }

    public List<group> getGroupList() {
        return groupList;
    }

    public void setGroupList(List<group> groupList) {
        this.groupList = groupList;
    }

    public HashMap<Expense, HashMap<User, Double>> getExpenseList() {
        return expenseList;
    }

    public void setExpenseList(HashMap<Expense, HashMap<User, Double>> expenseList) {
        this.expenseList = expenseList;
    }
}
