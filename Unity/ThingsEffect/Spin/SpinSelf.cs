/*
	使物体绕自身中心点旋转
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float spinSpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Rotate函数(xAngle, yAngle, zAngle, Space relativeTo)，设定后以relativeTo为主坐标系在x,y,z按照对应指定的角速度旋转
		this.transform.Rotate( 0, spinSpeed, 0, Space.World);
	}
}
