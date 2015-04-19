using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxVelocity = 10f;

	private bool facingRight;
	private Rigidbody2D rb2d;
	private Animator anim;

	public Transform lockLeft;           // The transform representing the left bound of the camera's position.
	public Transform lockRight;          // The transform representing the right bound of the camera's position.

	private bool jumping;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		facingRight = true;
		jumping = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");

		if(!jumping)
			rb2d.velocity = new Vector2(move*maxVelocity , rb2d.velocity.y);
		else
			rb2d.AddForce(Vector2.right* move*maxVelocity *0.1f);

		if(move > 0 && !facingRight)
			Flip ();
		else if(move < 0 && facingRight)
			Flip ();

		anim.SetFloat ("speed", Mathf.Abs(move));

		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		Vector2 bottom = collider.bounds.center;
		bottom.y -= collider.bounds.size.y;

		RaycastHit2D hit = Physics2D.Raycast(bottom , -Vector2.up, 0.1f);

		if(hit.collider != null)
			jumping=false;

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
