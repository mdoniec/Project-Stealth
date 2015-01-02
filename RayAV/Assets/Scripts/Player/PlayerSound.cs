using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class PlayerSound : MonoBehaviour {






	//string colidedsurface ;
	int maxSpeed = 80;
	int counter = 0 ;
	// Use this for initialization
	
	public SoundSampleHandle wooden ;
	public SoundSampleHandle carpet ;
	public SoundSampleHandle shower ;
	private SoundSourceHandle steps;
	float carpetvolume = 0.2f;


void Start () {
		//Audio.Initialize ("Assets/example_config.rconf");
				//Audio.SetReceiver (RayaUtility.RayaUtility.fromUnityVector3 (transform.position),
		//                   RayaUtility.RayaUtility.fromUnityVector3 (transform.forward),
		//                   RayaUtility.RayaUtility.fromUnityVector3 (transform.up));




		//RAYAV SOURCES
		//wooden=Audio.RegisterSample ("Assets/rayav_assets/wavs/Gun.ogg");
		wooden=Audio.RegisterSample ("Assets/Music/FootstepsSoundsCarpetPack/footsteps_walk_carpet_3.wav");
		//carpet=Audio.RegisterSample ("Assets/Music/FootstepsSoundsCarpetPack/footsteps_walk_carpet_3.wav");
		shower=Audio.RegisterSample ("Assets/Music/FootstepsSoundsCarpetPack/shower - prysznic 4.wav");


		rayav_csharp.Vector3 sourcePosition = RayaUtility.RayaUtility.fromUnityVector3 (transform.position);
		rayav_csharp.Vector3 translation = new rayav_csharp.Vector3 (1, 0, 0);
		steps = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition,translation), SoundSourceAttenuation.DivByDistance);
		Audio.SetSourceVolume (steps, 0.1f);

				
		}
void OnCollisionStay(Collision collisionInfo) 
	{


//		if (collisionInfo.gameObject.name=="Map" && !Audio.IsSoundSampleLoaded(wooden)) {
//
//			if (rigidbody.velocity.magnitude*100>maxSpeed/5 ) Audio.Play(wooden,steps);
//			} else 
//				if (rigidbody.velocity.magnitude*100<maxSpeed/5 || collisionInfo.gameObject.name != "Map") Audio.StopSource(steps);


//		if (collisionInfo.gameObject.name=="Corridor Grey Carpet" && !audio.isPlaying) {
//			audio.clip=carpet;
//			audio.volume=carpetvolume;
//			if (rigidbody.velocity.magnitude*100>maxSpeed/5 ) audio.Play();
//		} else 
//			if (rigidbody.velocity.magnitude*100<maxSpeed/5 || collisionInfo.gameObject.name != "Map") audio.Pause ();
//			
 	}


void Update () {
		Audio.SetSoundSourcePosition (steps, RayaUtility.RayaUtility.fromUnityVector3 (transform.position));

		//Audio.SetReceiver(RayaUtility.RayaUtility.fromUnityVector3(transform.position),
		//                RayaUtility.RayaUtility.fromUnityVector3(transform.forward),
		//                  RayaUtility.RayaUtility.fromUnityVector3(transform.up));


		Audio.Play(wooden,steps);

	
		counter++;

				if (counter % 400== 0) {
					counter = 0;
			Audio.Flush();		}
	}



	//void OnGUI() {
	//		GUI.Label(new Rect(10, 10, 100, 20), rigidbody.velocity.magnitude.ToString());
	//}


}

