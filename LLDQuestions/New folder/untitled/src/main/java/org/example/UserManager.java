package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class UserManager {
    List<User> userList = new ArrayList<>();

    public void createUser(User user)
    {
        userList.add(user);
    }

    public void deleteUser(User user) {
        userList.remove(user);
    }

    public void addUserToGroup(User user, group Group)
    {
        List<group> userGroups = user.getGroupList();
        userGroups.add(Group);
        List<User> groupUsers = Group.getUserList();
        groupUsers.add(user);
    }

    public void removeUserFromGroup(User user, group Group)
    {
        List<group> userGroups = user.getGroupList();
        userGroups.remove(Group);
        List<User> groupUsers = Group.getUserList();
        groupUsers.remove(user);
    }
}
