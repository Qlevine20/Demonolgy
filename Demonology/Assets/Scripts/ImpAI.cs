﻿using UnityEngine;
using System.Collections;

public class ImpAI : DemonBehavior {

    public Animation lavaDeath;
    public AudioClip[] impSummons;
    public AudioClip[] impDeaths;

    // Use this for initialization
    public override void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 9);
        base.Start();
        AudioSource.PlayClipAtPoint(impSummons[Random.Range(0, impSummons.Length)], transform.position);

    }
	// Update is called once per frame

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "moving") 
		{
			transform.parent = other.transform;
		}
	}

	public virtual void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "moving") 
		{
			transform.parent = null;
		}
	}
	public override void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "magma") {
			if (lavaDeath != null) {
				lavaDeath.Play ();
			}
			gameObject.layer = LayerMask.NameToLayer ("Player");
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			StartCoroutine (WaitTime (2f));
			gameObject.tag = "floor";
            AudioSource.PlayClipAtPoint(impDeaths[Random.Range(0, impDeaths.Length)], transform.position);
		} 
		else if (other.gameObject.tag == "spike") {
			if (lavaDeath != null) {
				lavaDeath.Play ();
			}
			gameObject.layer = LayerMask.NameToLayer ("Ground");
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			speed = 0;
			gameObject.tag = "floor";
            AudioSource.PlayClipAtPoint(impDeaths[Random.Range(0, impDeaths.Length)], transform.position);
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
