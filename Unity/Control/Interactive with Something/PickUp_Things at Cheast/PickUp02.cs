/*
	˼·���Ȱ������ŵ�����Ȼ�����ã�����Ҵ��������ϵ�����ɾ������ʵ�壬Ȼ���������е������������ø����ӡ�
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp02 : MonoBehaviour {

	// Use this for initialization
	private GameObject sw;
	private Vector3 shouxin;
	void Start () {
	sw = GameObject.Find("sw");
	sw.SetActive(false);

	}

	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerEnter(Collider other){
		if (other == true) {
		Destroy(this.gameObject);
		Destroy(GameObject.Find("sword"));
		sw.SetActive(true);
		}
	}
}