package org.example;

import java.util.*;

public class group {
    String groupName;
    List<User> userList;
    HashMap<User, HashMap<User, Expense>> expenseList;

    public String getGroupName() {
        return groupName;
    }

    public void setGroupName(String groupName) {
        this.groupName = groupName;
    }

    public List<User> getUserList() {
        return userList;
    }

    public void setUserList(List<User> userList) {
        this.userList = userList;
    }

    public HashMap<User, HashMap<User, Expense>> getExpenseList() {
        return expenseList;
    }

    public void setExpenseList(HashMap<User, HashMap<User, Expense>> expenseList) {
        this.expenseList = expenseList;
    }

    public group(String groupName) {
        this.groupName = groupName;
    }
}
