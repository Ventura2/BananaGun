using UnityEngine;
using System.Collections;

public class MainCharacterFollow : MonoBehaviour {

	public Transform bazooka;        // The transform of the projectile to follow.
	//public Transform farLeft;           // The transform representing the left bound of the camera's position.
	//public Transform farRight;          // The transform representing the right bound of the camera's position.
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		
		// Set the x value of the stored position to that of the bird.
		newPosition.x = bazooka.position.x;
		
		// Clamp the x value of the stored position between the left and right bounds.
		//newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		
		// Set the camera's position to this stored position.
		transform.position = newPosition;
	}
}