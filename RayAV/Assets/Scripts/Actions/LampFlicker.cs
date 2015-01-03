using UnityEngine;
using System.Collections;

public class LampFlicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Random.value <= 0.90f) {
						this.light.enabled = true;
				} else this.light.enabled = false;
}
}