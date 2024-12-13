package org.example;

import java.util.*;
import java.util.stream.*;

public class GroupManager {
    List<User> userList = new ArrayList<>();
    List<group> groupList = new ArrayList<>();

    public void createGroup(User user, group Group)
    {
        groupList.add(Group);
        userList.add(user);
        List<User> groupUsers = Group.getUserList();
        groupUsers.add(user);
        List<group> userGroups = user.getGroupList();
        userGroups.add(Group);
    }

    public void deleteGroup(group Group) {
        userList = userList.stream()
                .filter(user -> user.getGroupList().stream()
                        .anyMatch(group -> group.getGroupName() != Group.getGroupName())) // Replace Group.groupName with the actual value
                .collect(Collectors.toList());
        groupList = groupList.stream().filter(g -> g.getGroupName() != Group.getGroupName()).collect(Collectors.toList());
    }
}
