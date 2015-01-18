using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class SourcesQueue : MonoBehaviour {

	public SoundSourceHandle[] CollisionSources;
	public int arraysize;
	public int sourcenumber=0;
	public rayav_csharp.Vector3 sourcePosition;
	public rayav_csharp.Vector3 translation;
	// Use this for initialization
	void Start () { 
		arraysize=5;
		sourcenumber = 0;
		CollisionSources = new SoundSourceHandle[arraysize] ;

		for (int i=0; i<arraysize; i++) {
			CollisionSources [i] = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition, translation), SoundSourceAttenuation.DivByDistance);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
