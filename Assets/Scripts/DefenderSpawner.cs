using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find ("Defender");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!defenderParent) {
			defenderParent = new GameObject ("Defender");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateMousePosOfWorldPos ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	void SpawnDefender(Vector2 roundedPos, GameObject defender){
		GameObject newDefender = Instantiate (defender, roundedPos, Quaternion.identity);
		newDefender.transform.parent = defenderParent.transform;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);

		return new Vector2 (newX, newY);
	}

	Vector2 CalculateMousePosOfWorldPos(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;

		Vector2 rawMousePos = new Vector2 (mouseX, mouseY);
		Vector2 rawWorldPos = myCamera.ScreenToWorldPoint (rawMousePos);

		return rawWorldPos;
	}
}
