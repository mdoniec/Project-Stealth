﻿#pragma strict
var moveAcc = 120;
var maxSpeed = 80;
var JumpForce =250;


var runForce = 0;
var looper=0;
var cycle = 20;
function Start () {

}

function Update () {

Screen.lockCursor = true;

Screen.lockCursor = false;

Screen.showCursor = false;


//rigidbody.AddForce(Vector3.right * moveSpeed);
//move forward


if ((Input.GetAxis ("Vertical")!=0 || Input.GetAxis ("Horizontal")!=0) && looper>=cycle){
rigidbody.AddForce(Vector3(0,rigidbody.velocity.magnitude*runForce,0));
looper=0;
}



// MOVEMENT
if (rigidbody.velocity.magnitude*100<maxSpeed){
looper=looper+1;
if (Input.GetAxis ("Vertical")>0){
rigidbody.AddForce(Vector3(transform.forward.x * moveAcc,0,transform.forward.z * moveAcc));
//for (var child : Transform in transform) {
//if (child.rigidbody) {
//child.rigidbody.AddForce(Vector3(child.transform.forward.x * moveAcc,0,child.transform.forward.z * moveAcc));
//}

//}
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
if (Mathf.Abs(rigidbody.velocity.y)<0.1){

if (Input.GetKey("space"))   {
rigidbody.AddForce(transform.up*JumpForce);
}

}

}