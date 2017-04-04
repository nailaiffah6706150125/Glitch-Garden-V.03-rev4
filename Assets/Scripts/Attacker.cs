﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * currentSpeed);
		if (!currentTarget) {
			anim.SetBool ("isAttacking", false);
		}
	}

	public void SetSpeed(float speed){
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage){
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}

	public void Attack(GameObject obj){
		currentTarget = obj;
	}
}
