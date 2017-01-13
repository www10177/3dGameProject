using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClerkNPCDialog : MonoBehaviour {
	public Canvas msgUI;
	public Text msg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			msgUI.GetComponent<Canvas> ().enabled = true;
			if (TaskManager.MissionState == 2) {
				msg.text = "年輕人歹謝捏，現在沒賣喔，你待會再來。";
			}
			if (TaskManager.MissionState == 5) {
				
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag=="Player")
			msgUI.GetComponent<Canvas> ().enabled = false;
	}
}
