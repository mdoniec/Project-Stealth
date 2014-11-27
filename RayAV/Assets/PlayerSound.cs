using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour {

	string super ;
	int maxSpeed = 80;


	// Use this for initialization
	void Start () {
		GameObject map;
	map = GameObject.Find ("Map");
	}

	void OnCollisionStay(Collision collisionInfo) 
	{
				
		super = collisionInfo.gameObject.name;


		}

	// Update is called once per frame
	void Update () {

		if (super == "Map" && !audio.isPlaying) {
			if (rigidbody.velocity.magnitude*100>maxSpeed/5) audio.Play ();
				} else 
			if (rigidbody.velocity.magnitude*100<maxSpeed/5 || super != "Map")audio.Pause ();
				

	
	
	
	}




		void OnGUI() {
			GUI.Label(new Rect(10, 10, 100, 20), rigidbody.velocity.magnitude.ToString());
		}

}
