using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float horizontalSensitivity = 90;
	public float verticalSensitivity = -90;
	public float correctiveStrength = 20;
	
	void Update () {

		// Add torques to vertical and horizontal axes
		rigidbody.AddTorque(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
		rigidbody.AddRelativeTorque(Input.GetAxis("Mouse Y") * verticalSensitivity, 0, 0);

		// Corrective forces
		Vector3 properRight = Quaternion.Euler(0, 0, -transform.localEulerAngles.z) * transform.right;
		Vector3 uprightCorrection = Vector3.Cross(transform.right, properRight);
		rigidbody.AddRelativeTorque(uprightCorrection * correctiveStrength);

	}
}
