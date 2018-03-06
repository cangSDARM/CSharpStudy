using UnityEngine;
using System.Collections;

public class RoundPlayerÐý×ª: MonoBehaviour{
	public float distance;
	//public float targetDistance;
	//public float distanceLerpSpeed;
	
	void Update(){	
		if (!inPool) {
			//distance = Mathf.Lerp(distance,targetDistance,Time.deltaTime * distanceLerpSpeed);
			transform.position = player.transform.position + RadianToVector3((player.angle + ammoAngle) * Mathf.Deg2Rad) * distance;
			transform.eulerAngles = new Vector3(0,0,player.angle + ammoAngle);
            Debug.Log(player.angle + ammoAngle);
		}
	}
	
	void RadianToVector3(float radian){
		return new Vector3(Mathf.sin(radian), Mathf.cos(radian));
	}
}