using UnityEngine;
using System.Collections;
using rayav_csharp;
using RayaUtility;

public class PlayerSound : MonoBehaviour {





	public Collision yo;
	//string colidedsurface ;
	int maxSpeed = 80;
	int counter = 0 ;
	// Use this for initialization
	
	public SoundSampleHandle wooden ;
	public SoundSampleHandle carpet ;
	public SoundSampleHandle auditorium ;
	public SoundSampleHandle stone;
	public SoundSampleHandle pipe;
	public SoundSampleHandle grass;
	public SoundSampleHandle sand;




	private SoundSourceHandle steps;
	float stonevolume = 1f;
	float woodvolume = 0.6f;
	float carpetvolume = 0.2f;
	public float volume;


void Start () {






		//RAYAV SOURCES
		//wooden=Audio.RegisterSample ("Assets/rayav_assets/wavs/Gun.ogg");

		wooden=Audio.RegisterSample ("Assets/Music/SAMPLES/footsteps_walk_carpet_3.wav");
		auditorium=Audio.RegisterSample ("Assets/Music/SAMPLES/footsteps_walk_carpet_2.wav");
		stone=Audio.RegisterSample ("Assets/Music/SAMPLES/StoneStep.wav");
		pipe=Audio.RegisterSample ("Assets/Music/SAMPLES/MetalBang.wav");
		grass=Audio.RegisterSample ("Assets/Music/SAMPLES/GrassStep.wav");
		sand=Audio.RegisterSample ("Assets/Music/SAMPLES/SandStep.wav");
		//shower=Audio.RegisterSample ("Assets/Music/FootstepsSoundsCarpetPack/shower - prysznic 4.wav");
		while (!Audio.IsSoundSampleLoaded(wooden)) {}


		rayav_csharp.Vector3 sourcePosition = RayaUtility.RayaUtility.rayaPosition (transform.position);
		rayav_csharp.Vector3 translation = new rayav_csharp.Vector3 (1, 0, 0);
		steps = Audio.AddSoundSource (rayav_csharp.Vector3.Add (sourcePosition,translation), SoundSourceAttenuation.DivByDistance);


				
		}
void OnCollisionStay( Collision collisionInfo) 
	{yo = collisionInfo;




		
		
	}


void Update () {
		Audio.SetSoundSourcePosition (steps, RayaUtility.RayaUtility.rayaPosition (transform.position));
		counter=counter + 3;


		if (yo.gameObject.name=="Corridor Grey Carpet" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;
			Audio.SetSourceVolume (steps, carpetvolume);

			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(wooden,steps);
		} 
		if (yo.gameObject.name=="Auditorium Panel Floor" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;
			Audio.SetSourceVolume (steps, carpetvolume);

			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(auditorium,steps);
		} 
		
		if (yo.gameObject.name=="Stone floor" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;
			Audio.SetSourceVolume (steps, stonevolume);
		
			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(stone,steps);
		} 
		if (yo.gameObject.name=="BigPipe" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;

			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(pipe,steps);
		} 

		if (yo.gameObject.name=="Grass" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;
			Audio.SetSourceVolume (steps, woodvolume);

			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(grass,steps);
		} 

		if (yo.gameObject.name=="Sand Floor" && 270-counter<rigidbody.velocity.magnitude*130 ||
		    yo.gameObject.name=="Towel" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;
			Audio.SetSourceVolume (steps, woodvolume);

			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(sand,steps);
		} 
		

		
		if (yo.gameObject.name=="Map" && 270-counter<rigidbody.velocity.magnitude*130) {
			counter=0;
			Audio.SetSourceVolume (steps, woodvolume);
			volume = woodvolume;
			if (rigidbody.velocity.magnitude*100>maxSpeed/7 ) Audio.Play(wooden,steps);
		} //else 
			//if (rigidbody.velocity.magnitude*100<maxSpeed/7) Audio.StopSource(steps);




	

	

	}
}

