#pragma strict
var moveAcc = 160;
var maxSpeed = 80;
var runSpeed = 160;
var JumpForce =5000;
var JumpInterval = 200;
function Start () {
Screen.showCursor = false;
}

function FixedUpdate () {
Screen.lockCursor = false;
Screen.lockCursor = true;


// RUNNING
if (rigidbody.velocity.magnitude*100<runSpeed && Input.GetKey(KeyCode.LeftShift)){
if (Input.GetAxis ("Vertical")>0){
rigidbody.AddForce(Vector3(transform.forward.x * moveAcc,0,transform.forward.z * moveAcc));
}}

// MOVEMENT
if (rigidbody.velocity.magnitude*100<maxSpeed){
if (Input.GetAxis ("Vertical")>0){
rigidbody.AddForce(Vector3(transform.forward.x * moveAcc,0,transform.forward.z * moveAcc));

}



//move "backward"
if (Input.GetAxis("Vertical")<0){
rigidbody.AddForce(Vector3(-transform.forward.x * moveAcc,0,-transform.forward.z * moveAcc));
}

// move left
if (Input.GetAxis ("Horizontal")<0){
rigidbody.AddForce(Vector3(-transform.right.x * moveAcc,0,-transform.right.z * moveAcc));
}


//move right
if (Input.GetAxis ("Horizontal")>0){
rigidbody.AddForce(Vector3(transform.right.x * moveAcc,0,transform.right.z * moveAcc));
}
}

//JUMPING
if (Mathf.Abs(rigidbody.velocity.y)<0.001){

if (Input.GetKey("space"))   {
rigidbody.AddForce(transform.up*JumpForce);
JumpInterval=0;
}
}


}