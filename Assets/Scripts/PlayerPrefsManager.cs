using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string MASTER_DIFF_KEY = "master_diff";
	const string MASTER_LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume){
		if (volume >= 0 && volume <= 1) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if (level <= SceneManager.sceneCount - 1) {
			PlayerPrefs.SetInt (MASTER_LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError ("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(MASTER_LEVEL_KEY +level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= SceneManager.sceneCount - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to Query level not in build order");
			return false;
		}
	}

	public static void SetDifficulty (float diff){
		if (diff >= 1f && diff <= 3f) {
			PlayerPrefs.SetFloat (MASTER_DIFF_KEY, diff);
		} else {
			Debug.LogError ("Difficulty is out of range");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (MASTER_DIFF_KEY);
	}


}
