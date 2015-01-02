using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class Player_Rayav : MonoBehaviour {
	
	private SoundSourceHandle source;
	private SoundSampleHandle sample;
	//private int counter = 0;

	public void Start () {
				Audio.Initialize ("Assets/example_config.rconf");

				//sample = Audio.RegisterSample ("Assets/rayav_assets/wavs/Gun.ogg");
		
				Audio.SetReceiver (RayaUtility.RayaUtility.fromUnityVector3 (transform.position),
		              RayaUtility.RayaUtility.fromUnityVector3 (transform.forward),
		              RayaUtility.RayaUtility.fromUnityVector3 (transform.up));

				//rayav_csharp.Vector3 sourcePosition = RayaUtility.RayaUtility.fromUnityVector3 (transform.position);			
		//rayav_csharp.Vector3 translation = new rayav_csharp.Vector3 (1, 0, 0);

				//source = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition, translation), SoundSourceAttenuation.DivByDistance);

		}
	
	// Update is called once per frame
	void Update () {
		Audio.SetReceiver(RayaUtility.RayaUtility.fromUnityVector3(transform.position),
		                  RayaUtility.RayaUtility.fromUnityVector3(transform.forward),
		                  RayaUtility.RayaUtility.fromUnityVector3(transform.up));

//		counter++;
//
//		if (counter % 40 == 0) {
//			counter = 0;
//			Audio.Flush();
//				while (!Audio.IsSoundSampleLoaded(sample)) {}
//				
//				Audio.Play(sample, source);  
//
//		}
	}

	public void OnApplicationQuit()
	{
		Audio.Shutdown ();
		Audio.UnloadLibrary ();
	}

}
