using UnityEngine;
using System.Collections;
using rayav_csharp;
using System;
using System.IO;


public class Player_Rayav : MonoBehaviour {


	
	void Start () {

		string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process);
		string dllPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Plugins";
		if(currentPath.Contains(dllPath) == false)
		{
			Environment.SetEnvironmentVariable("PATH", currentPath + Path.PathSeparator + dllPath, EnvironmentVariableTarget.Process);
		}
	
	
	
		Audio.Initialize(@"\\Assets\rayav_config.rconf");
		//Audio.SetReceiver (new rayav_csharp.Vector3 (transform.position.x,transform.position.y,transform.position.z), 
	   //                		new rayav_csharp.Vector3 (transform.forward.x,transform.forward.y,transform.forward.z),
		//                    new rayav_csharp.Vector3 (transform.up.x,transform.up.y,transform.up.z));

		//SoundSourceHandle source = Audio.AddSoundSource(new rayav_csharp.Vector3 (10f,-5f,-23f), SoundSourceAttenuation.DivByDistance);
		
		//SoundSampleHandle sample = Audio.RegisterSample(@"C:\Users\Karlos\Desktop\Inzynierka\Project-Stealth\Project-Stealth\RayAV\Assets\Music\FootstepsSoundsCarpetPack\footsteps_run_carpet_1.wav");             
		
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
