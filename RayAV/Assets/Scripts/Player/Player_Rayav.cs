using UnityEngine;
using System.Collections;
using rayav_csharp;


public class Player_Rayav : MonoBehaviour {
	

	void Start () {
	Audio.Initialize("Assets/example_config.rconf");
	//	Audio.SetReceiverTransformation (RayavVector3 (transform.position), RayavVector3 (transform.forward),RayavVector3 (transform.up));

	//	SoundSourceHandle source = Audio.AddSoundSource(RayavVector3 (new UnityEngine.Vector3(10f,-5f,-23f)), 
		                                             //   SoundSourceAttenuation.DivByDistance);

		//SoundSampleHandle sample = Audio.RegisterSample(@"C:\Users\Karlos\Desktop\Inzynierka\Project-Stealth\RayAV\Assets\Music\FootstepsSoundsCarpetPack\footsteps_run_carpet_1.wav");             
		
		//while (!Audio.IsSoundSampleLoaded(sample)) {}
		
		//Audio.Play(sample, source);  
	}
	
	// Update is called once per frame
	void Update () {
	//	Audio.SetReceiverTransformation (RayavVector3 (transform.position), RayavVector3 (transform.forward),
	//	                                 RayavVector3 (transform.up));
	//
	}
}
