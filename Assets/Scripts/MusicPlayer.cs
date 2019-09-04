using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	void Awake() {
		int numMusPlayers = FindObjectsOfType<MusicPlayer>().Length;
		if (numMusPlayers > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}
}