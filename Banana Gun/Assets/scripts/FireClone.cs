using UnityEngine;
using System.Collections;

public class FireClone : MonoBehaviour {

	public float forceFire = 10;
	private bool fired;
	private Animator anim;

	// Use this for initialization
	void Start () {
		fired = false;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown(0) && !fired)
		{
			//Get vector to mouse
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 launchVector = mousePos - transform.position;
			launchVector.z = 0;

			//instantiate and add velocity
			GameObject clone =  Instantiate(this.gameObject, launchVector.normalized*0.5f + transform.position, Quaternion.identity) as GameObject;
			Vector2 force = (Vector2)launchVector;

			clone.GetComponent<Rigidbody2D>().AddForce (forceFire*force.normalized, ForceMode2D.Impulse);

			clone.GetComponent<PlayerMovement>().facingRight = GetComponent<PlayerMovement>().facingRight;
			Camera.main.GetComponent<MainCharacterFollow>().bazooka = clone.transform;

			anim.SetTrigger("fire");
			fired=true;

			//Disable all the scripts and set as trigger the collision
			foreach(MonoBehaviour mono in GetComponents<MonoBehaviour>())
			{
				mono.enabled = false;
			}

		}

	}



	void OnDrawGizmos()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 launchVector = mousePos - transform.position;
		Gizmos.DrawLine(mousePos, transform.position);
	}
}
