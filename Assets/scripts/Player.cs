using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Will handle the player and any interactions with the player.
 * 
 * @author Nick
 */
public class Player : Entity {

	public int speed = 1;
	//public int Health { get; set; }

	public Player(int id, string name) : base(id, name) { }

	// Called whenever the fuck we want.
	public override void doLogic() {
		doMovement(true);
	}

	/**
	 * Handle player movement.
	 * 
	 * @param  {[type]} bool canMove       Wheather or not the player can move.
	 */
	private void doMovement(bool canMove) {
		if (!canMove) return;

		float vert = getAxes("Vertical");
		float hori = getAxes("Horizontal") ;
		transform.Translate((hori * speed), (vert * speed), 0); // x, y, z
	}

	private float getAxes(string axes) {
		return Input.GetAxis(axes);
	}
}
