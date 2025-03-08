import React from 'react';

function UsersList(){
    const users = [
        { id: 1, name: "Alice" },
        { id: 2, name: "Bob" },
        { id: 3, name: "Charlie" }
    ];
    return <ul>
        {users.map((user)=>
        <li key = {user.key}>{user.name}</li>)
        }
    </ul>
}

export default UsersList;