const posts = [
    {title : "Post 1", body : "Post body 1"},
    {title : "Post 2", body : "Post body 2"},
    {title : "Post 3", body : "Post body 3"},
];

function getPosts()
{
    setTimeout(()=>{
        let output = '';
        posts.forEach((post)=>
        { 
            output+=`<li>${post.title}</li>`;
        });
        document.body.innerHTML = output;
    }, 1000);
}
getPosts();

//without promise
// function createPost(post)
// {
//     setTimeout(()=>{
//         posts.push(post);
//     },2000);
// }

//with promise
function createPost(post)
{
    return new Promise((resolve, reject) =>{
        setTimeout(()=>{
            posts.push(post);
            const error = false;
            if(!error)
                resolve();
            else
                reject("Error thrown");
        }, 1000)
    });
}
createPost({title : "Post 4", body : "Post body 4"})
.then(getPosts())
.catch(err => console.log(err));// with 1000 in getPosts post4 is not called in browser because createPost takes 2 seconds to add abut getPosts is called and 1 second has passed, so we need to increase time in getPosts or decrease in createPost44


//promise all
var p1 = new Promise('Hello World');
var p2 = new Promise(10);
var p3 = new Promise((resolve, reject) => {
    setTimeout(resolve, 2000, 'GoodBye')
});
var p4 = fetch('google.com');
Promise.all([p1,p2,p3]).then(values => console.log(values));



//async await
async function init()
{
    await getPosts();
    await createPost({title : "Post 5", body : "Post body 5"});
}
init();