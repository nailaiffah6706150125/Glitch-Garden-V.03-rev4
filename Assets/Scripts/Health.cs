using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float healthPoint = 100f;

	public void DealDamage(float damage){
		healthPoint -= damage;
		if (healthPoint <= 0) {
			Destroy (gameObject);
		}
	}
}
