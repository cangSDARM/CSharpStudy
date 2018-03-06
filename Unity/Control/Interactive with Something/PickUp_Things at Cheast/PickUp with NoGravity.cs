using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public Transform target;

	private float thisSize = 0f;

	private float betweenDistance = 0f;
	private float triggerDistance = 0.68f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		betweenDistance = Vector3.Distance( this.transform.position, target.transform.position);

		if (Input.GetKeyUp(KeyCode.F) && this.transform.parent == null && betweenDistance < triggerDistance) {

			thisSize = (this.GetComponent<MeshFilter> ().mesh.bounds.size.z * this.transform.localScale.z) / 2f + 0.3f;
			Vector3 thisPosition = new Vector3 (0f, 0f, thisSize);

			this.transform.parent = target.transform;
			this.transform.localPosition = thisPosition;
		}else if(this.transform.parent == target.transform && Input.GetKeyUp(KeyCode.F)) {
			this.transform.parent = null;
		}
	}
}
