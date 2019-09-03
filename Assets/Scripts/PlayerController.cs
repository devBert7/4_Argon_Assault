using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	[Tooltip("In m/s^-1")][SerializeField] float speed = 10f;
	[Tooltip("In m")][SerializeField] float xRange = 5f;
	[Tooltip("In m")][SerializeField] float yRange = 3f;

	[SerializeField] float posPitchFactor = -5f;
	[SerializeField] float ctrlPitchFactor = -20f;

	[SerializeField] float posYawFactor = 6f;

	[SerializeField] float ctrlRollFactor = -30;

	float xThrow;
	float yThrow;
	bool isControlEnabled = true;

	// Update is called once per frame
	void Update() {
		if (isControlEnabled) {
			ProcessPosition();
			ProcessRotation();
		}
	}

	public void DisableControls() {
		isControlEnabled = false;
	}

	void ProcessPosition() {
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float xOffset = xThrow * speed * Time.deltaTime;
		float	rawXPos = transform.localPosition.x + xOffset;
		float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

		yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		float yOffset = yThrow * speed * Time.deltaTime;
		float	rawYPos = transform.localPosition.y + yOffset;
		float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}

	void ProcessRotation() {
		float pitchDueToPosition = transform.localPosition.y * posPitchFactor;
		float pitchDueToControlThrow = yThrow * ctrlPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToControlThrow;
				
		float yaw = transform.localPosition.x * posYawFactor;

		float roll = xThrow * ctrlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
}