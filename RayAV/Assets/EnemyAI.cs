using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public int vanish=0;
	public Transform target;
	public NavMeshAgent agent;
	public Renderer[] rend;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		Renderer[] rend = GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {


		agent.SetDestination (target.position);
	}

	void FixedUpdate () {

//		if (!rend[0].isVisible) vanish++;
//		if (vanish > 1000) {
//			transform.position=transform.position+new Vector3(100,100,100);
//				}
	}
}
