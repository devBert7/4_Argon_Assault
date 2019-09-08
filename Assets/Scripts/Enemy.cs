﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;
	[SerializeField] int hits = 3;

	ScoreBoard scoreBoard;

	// Start is called before the first frame update
	void Start() {
		AddBoxCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}

	void AddBoxCollider() {
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	void OnParticleCollision(GameObject other) {
		ProcessHit();
		if (hits <= 0) {
			KillEnemy();
		}
	}

	void ProcessHit() {
		scoreBoard.ScoreHit(scorePerHit);
		hits--;
	}

	void KillEnemy() {
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}
}