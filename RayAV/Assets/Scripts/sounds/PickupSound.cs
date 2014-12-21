using UnityEngine;
using System.Collections;

public class PickupSound : MonoBehaviour {
	
	public string colidedsurface ;

	AudioSource sound1;

	public AudioClip impact ;

		void Start () {

		AudioSource[] audios = GetComponents<AudioSource>();
		sound1 = audios[1];
		
	}
	
	void OnCollisionStay(Collision collisionInfo) 
	{
		colidedsurface = collisionInfo.gameObject.name;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		sound1.pitch = (float)(0.0 + rigidbody.velocity.magnitude);




		}
	}
	
	
