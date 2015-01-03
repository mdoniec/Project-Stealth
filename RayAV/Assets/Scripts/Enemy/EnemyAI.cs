using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public int vanish=0;
	public Transform target;
	public AudioClip scream;


	public NavMeshAgent agent;
	public float incomingsound;

	public int counter=0;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();

	}
	

	void Update () {

		if ((agent.destination-target.position).magnitude>0.6) if (!audio.isPlaying) audio.PlayOneShot(scream, 1);
		agent.SetDestination (target.position);
	}

	void FixedUpdate () {
		counter++;
		if (counter > 8) {
			if (incomingsound<0.7) {incomingsound=0.7f;}
			incomingsound=incomingsound-0.1f;
			counter=0;

		}
//	
	}
}
