using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisionTest : MonoBehaviour {//純測試，希望拿來開發讓金幣自動離開生成物的腳本

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionStay(Collision other)
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
	}
	//void 
}
