using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Abstact class that will contain all logic for any entities in the world
 * that are not a world object. Examples include the player themselves, mobs, npcs, etc.
 * 
 * @author Nick
 */
public abstract class Entity : MonoBehaviour {

	// Properties
	public int ID { get; set; }

	public string Name { get; set; }

	public int Level { get; set; }

	public Entity() : base() {

	}

	public void Update() {
		doUpdate();
	}

	public abstract void doUpdate();

	public void Start() {
		init();
	}

	public abstract void init();

	public void FixedUpdate() {
		doMovement(true);
	}

	public abstract void doMovement(bool canMove);

}