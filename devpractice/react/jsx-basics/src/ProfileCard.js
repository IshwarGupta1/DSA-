import React from 'react';
function ProfileCard(props)
{
    return(
        <div>
            <h1>{props.Name}</h1>
            <h2>{props.Age}</h2>
            <h2 style={{color : "green", fontStyle : "italic"}}>{props.Quote}</h2>
        </div>
    )
};
export default ProfileCard;