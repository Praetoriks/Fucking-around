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

	// Constructors
	public Entity(int id) : this(id, "") { }

	public Entity(int id, string name) : this(id, name, 0) { }

	public Entity(int id, string name, int level) {
		this.ID = id;
		this.Name = name; 
		this.Level = level;
	}

	// Inhereited

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		doLogic();
	}
	
	public abstract void doLogic();
}