using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxVelocity = 10f;

	private bool facingRight;
	private Rigidbody2D rb2d;
	private Animator anim;

	public Transform lockLeft;
	public Transform lockRight;

	void Awake(){
		facingRight = true;
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");

		rb2d.velocity = new Vector2(move*maxVelocity , rb2d.velocity.y);

		if(move > 0 && !facingRight)
			Flip ();
		else if(move < 0 && facingRight)
			Flip ();

		anim.SetFloat ("speed", Mathf.Abs(move));

		Vector3 newPosition = transform.position;
		
		// Clamp the x value of the stored position between the left and right bounds.
		newPosition.x = Mathf.Clamp (newPosition.x, lockLeft.position.x, lockRight.position.x);
		
		// Set the camera's position to this stored position.
		transform.position = newPosition;

	}

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x = theScale.x * -1;
		transform.localScale = theScale;
	}
}
