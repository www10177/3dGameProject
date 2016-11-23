using UnityEngine;
using System.Collections;

public class RotateToolMan : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float SpeedHor = 1.0f; //水平旋轉(左右轉頭)的速度
		this.transform.Rotate (new Vector3(0,Input.GetAxis("Mouse X"),0)*SpeedHor,Space.Self);
	}
}
