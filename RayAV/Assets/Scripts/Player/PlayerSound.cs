using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour {

	string colidedsurface ;
	int maxSpeed = 80;
	AudioSource mapsteps;
	AudioSource carpetsteps;
	
	// Use this for initialization
	void Start () {
		//// AUDIO SOURCES


	
AudioSource[] audios = GetComponents<AudioSource>();
		mapsteps = audios[0];
		carpetsteps= audios[1];

		}

	void OnCollisionStay(Collision collisionInfo) 
	{
		colidedsurface = collisionInfo.gameObject.name;


		}

	// Update is called once per frame
	void Update () {
		if (colidedsurface == "Map" && !mapsteps.isPlaying) {
			if (rigidbody.velocity.magnitude*100>maxSpeed/5) mapsteps.Play ();
				} else 
			if (rigidbody.velocity.magnitude*100<maxSpeed/5 || colidedsurface != "Map")mapsteps.Pause ();
			

	if (colidedsurface == "Corridor Grey Carpet" && !carpetsteps.isPlaying) {
		if (rigidbody.velocity.magnitude*100>maxSpeed/5) carpetsteps.Play ();
	} else 
			if (rigidbody.velocity.magnitude*100<maxSpeed/5 || colidedsurface != "Corridor Grey Carpet")carpetsteps.Pause ();
}






	void OnGUI() {
			GUI.Label(new Rect(10, 10, 100, 20), rigidbody.velocity.magnitude.ToString());
		}

}
