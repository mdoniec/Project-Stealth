

#pragma strict
var objectPos : Vector3;

var strength : int = 300;

var objectRot : Quaternion;

var pickObj : GameObject;

var canpick = true;

var timer = 200;

var picking = false;

var guipick = false;

var pickref : GameObject;

var currentdistance : float ;

var pickdistance : float ;

var emptyj : GameObject;

var hand :Texture2D;

var fist :Texture2D;

var parentjoint : ConfigurableJoint;

var hitcheck: RaycastHit;

function Start () {

pickref = GameObject.FindWithTag ("pickupref");
emptyj = GameObject.FindWithTag ("emptyjoint");
pickObj = pickref;
hand = Resources.LoadAssetAtPath("Assets/icons/hand.png",typeof(Texture2D)) as Texture2D; ;
fist = Resources.LoadAssetAtPath("Assets/icons/fist.png",typeof(Texture2D)) as Texture2D; ;
}
function Update () {
var raycheck: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);



if (Physics.Raycast(raycheck, hitcheck,1) && hitcheck.collider.gameObject.tag == "pickup"){ guipick = true;

} 

if (Physics.Raycast(raycheck, hitcheck) && hitcheck.collider.gameObject.tag != "pickup"){ guipick = false;

}

objectPos = transform.position;

objectRot = transform.rotation;

canpick = true; 

//THROW

if(Input.GetMouseButtonDown(0) && picking)
{
timer = 100;
picking = false;
canpick = false; 
pickObj.rigidbody.constraints = RigidbodyConstraints.None;
pickObj.rigidbody.useGravity=true;
pickObj.rigidbody.isKinematic = false;
pickObj.transform.parent = null;
pickObj.collider.isTrigger = false;
pickObj.rigidbody.AddForce (transform.right * strength);
 pickObj = pickref;
 emptyj.transform.position = transform.position;
 parentjoint.connectedBody = emptyj.rigidbody;



}



// RELEASE
if(Input.GetMouseButtonDown(1) && picking   ) 


{ 
timer = 200;
picking = false;
canpick = false; 
pickObj.rigidbody.useGravity=true;
pickObj.rigidbody.isKinematic = false;
pickObj.rigidbody.constraints = RigidbodyConstraints.None ;
pickObj.transform.parent = null;

pickObj.collider.isTrigger = false; pickObj = pickref;
emptyj.transform.position = transform.position;
 parentjoint.connectedBody = emptyj.rigidbody;
 
}



if(Input.GetMouseButtonDown(0) && canpick && guipick){
picking = true;
var ray:Ray=Camera.main.ScreenPointToRay(Input.mousePosition);
var hit: RaycastHit;






//PICKUP
if (Physics.Raycast(ray, hit, 1) && hit.collider.gameObject.tag == "pickup")
{ pickObj = hit.collider.gameObject;
 hit.rigidbody.useGravity = false;
 
 
//pickObj.rigidbody.AddForce (transform.forward * 300);
// hit.rigidbody.isKinematic = true;  

//angle = Vector3.Angle(gameObject.transform.position,pickObj.transform.position) ;
//hit.transform.position= gameObject.transform.position;

 parentjoint = transform.parent.GetComponent(ConfigurableJoint);
 parentjoint.connectedBody= hit.rigidbody;
 
 //hit.transform.parent = gameObject.transform.parent.transform.parent.transform; 
 
 //hit.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ ;
 //hit.rigidbody.constraints = RigidbodyConstraints.FreezePosition ;
pickdistance = Vector3.Magnitude(gameObject.transform.position-pickObj.transform.position);
 // hit.rigidbody.constraints = RigidbodyConstraints.FreezeRotation ;

 //hit.transform.rotation = objectRot;

}

} 
}


 
function OnGUI () {

timer=timer-1;

if (guipick && canpick && !picking && timer<0){

GUI.Label (Rect (Screen.width/2-hand.width/2,Screen.height/2-hand.height/2, hand.width, hand.height),hand);
//GUI.Label (Rect (Screen.width/2-40,Screen.height/2,Screen.width/2,Screen.height/2), hitcheck.collider.gameObject.name);
}

if (picking){ 
GUI.Label (Rect (Screen.width/2-fist.width/2,Screen.height/2-fist.height/2, fist.width, fist.height),fist);
}


}