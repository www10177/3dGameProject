using UnityEngine;
using System.Collections;
//using System.Collections.Generic;


public class ConditionController : MonoBehaviour {
	public static int Money = 0;
	public static int Score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Coin") {
			Destroy (collider.gameObject);
			Money+=5;
			Score++;
		}
		if (collider.tag == "Cellphone") {
			Destroy (collider.gameObject);
			PhoneUIController.PhoneObtained = true;
		}
	}
}
