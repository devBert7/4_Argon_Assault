using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
	[Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 2f;
	[Tooltip("FX Prefab On Player Ship")][SerializeField] GameObject deathFX;
	[SerializeField] int hits = 3;

	void OnTriggerEnter(Collider other) {
		hits--;
		if (hits <= 0) {
			StartDeathSequence();
			deathFX.SetActive(true);
			Invoke("ReloadScene", levelLoadDelay);
		}
	}

	private void StartDeathSequence() {
		SendMessage("DisableControls");
	}

	private void ReloadScene() {
		SceneManager.LoadScene(1);
	}
}