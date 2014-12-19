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
		sound1 = audios[1];
		//carpetsteps= audios[1];
		
	}
	
	void OnCollisionStay(Collision collisionInfo) 
	{
		colidedsurface = collisionInfo.gameObject.name;
		
		
	}
	
	// Update is called once per frame
	void Update () {


	
						sound1.volume = rigidbody.velocity.magnitude ;



		}
	}
	
	
