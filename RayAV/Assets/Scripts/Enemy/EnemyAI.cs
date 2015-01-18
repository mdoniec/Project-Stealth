using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class EnemyAI : MonoBehaviour {

	// Respawn parameters
	public GameObject piano;
	public GameObject player;
	public GameObject body;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform oldrot;

	// AI, movement, sound parameters
	public Transform target;
	public Transform oldtarget;
	public AudioClip scream;
	public NavMeshAgent agent;
	public float incomingsound;

	// Randomize respawn, define time parameters
	public int counter=0;
	public int randomspawn;
	public int vanish;

	public SoundSampleHandle rayascream;
	public SoundSourceHandle enemysource;

	void Start () {
		// Set starting parameters
		agent = GetComponent<NavMeshAgent> ();
		oldrot = transform;
		vanish=600;
		randomspawn=0;


		rayascream=Audio.RegisterSample ("Assets/Music/SAMPLES/SCREAM.wav");
		while (!Audio.IsSoundSampleLoaded(rayascream)) {}
		rayav_csharp.Vector3 sourcePosition = RayaUtility.RayaUtility.rayaPosition (transform.position);
		rayav_csharp.Vector3 translation = new rayav_csharp.Vector3 (1, 0, 0);
		enemysource = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition,translation), SoundSourceAttenuation.DivByDistance);
	}
	

	void Update () {

	}

	void FixedUpdate () {
		// Increase counter per stable interval
		counter++;


if (counter > 8) {
			// Limit maximum and minimum threat levels, define threat decrement every time interval (counter spin)
	if (incomingsound < 0.7) incomingsound = 0.7f;
	if (incomingsound > 9) incomingsound = 9f;
	incomingsound = incomingsound - 0.1f;
	counter = 0;}
	
	//	ENEMY AI ----------------------------------------------
	// START WITH PIANO PLAYING

	if (piano.audio.isPlaying) {
	
			Audio.SetSoundSourcePosition (enemysource , RayaUtility.RayaUtility.rayaPosition (transform.position));
	// Update enemy's destination and scream if destination is further away
	agent.SetDestination (target.position);
			if ( oldtarget!=target) {oldtarget=target;//audio.PlayOneShot(scream, 1);
				 Audio.Play(rayascream,enemysource);}

	// Increase vanish counter if enemy is not visible to the camera (not rendered, which adds even more surprise element)
	if (!body.renderer.isVisible) {vanish++; }

	// Enemy VANISHING --------------------------------------------
	if (vanish>700 && incomingsound<2) {
				// Reset threat level and play scream
				incomingsound=0.7f;


				// RESPAWN ===============================================
				// First, "special" respawn at spawn1 with piano as target
				if (randomspawn==0) {transform.position=spawn1.position; target=piano.transform; agent.enabled = true; agent.ResetPath();}
				// Regular respawns and targets
				if (randomspawn==1) {transform.position=spawn1.position; target=spawn3; agent.enabled = true; agent.ResetPath();}
				if (randomspawn==2) {transform.position=spawn2.position; target=spawn3; agent.enabled = true; agent.ResetPath();}
				if (randomspawn==3) {transform.position=spawn3.position; target=spawn1; agent.enabled = true; agent.ResetPath();}
				transform.rotation=oldrot.rotation;

				if (!audio.isPlaying) {audio.PlayOneShot(scream, 1);
					Audio.Play(rayascream,enemysource);}

				// Randomize next respawn spot, reset "vanish" counter
				randomspawn = (int)Random.Range(1f, 4F);
				vanish=0;
									}

							}

		
	
}
}
