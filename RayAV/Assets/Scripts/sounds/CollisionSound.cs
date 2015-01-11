using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {

	public AudioClip impact ;
	public GameObject enemy;
	public EnemyAI enemyscript;
	public float distance;
	//AudioSource sound1;
		//float forsik;
		//AudioSource carpetsteps;

		// Use this for initialization
		void Start () {

			
			
			
			//AudioSource[] audios = GetComponents<AudioSource>();
			//sound1 = audios[1];
			//carpetsteps= audios[1];
			
		}
		
		void OnCollisionEnter(Collision collision) 
		{
		distance = (transform.position - enemy.transform.position).magnitude;
		//colidedsurface = collisionInfo.gameObject.name;
		audio.PlayOneShot(impact, collision.relativeVelocity.magnitude/2);

		if ((enemyscript.incomingsound < collision.relativeVelocity.magnitude * 2 * rigidbody.mass / (transform.position - enemy.transform.position).magnitude) && ((transform.position - enemy.transform.position).magnitude > 1.4)) {
			enemyscript.target = transform;
			enemyscript.incomingsound = (collision.relativeVelocity.magnitude * 2 * rigidbody.mass/ (transform.position - enemy.transform.position).magnitude);
		}

		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
