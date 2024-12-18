// See https://aka.ms/new-console-template for more information
using Events_Delegates;

var sub = new Subscriber();
var pub = new Publisher();
pub.OnNotify += sub.Triggered;
pub.AlertMessage("Hi Triggered");
