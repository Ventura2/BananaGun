using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxVelocity = 10f;

	public bool facingRight;
	private Rigidbody2D rb2d;
	private Animator anim;

	public Transform lockLeft;           // The transform representing the left bound of the camera's position.
	public Transform lockRight;          // The transform representing the right bound of the camera's position.

	private bool jumping;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		
		facingRight = true;
	}

	// Use this for initialization
	void Start () {
		jumping = true;
	}

	void Update()
	{


	}
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");

		if(!jumping)
			rb2d.velocity = new Vector2(move*maxVelocity , rb2d.velocity.y);
		else
			rb2d.AddForce(Vector2.right* move*maxVelocity *0.1f);

		if(move > 0.2f && !facingRight)
			Flip ();
		else if(move < 0.2f && facingRight)
			Flip ();

		anim.SetFloat ("speed", Mathf.Abs(move));

		
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		Vector2 bottom = collider.bounds.min;

		bottom.y -= 0.01f;
		bottom.x = collider.bounds.center.x;
		
		RaycastHit2D hit = Physics2D.Raycast(bottom, -Vector2.up, 0.01f);
		
		Debug.DrawLine(bottom, -Vector2.up*0.1f+bottom);
		
		if(hit.collider != null && hit.collider.name != gameObject.name)
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
