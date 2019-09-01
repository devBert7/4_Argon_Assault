using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginLevel : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {
		Invoke("BeginGame", 2f);
	}

	void BeginGame() {
		SceneManager.LoadScene(1);
	}

	// Update is called once per frame
	void Update() {
		
	}
}