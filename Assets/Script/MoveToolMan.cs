using UnityEngine;
using System.Collections;

public class MoveToolMan : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	//壓著按鍵可連續移動
	//移動速度未定 就先用1.0f吧/(>.O)/
	void Update () {
		//print (this.transform.rotation.eulerAngles);
		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate (new Vector3 (0,0,1.0f)*Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate (new Vector3(0,0,-1.0f)*Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.A)) {
			this.transform.Translate (new Vector3(-1.0f,0,0)*Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.D)) {
			this.transform.Translate (new Vector3 (1.0f,0,0)*Time.deltaTime, Space.Self);
		}
	}
}
