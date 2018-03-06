using UnityEngine;
using System.Collections;

//指北针效果
public class PlanetCompass : MonoBehaviour{
	public Transform player;
	public Transform planet;
	public float rotateSpeed = 1000f;

	Vector3 playerUp;
	Vector3 planetUp;
	
	void Awake(){
		playerUp = player.up;
		playerUp = planet.up;
	}
	
	void Update(){
		playerUp = player.up;
		
		//Vector3.Cross叉积，normalized单位化
		Vector3 crossValue = Vector3.Cross(planetUp, playerUp).normalized;
		
		//最终效果
		Vector3 northDirect = Vector3.Cross(playerUp, crossValue).normalized;
		
		//指南针的旋转效果
		Quaternion target = Quaternion.LookRotation(northDirect, playerUp);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotateSpeed * Time.deltaTime);
		
		Debug.DrawLine(transform.position, transform.position + transform.up*100, Color.black);
		Debug.DrawLine(transform.position, transform.position + planet.up*100, Color.green);
		Debug.DrawLine(transform.position, transform.position + crossValue*100, Color.magenta);
		Debug.DrawLine(transform.position, transform.position + northDirect*100, Color.red);
	}
}