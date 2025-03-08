function list(){
    const listUsers = [ "user1", "user2", "user3"];
    const listUser = listUsers.map(user=><ul><li>{user}</li></ul>);
    return(
        <div>
           {listUser}
        </div>
    );
}
export default list;