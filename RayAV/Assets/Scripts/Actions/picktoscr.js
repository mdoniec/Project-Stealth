

#pragma strict
var strength : int = 300;
var timer = 200;

var pickObj : GameObject;

var canpick = true;

var picking = false;

var guipick = false;

var pickref : GameObject;

var emptyj : GameObject;

var parentjoint : ConfigurableJoint;

var hitcheck: RaycastHit;

var hand :Texture2D;

var fist :Texture2D;

function Start () {
// set starting values of used objects
pickref = GameObject.FindWithTag ("pickupref");
emptyj = GameObject.FindWithTag ("emptyjoint");
pickObj = pickref;
}

// In every frame
function Update () {

// create raycheck from mouse position and allow picking
var raycheck: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
canpick = true; 

// Is mouse poining "pickup" object?
if (Physics.Raycast(raycheck, hitcheck,1) && hitcheck.collider.gameObject.tag == "pickup") guipick = true;
if (Physics.Raycast(raycheck, hitcheck) && hitcheck.collider.gameObject.tag != "pickup") guipick = false;




// THROWING --------------------------------------------------------------------
if(Input.GetMouseButtonDown(0) && picking)
{

	timer = 200;
	picking = false;
	canpick = false; 
// Set picked object rigidbody variables to release it
	pickObj.rigidbody.useGravity=true;
	pickObj.rigidbody.isKinematic = false;
	pickObj.transform.parent = null;
// Add force to thrown rigidbody and reasign empty joints to the camera
	pickObj.rigidbody.AddForce (transform.right * strength);
	pickObj = pickref;
	emptyj.transform.position = transform.position;
	parentjoint.connectedBody = emptyj.rigidbody;
}

// RELEASE--------------------------------------------------
if(Input.GetMouseButtonDown(1) && picking   ) 
{ 
// Set internal script variables to release picked object
	timer = 200;
	picking = false;
	canpick = false; 
// Set picked object rigidbody variables to release it
	pickObj.rigidbody.useGravity=true;
	pickObj.rigidbody.isKinematic = false;
	pickObj.transform.parent = null;
// Add force to release rigidbody and reasign empty joints to the camera
	pickObj.collider.isTrigger = false;
	pickObj = pickref;
	emptyj.transform.position = transform.position;
	parentjoint.connectedBody = emptyj.rigidbody;
 
}

///PICKING ------------------------------------------------------------------
if(Input.GetMouseButtonDown(0) && canpick && guipick){
picking = true;
var ray:Ray=Camera.main.ScreenPointToRay(Input.mousePosition);
var hit: RaycastHit;

//Check if the object can be picked
if (Physics.Raycast(ray, hit, 1) && hit.collider.gameObject.tag == "pickup")
{ 
// Turn off gravity of the picked object, connect the joint and set the distance
pickObj = hit.collider.gameObject;
hit.rigidbody.useGravity = false;
parentjoint = transform.parent.GetComponent(ConfigurableJoint); 
parentjoint.connectedBody= hit.rigidbody;
}
} 

}


// Display GUI
function OnGUI () {
//decrease timer
timer--;

// Display GUI hand Icons
if (guipick && canpick && !picking && timer<0){
GUI.Label (Rect (Screen.width/2-hand.width/2,Screen.height/2-hand.height/2, hand.width, hand.height),hand);
}
if (picking){ 
GUI.Label (Rect (Screen.width/2-hand.width/2,Screen.height/2-fist.height/2, fist.width, fist.height),fist);
}


}