using UnityEngine;
using System.Collections;

public class LampFlicker : MonoBehaviour {

	// Script for lamp "flicker" effect
	void Start () {
	
	}
	


	void FixedUpdate () {
		// DISABLE LAMP with 1/10 chance
		if (Random.value <= 0.90f) {
						this.light.enabled = true;
				} else this.light.enabled = false;
}
}