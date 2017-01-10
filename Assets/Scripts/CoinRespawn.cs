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
	}
	float Counter_f = 0;
	// Update is called once per frame
	void Update () {
		Counter_f += Time.deltaTime;
		Size= plane.transform.GetComponent<Renderer>().bounds.size;
		if (Counter_f > 120f) {
			x = Random.Range (-0.5f * Size.x, 0.5f * Size.x);
			y = 1f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);

			this.transform.position = new Vector3 (x + transform.position.x, y, z + transform.position.z);
		}
	}
	/*void OnCollisionStay(Collision other)
	{
		if (other.gameObject.layer == 8) {
			print ("Coin stay in "+other.gameObject.name);
			GetComponent<Collider> ().isTrigger = false;
			Destroy (GetComponent<Rigidbody>());
		}

	}
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.layer == 8) {
			print ("Coin Exit "+other.gameObject.name);
			GetComponent<Collider> ().isTrigger = true;
			Destroy (GetComponent<Rigidbody>());
		}
	}*/
	//void 
}
