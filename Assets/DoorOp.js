private var isTriggered = false;

function OnTriggerEnter(other : collider)
{
if(other.gameObject.tag == "player"){
isTriggered =true;
}
}

function OnTriggerExit(collider : collider)
{
isTriggered = false;
}