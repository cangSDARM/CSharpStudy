using UnityEngine;
using UnityEngine.UI;

/*
	time-style like : 00:00
	 */

public class TimeStyle : MonoBehaviour {

	float time, startTime;
	Text timer;

	void Start () {
		timer = GameObject.Find("Canvas/Timer").GetComponent<Text>();

		startTime = Time.time;
	}

	void Update () {

		time = Time.time - startTime;

		var seconds = (int)(time % 60);
		var minutes = (int)(time / 60);

		var strTime = string.Format("{0:00}:{1:00}", minutes, seconds);
		timer.text = strTime;

	}
}
