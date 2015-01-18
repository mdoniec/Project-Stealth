using rayav_csharp;
using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour {

	public float counter =0 ;
	public float shakeduration=2000;
	public float hitcounter =0;
	public float health =100;
	public bool dead = false;

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

	public Texture2D blackgui;
	public Font myFont;


	void Start () {
}


	
	// Update is called once per frame
	void Update () {
}

	void FixedUpdate() {
// Player is seeing the Enemy
if (enemyrenderer.renderer.isVisible) {
RaycastHit hit;
			// Check if you see "BlindMan" directly, if so - play statik sound, if not, pause the sound
if (Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward),out hit)) {
				if (hit.collider.name=="BlindMan") if (!statik.isPlaying) statik.Play();
			} else statik.Pause();
}   else statik.Pause();

// Loose health if you see the Enemy (statik is playing)
if (statik.isPlaying) health = health - 0.1f;

///// Enemy in close range ---------------------------------------------------------------------
if ((transform.position-enemyrenderer.transform.position).magnitude<1.3f) {
	// Loose health
	health = health - 0.3f;
	// Shake the camera every conter cycle to imitate player being hit
	if (hitcounter>50) {Shake(); hitcounter=0;}
	hitcounter++;		
}
	// 80+ HP  Breath EFFECTS
	if ( health>80) {
	breath.clip=breath100;
	if (!breath.isPlaying) breath.Play();
	}
		// 20+ HP Breath EFFECTS
	if (health<80 && health>20) {
		breath.clip=breath70;
		if (!breath.isPlaying) breath.Play();
	}
		// CRITICAL HP Breath EFFECTS
	if (health<20) {
		breath.clip=breath20;
		if (!breath.isPlaying)breath.Play();
	}

//////////// Heartbeat effects - Fast/slow ------------------
		counter = counter+0.1f;
	if (counter>20 && health>80) {
		heart.Stop();
		heart.PlayOneShot(heartbeatSlow,1f);
		counter=0;

	}
	if (counter > 20 && health < 80) {
						heart.Stop ();
						heart.PlayOneShot (heartbeatFast, 1f);
						counter = 0;
				}
		//----------------------------------------------------------

if (health > 0) {
			// Health regeneration per time interval while the player is not dead
	health = health + 0.03f;
} else {
			// IF the player died, scream and allow restart
	dead = true;
	enemy.audio.PlayOneShot(SCREAM,1f);
	if (Input.GetKey (KeyCode.R)) {
				Audio.Shutdown ();
				Audio.UnloadLibrary ();
		Application.LoadLevel (0);
		
	}
}
	

if (health > 100f) health = 100f; // Limit max hp to 100
	}

	void OnGUI() {
		// Set GUI style to desited one
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.fontSize = 100;
		myStyle.normal.textColor = Color.white;
		GUI.color = new Color(255, 255, 255, 1-health/100);
	
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackgui);

		// If the player is dead - display "dead" message
		if (dead == true) {
		GUI.Label(new Rect( Screen.width/2-400, Screen.height/2-100, Screen.width, Screen.height), "Bobby, please be quiet..." +
			"\n\n"+
			          "     [R] to try again"+
			""+
			"",myStyle);

				}

		//GUI.Label(new Rect(10, 10, 100, 20), health.ToString()); // Display health (debug) 
	}

	// Shake camera
void Shake() {
float elapsed = 0.0f;
float magnitude = 40f;

while (elapsed < shakeduration) {
			// increase elapsed time
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
			// Shake camera by adding force to the camera rigidbody
			transform.rigidbody.AddForce( new UnityEngine.Vector3(x, y, z));
			

		}
		

	}


}