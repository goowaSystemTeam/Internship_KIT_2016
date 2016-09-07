private var opened : boolean;
private var near : boolean;
private var animator : Animator;
function Start () {
opened = false;
near = false;
animator = transform.parent.GetComponent(Animator);
}
function Update () {
if(Input.GetKeyDown("space") && near) {
Debug.Log("space");
if(!opened) {
animator.SetBool("Open", true);
Open();
Debug.Log("Open");
} else {
animator.SetBool("Open", false);
Open();
Debug.Log("Close");
}
}
}
function OnTriggerEnter(col : Collider) {
if(col.tag == "Player") {
near = true;
}
}
function OnTriggerExit(col : Collider) {
near = false;
}
function Open() {
opened = !opened;
}