/*
	思路：先把武器放到手上然后不启用，当玩家触碰到地上的武器删除地上实体，然后启用手中的武器。连接用刚连接。
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