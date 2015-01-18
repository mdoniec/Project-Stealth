using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class CollisionSound : MonoBehaviour {
//
//	public AudioClip impact ;
//	public GameObject enemy;
//	public EnemyAI enemyscript;
//	public float distance;
//
//	public string path;
//	SoundSampleHandle RayavImpact ;
//	SoundSourceHandle CollisionSource;
//
//
//		void Start () {
//		// RAYAV
//		//path = "Assets/Music/SAMPLES/" + impact.name + ".wav";
//		RayavImpact=Audio.RegisterSample ("Assets/rayav_assets/wavs/Gun.ogg");
//		while (!Audio.IsSoundSampleLoaded(RayavImpact)) {}
//		rayav_csharp.Vector3 sourcePosition = RayaUtility.RayaUtility.rayaPosition (transform.position);
//		rayav_csharp.Vector3 translation = new rayav_csharp.Vector3 (1, 0, 0);
//		CollisionSource = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition,translation), SoundSourceAttenuation.DivByDistance);
//
//}
//		
//void OnCollisionEnter(Collision collision) 
//		{
//		// On collision
//		// Calculate distance from the enemy
//distance = (transform.position - enemy.transform.position).magnitude;
//		// Play impact sound with volume proportional to impact velocity
//
//		Audio.SetSourceVolume (CollisionSource, 1f); //collision.relativeVelocity.magnitude/2f
//		Audio.SetSoundSourcePosition (CollisionSource, RayaUtility.RayaUtility.rayaPosition (transform.position));
//		Audio.Play(RayavImpact,CollisionSource);
//
//		// If incoming sound is louder than the one currently stored and is far enough -> change enemy's target to new sound source
//		if ((enemyscript.incomingsound < collision.relativeVelocity.magnitude * 2 * rigidbody.mass / (transform.position - enemy.transform.position).magnitude) 
//		    && ((transform.position - enemy.transform.position).magnitude > 1.4)) {
//			enemyscript.target = transform;
//			// Set new threat level (incomingsound) at level of the signal currently attracting the enemy
//			enemyscript.incomingsound = (collision.relativeVelocity.magnitude * 2 * rigidbody.mass/ (transform.position - enemy.transform.position).magnitude);
//		}
//
//		}
//	
//	// Update is called once per frame
//	void Update () {	
//	}
}
