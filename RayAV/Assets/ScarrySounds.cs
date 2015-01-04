using UnityEngine;
using System.Collections;

public class ScarrySounds : MonoBehaviour {

	public AudioSource source;
	public AudioClip fallsound;
	public GameObject player;
	public GameObject fallplace;
	bool fall = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position-fallplace.transform.position).magnitude<2f && fall==false) {
			source.PlayOneShot(fallsound,1f);
			fall=true;
	}
}
}
