using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	public Slider VolSlider, DifSlider;
	private MusicManager musicManager;
	private LevelManager levelManager;


	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		VolSlider.value = PlayerPrefsManager.GetMasterVolume ();
		DifSlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume (VolSlider.value);
	}

	public void SaveandExit(){
		PlayerPrefsManager.SetMasterVolume (VolSlider.value);
		PlayerPrefsManager.SetDifficulty (DifSlider.value);
		levelManager.LoadLevel ("01a Start");
	}

	public void setDefault(){
		VolSlider.value = 0.8f;
		DifSlider.value = 2f;
	}
}
