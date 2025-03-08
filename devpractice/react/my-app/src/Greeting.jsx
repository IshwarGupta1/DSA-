function Greeting({name})
{
    const today = new Date().toDateString();
    const time = new Date().toTimeString();
    return<div>
        <h2>Hi! Myself {name}</h2>
        <h2>Day is {today}</h2>
        <h2>Time is {time}</h2>
    </div>

}
export default Greeting;