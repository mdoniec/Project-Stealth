using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class CollisionRayav : MonoBehaviour {
	
	public AudioClip impact ;
	public GameObject enemy;
	public EnemyAI enemyscript;
	public SourcesQueue sourceS;
	public float distance;
	
	public string path;
	SoundSampleHandle RayavImpact ;
	public int arraysize;
	public int sourcenumberview=0;

	rayav_csharp.Vector3 sourcePosition;
	rayav_csharp.Vector3 translation;
	
	void Start () {
				// RAYAV
				arraysize = 5;

				path = "Assets/Music/SAMPLES/" + impact.name + ".wav";
				RayavImpact = Audio.RegisterSample (path);
				while (!Audio.IsSoundSampleLoaded(RayavImpact)) {
				}
				rayav_csharp.Vector3 sourcePosition = RayaUtility.RayaUtility.rayaPosition (transform.position);
				rayav_csharp.Vector3 translation = new rayav_csharp.Vector3 (1, 0, 0);

		}
	void OnCollisionEnter(Collision collision) 
	{

		if (collision.relativeVelocity.magnitude / 2f > 0.35) {

						// On collision
						// Calculate distance from the enemy
						distance = (transform.position - enemy.transform.position).magnitude;
						// Play impact sound with volume proportional to impact velocity

			//sourceS.CollisionSources [sourceS.sourcenumber] = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition, translation), SoundSourceAttenuation.DivByDistance);
			Audio.SetSourceVolume (sourceS.CollisionSources [sourceS.sourcenumber], collision.relativeVelocity.magnitude / 2f); //
			Audio.SetSoundSourcePosition (sourceS.CollisionSources [sourceS.sourcenumber], RayaUtility.RayaUtility.rayaPosition (transform.position));
			Audio.Play (RayavImpact, sourceS.CollisionSources [sourceS.sourcenumber]);
			if (sourceS.sourcenumber<arraysize-1) Audio.StopSource (sourceS.CollisionSources [sourceS.sourcenumber+1]);
			if (sourceS.sourcenumber==arraysize-1) Audio.StopSource (sourceS.CollisionSources [0]);

			print (sourceS.sourcenumber);
						sourceS.sourcenumber++;
						if (sourceS.sourcenumber >= arraysize)
								sourceS.sourcenumber = 0;

		
						// If incoming sound is louder than the one currently stored and is far enough -> change enemy's target to new sound source
						if ((enemyscript.incomingsound < collision.relativeVelocity.magnitude * 2 * rigidbody.mass / (transform.position - enemy.transform.position).magnitude) 
								&& ((transform.position - enemy.transform.position).magnitude > 1.2)) {
								enemyscript.target = transform;
								// Set new threat level (incomingsound) at level of the signal currently attracting the enemy
								enemyscript.incomingsound = (collision.relativeVelocity.magnitude * 2 * rigidbody.mass / (transform.position - enemy.transform.position).magnitude);
						}
				}
	}
	
	// Update is called once per frame
	void Update () {	
		sourcenumberview = sourceS.sourcenumber;		

	}
}
