package org.example;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.*;

public class ExpenseManager {
    List<User> userList = new ArrayList<>();
    List<group> groupList = new ArrayList<>();

    public void listExpensesofUser(User user) {
       for(int i=0;i<groupList.size();i++)
       {
           if(groupList.get(i).getUserList().contains(user))
           {
               System.out.print(user.getUserName() + " owes ");
               String groupName = groupList.get(i).groupName;
               var expenseList = user.getExpenseList();
               for(Map.Entry<Expense, HashMap<User, Double>> expenseHashMapEntry:expenseList.entrySet())
               {
                   Expense expense = expenseHashMapEntry.getKey();
                   HashMap<User,Double> mpp = expenseHashMapEntry.getValue();
                   for(Map.Entry<User,Double> expenseEntry:mpp.entrySet())
                   {
                       System.out.println(expenseEntry.getKey().userName +" "+ expenseEntry.getValue());
                   }
               }
               System.out.println(" from the group "+groupName);
           }
       }
    }

    public void listExpensesofGroup(group Group) {
        for(int i=0;i<groupList.size();i++)
        {
            if(groupList.get(i).getGroupName().equals(Group.groupName))
            {
                System.out.println(Group.groupName + " list of expenses are");
                HashMap<User, HashMap<User, Expense>> expenseList = groupList.get(i).expenseList;
                for(Map.Entry<User, HashMap<User, Expense>> expense:expenseList.entrySet())
                {
                    User receiver = expense.getKey();
                    System.out.print(receiver.getUserName()+" owes from");
                    HashMap<User,Expense> owers = expense.getValue();
                    for(Map.Entry<User,Expense> ower:owers.entrySet())
                    {
                        User ow=ower.getKey();
                        System.out.print(ow.getUserName()+" ");
                        System.out.println(ower.getValue().amount);
                    }
                }
            }
        }
    }
    public void addExpenseByUser(User user, group group, Expense expense, Split splitType, Map<User, Double> customValues) {
        // Check if the user is part of the group
        if (!group.getUserList().contains(user)) {
            System.out.println(user.getUserName() + " is not part of the group " + group.getGroupName());
            return;
        }

        // Create a map to track how much each user owes
        HashMap<User, Double> userShares = new HashMap<>();

        switch (splitType) {
            case Equal:
                equalSplit(group, expense, userShares);
                break;

            case Percentage:
                percentageSplit(group, expense, userShares, customValues);
                break;

            case Custome:
                customSplit(group, expense, userShares, customValues);
                break;
        }

        // Add the expense to the group's expense list and update the user's expense list
        group.getExpenseList().(expense);

        // Update each user's expense list with their share of the expense
        for (Map.Entry<User, Double> entry : userShares.entrySet()) {
            User debtor = entry.getKey();
            double amountOwed = entry.getValue();

            // Create an Expense object to track the amount owed
            Expense debtExpense = new Expense(expense.getExpenseName(), amountOwed, expense.getGroupId(), splitType);

            // Add this expense to the debtor's list of expenses with the payer
            if (!group.getExpenseList().containsKey(user)) {
                group.getExpenseList().put(user, new HashMap<>());
            }
            group.getExpenseList().get(user).put(debtor, debtExpense); // user owes debtor

            // Also, add this expense to the debtor's expense list (reverse perspective)
            if (!group.getExpenseList().containsKey(debtor)) {
                group.getExpenseList().put(debtor, new HashMap<>());
            }
            group.getExpenseList().get(debtor).put(user, debtExpense); // debtor owes user
        }
    }

    // Equal split logic
    private void equalSplit(group group, Expense expense, HashMap<User, Double> userShares) {
        double equalShare = expense.getAmount() / group.getUserList().size();
        for (User groupUser : group.getUserList()) {
            userShares.put(groupUser, equalShare);
        }
    }

    // Percentage split logic - takes custom percentage values for each user
    private void percentageSplit(group group, Expense expense, HashMap<User, Double> userShares, Map<User, Double> customValues) {
        double totalPercentage = 0;
        for (User groupUser : group.getUserList()) {
            if (customValues.containsKey(groupUser)) {
                double percentage = customValues.get(groupUser);
                totalPercentage += percentage;
                userShares.put(groupUser, expense.getAmount() * (percentage / 100));
            } else {
                System.out.println("Percentage value for user " + groupUser.getUserName() + " not provided!");
            }
        }
        if (totalPercentage != 100) {
            System.out.println("Total percentage must be 100%. Please adjust the percentages.");
        }
    }

    // Custom split logic - takes custom amounts for each user
    private void customSplit(group group, Expense expense, HashMap<User, Double> userShares, Map<User, Double> customValues) {
        for (User groupUser : group.getUserList()) {
            if (customValues.containsKey(groupUser)) {
                double customAmount = customValues.get(groupUser);
                userShares.put(groupUser, customAmount);
            } else {
                System.out.println("Custom amount for user " + groupUser.getUserName() + " not provided!");
            }
        }
    }

}
