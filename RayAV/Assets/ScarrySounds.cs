using UnityEngine;
using System.Collections;

public class ScarrySounds : MonoBehaviour {

	public AudioSource source;

	public GameObject player;
	public AudioClip fallsound;
	public GameObject fallplace;
	public AudioClip beachsound;
	public GameObject beachplace;
	bool fall = false;
	bool beach = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position - fallplace.transform.position).magnitude < 2f && fall == false) {
						source.PlayOneShot (fallsound, 1f);
						fall = true;
				}
		if ((player.transform.position-beachplace.transform.position).magnitude<2f && beach==false) {
				source.PlayOneShot(beachsound,1f);
				beach=true;
	}
}
}
