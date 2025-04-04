//traditional functions
function calculatePrice(sqMetres)
{
    const price = 100.25;
    console.log(price*sqMetres);
    return price * sqMetres
}
const res = calculatePrice(250);
console.log(res);
var area = function(length, breadth){
    return length * breadth;
}
console.log(area(10,20));

//modern arrow functions
const perim = (length,breadth) => {
    return 2*(length+breadth);
}
console.log(perim(5,15));

const radius = diam => diam/2;
console.log(radius(6));