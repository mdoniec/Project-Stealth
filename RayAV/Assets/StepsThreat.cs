using UnityEngine;
using System.Collections;

public class StepsThreat : MonoBehaviour {
	public GameObject enemy;
	public EnemyAI enemyscript;
	public float distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		distance = (transform.position - enemy.transform.position).magnitude;

		
		if ((enemyscript.incomingsound < rigidbody.velocity.magnitude * 2f / (transform.position - enemy.transform.position).magnitude) && ((transform.position - enemy.transform.position).magnitude > 1.5)) {
			enemyscript.target = transform;
			enemyscript.incomingsound = (rigidbody.velocity.magnitude * 2f / (transform.position - enemy.transform.position).magnitude);
		}
	
	}
}
