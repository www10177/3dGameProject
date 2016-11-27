using UnityEngine;
using System.Collections;

public class RotateToolMan : MonoBehaviour {
	public float SpeedHor = 1.0f; //水平旋轉(左右轉頭)的速度
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3(0,Input.GetAxis("Mouse X"),0)*SpeedHor,Space.Self);
		this.transform.GetChild (3).Rotate (new Vector3 (Input.GetAxis ("Mouse Y"), 0, 0) * SpeedHor, Space.Self);
	}
}
