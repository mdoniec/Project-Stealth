using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {
	
		
	public float lolo ;
	public AudioClip impact ;

	//AudioSource sound1;
		//float forsik;
		
		//AudioSource carpetsteps;
		
		// Use this for initialization
		void Start () {
			//// AUDIO SOURCES
			
			
			
			//AudioSource[] audios = GetComponents<AudioSource>();
			//sound1 = audios[1];
			//carpetsteps= audios[1];
			
		}
		
		void OnCollisionEnter(Collision collision) 
		{
		lolo = rigidbody.velocity.magnitude;
		//colidedsurface = collisionInfo.gameObject.name;
		audio.PlayOneShot(impact, collision.relativeVelocity.magnitude/2);
			
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
