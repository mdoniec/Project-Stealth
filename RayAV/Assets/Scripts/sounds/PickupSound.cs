using UnityEngine;
using System.Collections;

public class PickupSound : MonoBehaviour {
	
	string colidedsurface ;
	int maxSpeed = 40;
	AudioSource sound1;
	//AudioSource carpetsteps;
	
	// Use this for initialization
	void Start () {
		//// AUDIO SOURCES
		
		
		
		AudioSource[] audios = GetComponents<AudioSource>();
		sound1 = audios[0];
		//carpetsteps= audios[1];
		
	}
	
	void OnCollisionStay(Collision collisionInfo) 
	{
		colidedsurface = collisionInfo.gameObject.name;
		
		
	}
	
	// Update is called once per frame
	void Update () {


		if (!sound1.isPlaying) {
						sound1.volume = rigidbody.velocity.magnitude / 5;
				}
	if (colidedsurface == "Map" && !sound1.isPlaying) {sound1.Play ();}
		//if(rigidbody.velocity.magnitude<maxSpeed) sound1.Pause ();


		}
	}
	
	
