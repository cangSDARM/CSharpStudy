/*
	第三人称越肩视角
*/

using System.Collections;
using UnityEngine;

public class ShoulderPerspectiveController : MonoBehaviour {

	public Transform target;

	//相对于人物的位置属性
	public float distanceY = 2f;
	public float distanceX = 1f;

	//观察距离  
	public float distanceZ = 5f;

	//鼠标缩放速率  
	public float ZoomSpeed=2F;
	//鼠标缩放距离最值  
	private float MaxDistance=10;  
	private float MinDistance=1.5F; 

	//旋转速度
	public float rotateSpeedX = 240f;  
	public float rotateSpeedY = 120f;

	//角度限制  
	private float  MinLimitY = -180f;  
	private float  MaxLimitY = 180f;  

	//旋转角度  
	private float mX = 0.0f;  
	private float mY = 0.0f; 
	
	//存储角度的四元数  
	private Quaternion mRotation;

	//Use this for initialization
	void Start(){
		
		//初始化旋转角度  
		mX = this.transform.eulerAngles.x;  
		mY = this.transform.eulerAngles.y; 
	}

	//Update is called once per frame
	void Update(){
		
	}

	void LateUpdate(){
		//主角转动，摄像机跟随
		//Vector3 nextpos = target.forward * -1 * distanceY + target.up * distanceX + target.position;
		//this.transform.position = Vector3.Lerp(this.transform.position, nextpos, soothSpeed * Time.deltaTime);		//平滑差值

		//鼠标旋转  
		if(target!=null) {  
			//获取鼠标输入 
			mX += Input.GetAxis("Mouse X") * rotateSpeedX * 0.02F;  
			mY -= Input.GetAxis("Mouse Y") * rotateSpeedY * 0.02F;  
			//范围限制  
			mY = ClampAngle(mY,MinLimitY,MaxLimitY);  
			//计算旋转  
			mRotation = Quaternion.Euler(mY, mX, 0);

			this.transform.rotation = mRotation;  
		}


		//鼠标滚轮缩放  
		distanceZ -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;  
		distanceZ = Mathf.Clamp(distanceZ,MinDistance,MaxDistance);  


		//重新计算位置
		Vector3 mPosition = mRotation * new Vector3(distanceX, distanceY, -distanceZ) + target.position;

		this.transform.position = Vector3.Lerp( this.transform.position, mPosition, 10f);
	}

	//角度限制  
	private float  ClampAngle (float angle, float min, float max) {  
		if (angle < -360) angle += 360;  
		if (angle >  360) angle -= 360;
		return Mathf.Clamp (angle, min, max);  
	}  
}
