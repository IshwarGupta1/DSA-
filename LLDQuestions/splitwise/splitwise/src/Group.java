import java.util.*;
public class Group {
    int groupId;
    String groupName;
    List<User> members;

    public Group(int groupId, String groupName, List<User> members) {
        this.groupId = groupId;
        this.groupName = groupName;
        this.members = members;
    }

    public void addUser(User user) {
        members.add(user);
    }
}
