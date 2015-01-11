using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public int vanish=120;
	public Transform target;
	public AudioClip scream;
	public GameObject piano;
	public GameObject player;
	public GameObject body;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform oldrot;


	public NavMeshAgent agent;
	public float incomingsound;

	public int counter=0;

	public int randomspawn=1;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		oldrot = transform;
		vanish=600;
		randomspawn=0;

	}
	

	void Update () {

	}

	void FixedUpdate () {


		counter++;


		if (counter > 8) {
						if (incomingsound < 0.7) {
								incomingsound = 0.7f;
						}
			if (incomingsound > 9) {
				incomingsound = 9f;
			}
			incomingsound = incomingsound - 0.1f;
						counter = 0;
				}
	
			if (piano.audio.isPlaying) {


		
				if (!body.renderer.isVisible) {vanish++; }

			if (vanish>700 && incomingsound<2) {

					
				incomingsound=0.7f;



				if (!audio.isPlaying) audio.PlayOneShot(scream, 1);
				if (randomspawn==0) {transform.position=spawn1.position; target=piano.transform; agent.enabled = true; agent.ResetPath();}
				if (randomspawn==1) {transform.position=spawn1.position; target=spawn3; agent.enabled = true; agent.ResetPath();}
				if (randomspawn==2) {transform.position=spawn2.position; target=spawn3; agent.enabled = true; agent.ResetPath();}
				if (randomspawn==3) {transform.position=spawn3.position; target=spawn1; agent.enabled = true; agent.ResetPath();}

				randomspawn = (int)Random.Range(1f, 4F);
				transform.rotation=oldrot.rotation;
				//agent.ResetPath();
					vanish=0;



			
				}
			if ((agent.destination-target.position).magnitude>0.6) if (!audio.isPlaying) audio.PlayOneShot(scream, 1);

			agent.SetDestination (target.position);
			}

		
//	
	}
}
