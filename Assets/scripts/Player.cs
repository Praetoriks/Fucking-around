using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Will handle the player and any interactions with the player.
 * 
 * @author Nick
 */
public class Player : Entity {

	public float speed = .5f;
	private bool facingLeft = false;
	private Rigidbody2D rigid2D;
	private Animator anim;

	//public int Health { get; set; }

	// XXX: Are constructor methods even fucking used in unity?
	// When is this even initailized? Forced to use Start() function instead.
	public Player(int id, string name) : base(id, name) { 
		//rigid2D = GetComponent<Rigidbody>();
		//anim = GetComponent<Animator>();
	}

	public void Start() {
		rigid2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Called whenever the fuck we want.
	public override void doLogic() {
		//doMovement(true);
	}

	/**
	 * Handle player movement.
	 * 
	 * @param  {[type]} bool canMove       Wheather or not the player can move.
	 */
	private void doMovement(bool canMove) {
		if (!canMove) return;

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

	public void FixedUpdate() {
		doMovement(true);
	}
}
