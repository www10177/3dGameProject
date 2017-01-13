using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRespawn : MonoBehaviour {//純測試，希望拿來開發讓金幣自動離開生成物的腳本
	GameObject plane;
	Vector3 Size; 
	float x,y,z;
	// Use this for initialization
	void Start () {
		plane = GameObject.Find ("Plane");
		Size = plane.transform.GetComponent<Renderer> ().bounds.size;
	}
	float Counter_f = 0;
	// Update is called once per frame
	void Update () {
		Counter_f += Time.deltaTime;
		if (Counter_f > 120f) {
			x = Random.Range (-0.5f * Size.x, 0.5f * Size.x);
			y = 1f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);
			this.transform.position = new Vector3 (x + plane.transform.position.x, y, z + plane.transform.position.z);
			Counter_f = 0f;
		}
	}

}
