using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {

	public AudioClip impact ;
	public GameObject enemy;
	public EnemyAI enemyscript;
	public float distance;

		void Start () {
}
		
void OnCollisionEnter(Collision collision) 
		{
		// On collision
		// Calculate distance from the enemy
distance = (transform.position - enemy.transform.position).magnitude;
		// Play impact sound with volume proportional to impact velocity
audio.PlayOneShot(impact, collision.relativeVelocity.magnitude/2);

		// If incoming sound is louder than the one currently stored and is far enough -> change enemy's target to new sound source
		if ((enemyscript.incomingsound < collision.relativeVelocity.magnitude * 2 * rigidbody.mass / (transform.position - enemy.transform.position).magnitude) 
		    && ((transform.position - enemy.transform.position).magnitude > 1.4)) {
			enemyscript.target = transform;
			// Set new threat level (incomingsound) at level of the signal currently attracting the enemy
			enemyscript.incomingsound = (collision.relativeVelocity.magnitude * 2 * rigidbody.mass/ (transform.position - enemy.transform.position).magnitude);
		}

		}
	
	// Update is called once per frame
	void Update () {	
	}
}
