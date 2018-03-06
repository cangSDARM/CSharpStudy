using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovewithMouse_2D: MonoBehaviour {
	private bool onClicked = false;
	private Vector3 lastMousePosition = Vector3.zero;

	void Update() {
		if (lastMousePosition != Vector3.zero && onClicked) {
			Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
			this.transform.position += offset;
		}
		lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	private void OnMouseDown() {
		onClicked = true;
	}

	private void OnMouseUp() {
		onClicked = false;
	}
}