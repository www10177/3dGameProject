﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float MouseXSensitivity = 10f; //垂直旋轉(上下轉頭、眼)的速度
	public float CameraYOffset = 2;	//Camera Y-Axis offset
	public float CameraDistance = 0.5f;	//繞LookAtHere半徑
	private Transform ToolMan;
	private Transform MainCamera;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
		ToolMan = GameObject.FindWithTag ("Player").transform;
		MainCamera = Camera.main.transform;
        //  offset = new Vector3(ToolMan.position.x, ToolMan.position.y + CameraYOffset, ToolMan.position.z + CameraDistance);
        offset = new Vector3(ToolMan.position.x, ToolMan.position.y+CameraYOffset,ToolMan.position.z+  CameraDistance);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * MouseXSensitivity, Vector3.up) * offset;
        MainCamera.position = ToolMan.position + offset;
        MainCamera.LookAt(ToolMan.Find("LookAtHere"));

    }
}
