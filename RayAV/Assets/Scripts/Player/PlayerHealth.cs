using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float counter =0 ;

	public float health =100;
	public Texture2D blackgui;
	//public string enemyseen;
	//public string enemyclose;
	public AudioClip breath100;
	public AudioClip breath70;
	public AudioClip breath20;
	public AudioClip heartbeatSlow;
	public AudioClip heartbeatFast;
	public AudioClip staticSound;

	public AudioSource heart;
	public AudioSource breath;
	public AudioSource statik;

	public GameObject enemy;




	// Use this for initialization
	void Start () {
	







	}


	
	// Update is called once per frame
	void Update () {
		 


	}

	void FixedUpdate() {

		
		//////// YOU SEE THE ENEMY
		if (enemy.renderer.isVisible) {
			rigidbody.AddTorque(Random.value*30,0,0);
			health = health - 0.05f;
			if (!statik.isPlaying) statik.Play(); 
		}   else statik.Pause();
		
		///// IF ENEMY IS CLOSE
		if ((transform.position-enemy.transform.position).magnitude<1.3f) {
			health = health - 0.25f;
			
		}
		
		if ( health>70) {
			breath.clip=breath100;
			if (!breath.isPlaying) breath.Play();
		}
		
		if (health<70 && health>20) {
			breath.clip=breath70;
			if (!breath.isPlaying) breath.Play();
		}
		if (health<20) {
			breath.clip=breath20;
			if (!breath.isPlaying)breath.Play();
		}
		
		
		health = health + 0.02f;
		if (health > 100f)
			health = 100f;
		
		



		counter = counter+0.1f;
		if (counter>20 && health>80) {
			heart.Stop();
			heart.PlayOneShot(heartbeatSlow,1f);
			counter=0;
		}
		if (counter>20 && health<80) {
			heart.Stop();
			heart.PlayOneShot(heartbeatFast ,1f);
			counter=0;
		}

	}

	void OnGUI() {
		GUI.color = new Color(255, 255, 255, 1-health/100);
		GUI.Label(new Rect(10, 10, 100, 20), health.ToString());

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackgui); 
	}


}