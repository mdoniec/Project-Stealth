using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float counter =0 ;
	public float shakeduration=2000;
	public float hitcounter =0;
	public bool dead = false;
	public Font myFont;

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

	public GameObject enemyrenderer;
	public GameObject enemy;
	public AudioClip SCREAM;



	// Use this for initialization
	void Start () {
	

	





	}


	
	// Update is called once per frame
	void Update () {
		 
	

	}

	void FixedUpdate() {

		
		//////// YOU SEE THE ENEMY
		if (statik.isPlaying) health = health - 0.1f;
		if (enemyrenderer.renderer.isVisible) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit)) {
				//print(hit.collider.name);
				if (hit.collider.name=="BlindMan") {

				if (!statik.isPlaying) statik.Play();}
			} else statik.Pause();
}   else statik.Pause();

		////// 
	



		///// IF ENEMY IS CLOSE
		if ((transform.position-enemyrenderer.transform.position).magnitude<1.3f) {
			health = health - 0.3f;
			if (hitcounter>50) {Shake(); hitcounter=0;}
			hitcounter++;
			
		}
		
		if ( health>80) {

			breath.clip=breath100;
			if (!breath.isPlaying) breath.Play();
		}
		
		if (health<80 && health>20) {
			breath.clip=breath70;
			if (!breath.isPlaying) breath.Play();
		}
		if (health<20) {
			breath.clip=breath20;
			if (!breath.isPlaying)breath.Play();
		}
		
		
		if (health > 0) {
						health = health + 0.03f;
		} else {
			dead = true;
			 enemy.audio.PlayOneShot(SCREAM,1f);
			if (Input.GetKey (KeyCode.R)) {
								
								Application.LoadLevel (0);

						}
				}




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
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.fontSize = 100;
		myStyle.normal.textColor = Color.white;
	
		GUI.color = new Color(255, 255, 255, 1-health/100);
		//GUI.contentColor = Color.black;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackgui);
		if (dead == true) {
		GUI.Label(new Rect( Screen.width/2-400, Screen.height/2-100, Screen.width, Screen.height), "Bobby, please be quiet..." +
			"\n\n"+
			          "     [R] to try again"+
			""+
			"",myStyle);

				}
		GUI.Label(new Rect(10, 10, 100, 20), health.ToString());
		 
	}

	void Shake() {
		
		float elapsed = 0.0f;
		float magnitude = 40f;
		//print ("yolo");

		
		while (elapsed < shakeduration) {
			
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / shakeduration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
			
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			float z = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;
			z *= magnitude * damper;
			transform.rigidbody.AddForce( new Vector3(x, y, z));
			

		}
		

	}


}