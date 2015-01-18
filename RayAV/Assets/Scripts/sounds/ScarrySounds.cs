using UnityEngine;
using System.Collections;

public class ScarrySounds : MonoBehaviour {

	public AudioSource source;
	public GameObject bogus;

	public GameObject player;
	public AudioClip fallsound;
	public GameObject fallplace;
	public AudioClip beachsound;
	public GameObject beachplace;
	public AudioClip endsound1;
	public AudioClip endsound2;
	public GameObject endplace;

	
	bool fall = false;
	bool beach = false;
	bool end = false;
	public bool tutorial = true;

	public Font myFont;
	public Texture2D tutorialgui;
	public Texture2D blackgui;
	float y=0;
	int final=0;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {


		if ((player.transform.position - fallplace.transform.position).magnitude < 2f && fall == false) {
						source.PlayOneShot (fallsound, 1f);
						fall = true;
				}
		if ((player.transform.position-beachplace.transform.position).magnitude<1f && beach==false) {
				source.PlayOneShot(beachsound,1f);
			beach=true;

	}
		if ((player.transform.position-endplace.transform.position).magnitude<1.8f && end==false) {
			//AudioListener.pause=true;
			player.rigidbody.constraints=RigidbodyConstraints.FreezeAll;
			end=true;
			bogus.renderer.enabled=true;

			source.enabled=false;
			source.enabled=true;

			//source.ignoreListenerPause=true;
			source.PlayOneShot(endsound2,1f);


		}

		if (end == true) final++;
		if (end==true && final>1000) y=y+0.4f;
		if (Input.GetKey("space") && tutorial == true) tutorial = false;
}

	void OnGUI () {
		if (tutorial == true) {
			GUIStyle myStyle = new GUIStyle ();
			//myStyle.font = myFont;
			myStyle.fontSize = 30;
			myStyle.normal.textColor = Color.white;
			GUI.color = new Color (255, 255, 255, 0.95f);
			
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tutorialgui);
			GUI.Label(new Rect( Screen.width/2-400, Screen.height/2-200, Screen.width, Screen.height), "Move using WSAD\nRun using Left Shift\nJump using Space\n\n" +
			          "Pick up and use objects by left clicking mouse\n"+
			          "Throw clicking left again, release clicking right\n\n"+
			          "Try to esacape... But no matter what...\n"+
			          "Proceed slowly and BE QUIET!\n\n"+
			          "Press Space to start",myStyle);

			
		}

		if (end == true && final>800) {
						GUIStyle myStyle = new GUIStyle ();
						//myStyle.font = myFont;
						myStyle.fontSize = 30;
						myStyle.normal.textColor = Color.white;
						GUI.color = new Color (255, 255, 255, 1);

						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackgui);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y, 200, 50), "SILENT NIGHTMARE", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 50, 200, 50), "Created by:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 100, 200, 50), " ", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 150, 200, 50), "Karol Matyasik and Maciej Doniec", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 200, 200, 50), "", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 250, 200, 50), "Scripts, Objects and Mechanics:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 300, 200, 50), "Kaem Nub", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 350, 200, 50), "", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 450, 200, 50), "Level Design:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 500, 200, 50), "mdonietz", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 550, 200, 50), "", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 600, 200, 50), "Testing:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 650, 200, 50), "-=MM=-", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 700, 200, 50), "", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 750, 200, 50), "Music:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 800, 200, 50), "Matygoysh", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 850, 200, 50), "", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 900, 200, 50), "Sound Effects:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 950, 200, 50), "BlinDmAn & RayaV team", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 1000, 200, 50), "", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 1050, 200, 50), "Speshul Thanks:", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 1100, 200, 50), "Zbyszko, Marqs, pushEQ, ctp.doniu, Zet Team", myStyle);

						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 1800, 200, 50), "THE END", myStyle);
						GUI.Label (new Rect ((Screen.width / 2) - 100, Screen.height - y + 2800, 200, 50), "?", myStyle);

				}
	}

}
