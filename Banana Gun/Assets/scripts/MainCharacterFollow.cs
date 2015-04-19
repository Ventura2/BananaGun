using UnityEngine;
using System.Collections;

public class MainCharacterFollow : MonoBehaviour {

	public Transform bazooka;        // The transform of the projectile to follow.
	public Transform lockLeft;           // The transform representing the left bound of the camera's position.
	public Transform lockRight;          // The transform representing the right bound of the camera's position.

	public float cameraForce = 5f;
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPosition = transform.position;
		
		// Set the x value of the stored position to that of the bird.
		newPosition.x = bazooka.position.x;
		
		// Clamp the x value of the stored position between the left and right bounds.
		newPosition.x = Mathf.Clamp (newPosition.x, lockLeft.position.x, lockRight.position.x);

		newPosition.y = bazooka.position.y;
		
		// Set the camera's position to this stored position.
		transform.position = Vector3.Lerp(Camera.main.transform.position, newPosition, Time.deltaTime * cameraForce);
	}
}