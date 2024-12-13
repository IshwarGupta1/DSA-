package org.example;

import java.util.HashMap;

public class Expense {
    String expenseName;
    Split splitType;

    public Split getSplitType() {
        return splitType;
    }

    public void setSplitType(Split splitType) {
        this.splitType = splitType;
    }

    public double getAmount() {
        return amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    double amount;

    public String getExpenseName() {
        return expenseName;
    }

    public void setExpenseName(String expenseName) {
        this.expenseName = expenseName;
    }

    public Expense(String expenseName, Split splitType, double amount) {
        this.expenseName = expenseName;
        this.splitType = splitType;
        this.amount = amount;
    }
}
