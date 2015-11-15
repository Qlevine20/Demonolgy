﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	//set for crystals[]
	//Keep track of crystals picked up until you hit a checkpoint, and then erase the set and start over.
	//If you respawn at a checkpoint, reinstantiate all the crystals in the set

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter2D(Collider2D other){
			if(other.gameObject.tag == "Player"){
			CharacterBehavior.activeCheckpoint = this.gameObject;
			print ("Checkpoint has changed");
			}
	}
}
