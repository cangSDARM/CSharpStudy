/*
	ʹ�������������ĵ���ת
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
		//Rotate����(xAngle, yAngle, zAngle, Space relativeTo)���趨����relativeToΪ������ϵ��x,y,z���ն�Ӧָ���Ľ��ٶ���ת
		this.transform.Rotate( 0, spinSpeed, 0, Space.World);
	}
}
