using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] musicClipArray;
	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
	}

	void SceneManager_sceneLoaded (Scene scene, LoadSceneMode sceneMode)
	{
		SetMusic ();
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		SetMusic ();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}

	void SetMusic(){
		int levelIndex = SceneManager.GetActiveScene ().buildIndex;
		AudioClip thisLevelMusic = musicClipArray [levelIndex];
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.Play ();
			if (levelIndex != 0) {
				audioSource.loop = true;
			}
		}
	}

	public void SetVolume(float vol){
		audioSource.volume = vol;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
