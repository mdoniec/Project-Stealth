using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class Player_Rayav : MonoBehaviour {
	
	//private SoundSampleHandle wooden;
	private int counter = 0;

	public void Start () {
		Audio.Initialize ("Assets/example_config.rconf");
//		wooden=Audio.RegisterSample ("Assets/rayav_assets/wavs/Gun.ogg");
//		while (!Audio.IsSoundSampleLoaded(wooden)) {}
		

				Audio.SetReceiver (RayaUtility.RayaUtility.rayaPosition (transform.position),
		          RayaUtility.RayaUtility.fromUnityVector3 (transform.forward),
		           RayaUtility.RayaUtility.fromUnityVector3 (transform.up));


		}
	
	// Update is called once per frame
	void Update () {


		counter++;

		if (counter % 5 == 0) {
			Audio.SetReceiver(RayaUtility.RayaUtility.rayaPosition(transform.position),
			                  RayaUtility.RayaUtility.fromUnityVector3(transform.forward),
			                  RayaUtility.RayaUtility.fromUnityVector3(transform.up));
			counter = 0;
					}
			Audio.Flush();
//				
//
//		
	}

	public void OnApplicationQuit()
	{
		Audio.Shutdown ();
		Audio.UnloadLibrary ();
	}

}
