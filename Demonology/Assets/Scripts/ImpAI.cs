﻿using UnityEngine;
using System.Collections;

public class ImpAI : DemonBehavior {

	public float lavaSpeed;
	public Animation lavaDeath;

	// Use this for initialization
	public override void Start () {
		Physics2D.IgnoreLayerCollision(10,9);
		base.Start ();
	}
	// Update is called once per frame

	public override void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "magma") {
			if (lavaDeath != null) {
				lavaDeath.Play ();
			}
			gameObject.layer = LayerMask.NameToLayer ("Player");
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			StartCoroutine (WaitTime (2f));
			
		} 
		else if (other.gameObject.tag == "spike") {
			if (lavaDeath != null) {
				lavaDeath.Play ();
			}
			gameObject.layer = LayerMask.NameToLayer ("Player");
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			speed = 0;
		} 
		else 
		{
			base.OnCollisionEnter2D (other);
		}
			
	}


	public override IEnumerator WaitTime(float num)
	{
		speed = 0;
		yield return new WaitForSeconds (num);
		OnDeath ();
	}
}
