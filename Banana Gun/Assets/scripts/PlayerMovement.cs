using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxVelocity = 10f;

	private bool facingRight;
	private Rigidbody2D rb2d;
	private Animator anim;

	private bool jumping;

	void Awake(){
		facingRight = true;
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		jumping = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");

		if(!jumping)
			rb2d.velocity = new Vector2(move*maxVelocity , rb2d.velocity.y);
		else
			rb2d.velocity = new Vector2(rb2d.velocity.x + move*maxVelocity , rb2d.velocity.y);

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
	}

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x = theScale.x * -1;
		transform.localScale = theScale;
	}
}
