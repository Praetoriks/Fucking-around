using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Will handle the player and any interactions with the player.
 * 
 * @author Nick
 */
public class Player : Entity {

	// XXX: Public variables show in the inspector.
	public float speed = 2f;
	public float jumpForce = 75f;
	public Transform checkGround;
	public LayerMask whatIsGround;

	// XXX: Private variables do not.
	private bool facingLeft = false;
	private Rigidbody2D rigid2D;
	private Animator anim;
	private bool onGround = false;
	private float groundRadius = 0.2f;

	public override void init() {
		rigid2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	public override void doUpdate() {

	}

	/**
	 * Handle player movement.
	 * 
	 * @param  {[type]} bool canMove       Wheather or not the player can move.
	 */
	public override void doMovement(bool canMove) {
		if (!canMove) return;
		
		if (onGround && (getAxes("Jump") > 0)) {
			anim.SetBool("ground", false);
			rigid2D.AddForce(new Vector2(0, jumpForce));
		}

		onGround = Physics2D.OverlapCircle(checkGround.position, groundRadius, whatIsGround);
		anim.SetBool("ground", onGround);
		anim.SetFloat("vSpeed", rigid2D.velocity.y);

		//float vert = getAxes("Vertical");
		float rawHorizontal = getAxes("Horizontal") ;
		rigid2D.velocity = new Vector2(rawHorizontal * speed, rigid2D.velocity.y);
		anim.SetFloat("speed", Mathf.Abs(rawHorizontal));
		if (rawHorizontal < 0 && !facingLeft) {
			flipDirection();
		} else if (rawHorizontal > 0 && facingLeft) {
			flipDirection();
		}


		//transform.Translate((hori * speed), (vert * speed), 0); // x, y, z
	}

	private void flipDirection() {
		facingLeft = !facingLeft;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	private float getAxes(string axes) {
		return Input.GetAxis(axes);
	}
}
