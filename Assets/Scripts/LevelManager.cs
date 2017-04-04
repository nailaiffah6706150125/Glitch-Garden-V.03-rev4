using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private float splashTime = 3.0f;

	void Start(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			Invoke ("LoadNextLevel", splashTime);
		}
	}

	public void LoadLevel(string name){
		Debug.Log ("Requesting level : " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitGame(){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}

	public void LoadNextLevel(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
		
}
