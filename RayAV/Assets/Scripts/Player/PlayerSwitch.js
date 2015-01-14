#pragma strict

var door : GameObject ;
	var myname = "ssssssssss";
	var open = 0;
	var guipick = false ;
	var hitcheck: RaycastHit;
var hand :Texture2D;
var timer = 200;



function Start () {

}

function Update () {

var raycheck: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);


if (Physics.Raycast(raycheck, hitcheck,1) && hitcheck.collider.gameObject.tag == "switch"){ 

 Physics.Raycast(raycheck, hitcheck,1) ;
 myname = hitcheck.collider.gameObject.name;
 if (myname.Length>6) { myname = myname.Substring(0, myname.Length - 6); }
 door = GameObject.Find (myname);
 guipick = true;
 } 
if (Physics.Raycast(raycheck, hitcheck) && hitcheck.collider.gameObject.tag != "switch"){ guipick = false;}

if(Input.GetMouseButtonDown(0)  && guipick){
if (!hitcheck.collider.gameObject.audio.isPlaying) {
hitcheck.collider.gameObject.tag="Untagged";
hitcheck.collider.gameObject.audio.Play();
door.rigidbody.constraints=RigidbodyConstraints.None;
door.audio.Play();

}
}

}

function OnGUI () {

timer=timer-1;

if (guipick && timer<0  ){

GUI.Label (Rect (Screen.width/2-hand.width/2,Screen.height/2-hand.height/2, hand.width, hand.height),hand);
//GUI.Label (Rect (Screen.width/2-40,Screen.height/2,Screen.width/2,Screen.height/2), hitcheck.collider.gameObject.name);
}
}