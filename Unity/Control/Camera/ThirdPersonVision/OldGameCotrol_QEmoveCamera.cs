/*
	老式3D游戏操作，Q,E操作摄像头
*/

using System.Collections;
using UnityEngine;

public class OldGameCotrol_QEmoveCamera : MonoBehaviour {

	public float cameraMoveSpeed = 10f;
	public float cameraRotSpeed = 30f;
	bool isRotateCamera = false;

	//private float trans_Y = 0;
	//private float trans_X = 0;
	private float trans_Z = 0;


	private float eulerAngles_X;
	private float eulerAngles_Y;

	// Use this for initialization
	void Start () {
		Vector3 eulerAngles = this.transform.eulerAngles;		//当前物体的欧拉视角
		this.eulerAngles_X = eulerAngles_Y;
		this.eulerAngles_Y = eulerAngles_X;

	}

	void FixedUpdate() {
		if (Input.GetMouseButton (1)) {
			this.eulerAngles_X += (Input.GetAxis("Mouse X") * this.cameraRotSpeed) * Time.deltaTime;
			this.eulerAngles_Y += (Input.GetAxis ("Mouse Y") * this.cameraRotSpeed) * Time.deltaTime;
			Quaternion quaternion = Quaternion.Euler(this.eulerAngles_Y, this.eulerAngles_X, (float)0);
			this.transform.rotation = quaternion;
			moveCameraByKey(cameraMoveSpeed);
		}

		this.trans_Z = (Input.GetAxis("Mouse ScrollWheel") * this.cameraMoveSpeed * 2) * Time.deltaTime;
		this.transform.Translate(Vector3.forward * this.trans_Z);

		/*
		 * 	if (Input.GetMouseButton (2)) {
				this.trans_Y = (Input.GetAxis("Mouse Y") * this.ySpeed/2 ) * 0.02f;
				this.trans_X = (Input.GetAxis ("Mouse X") * this.xSpeed/2 ) * 0.02f;

				this.transform.Translate(-1 * Vector3.right * this.trans_X);
				this.transform.Translate(-1 * Vector3.up * this.trans_Y);
			}
		*/
	}

	void moveCameraByKey(float speed) {
		if (Input.GetKey (KeyCode.Q)) {
			this.transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.E)) {
			this.transform.Translate (Vector3.up * speed * Time.deltaTime);
		}

		float moveV = Input.GetAxis ("Vertical");
		float moveH = Input.GetAxis ("Horizontal");

		this.transform.Translate (Vector3.forward * speed * moveV * Time.deltaTime + Vector3.right * speed * moveH * Time.deltaTime);
	}
}
