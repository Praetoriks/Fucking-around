using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Will handle the player and any interactions with the player.
 * 
 * @author Nick
 */
public class Player : Entity {

	public int Health { get; set; }

	public Player(int id, string name) : base(id, name) { }

	// Called whenever the fuck we want.
	public override void doLogic() {

	}
}
