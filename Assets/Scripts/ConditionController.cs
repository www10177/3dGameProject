using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System.Collections.Generic;


public class ConditionController : MonoBehaviour {
	public static int Money = 0;
	public static int Score = 0;
	public GameObject buyMsgWindow;//when on click (buying)
	public static int[] ItemCount = new int [4];
	public MonoBehaviour[] scripts = new MonoBehaviour[2];
	/*
 * 0:香酥雞排
 * 1:薯條
 * 2:鹹酥雞
 * 3:甜不辣
 * 
 * */



	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		if (ItemCount [2] > 0 && TaskManager.MissionState==5) {
			TaskManager.MRate = 1;
		}
		if (ItemCount [0] > 0 && TaskManager.MissionState == 8) {
			TaskManager.MRate = 1;
		}
		if (Input.GetKeyDown ("escape")) {
			//Time.timeScale = 0;
			PauseGUI.windowSwitch = 1;
			PauseGUI.alpha = 0; // Init Window Alpha Color
		}
	}
	void OnCollisionEnter(Collision other)
	{
		print ("Collision on " + other.gameObject.name);
		if (other.gameObject.tag == "Cars") {
			foreach(MonoBehaviour scripts in scripts){
				scripts.enabled = false;
			}
			PauseGUI.windowSwitch = 2;
			PauseGUI.alpha = 0;
			GetComponent<AudioSource>().Play();
			Vector3 pos = other.gameObject.transform.position;
			Vector3 force = 10*(pos - transform.position + new Vector3(0,100,0)) ;
			transform.Translate (new Vector3 (0, 3.4f, 0));
			GetComponent<Rigidbody> ().AddForce ( force);
		}
		if(other.gameObject.layer==12)
		{
			if (TaskManager.MissionState == 6) {
				TaskManager.MRate++;
				if (TaskManager.MRate == TaskManager.MCase) {
					Score += 20;
					TaskManager.LastMission = 4;
					TaskManager.TaskState = true;
					TaskManager.MCase = 0;
					TaskManager.MRate = 0;
				}
			} else {
				Score = Mathf.Max (Score - 5, 0);
				Money -= 20;
				if (Money < 0) {
					foreach(MonoBehaviour scripts in scripts){
						scripts.enabled = false;
					}
					PauseGUI.windowSwitch = 2;
					PauseGUI.alpha = 0;
				}
			}
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		print ("trigger on" + collider.name);
		if (collider.tag == "Coin") {
			if (TaskManager.MissionState == 7) {
				TaskManager.MRate++;
				if (TaskManager.MRate == TaskManager.MCase) {
					dd_menu.Switch = 5;
					Score += 100;
					TaskManager.LastMission = 7;
					TaskManager.TaskState = true;
				}
			} else if (TaskManager.MissionState == 3) {
				TaskManager.MRate++;
				if (TaskManager.MRate == TaskManager.MCase) {
					Score += 30;
					TaskManager.LastMission = 3;
					TaskManager.TaskState = true;
				}
			}
			MapObjectSpawner.CoinCount -= 1;
			Destroy (collider.gameObject);
			Money+=5;
			Score++;
		}
		if (collider.tag == "Cellphone") {
			Destroy (collider.gameObject);
			PhoneUIController.PhoneObtained = true;
		}
		if (collider.name == "TaskTwoStall" && TaskManager.MissionState == 2) {
			Score += 20;
			TaskManager.LastMission = 2;
			TaskManager.TaskState = true;
		}

		if (collider.name=="GirlCollider" && TaskManager.MissionState == 4) {
			Score += 30;
			TaskManager.LastMission = 4;
			dd_menu.Switch = 1;
			TaskManager.TaskState = true;
		}
		if (collider.name == "GirlCollider" && TaskManager.MissionState == 5 && TaskManager.MRate == 1) {
			Score += 120;
			TaskManager.LastMission = 5;
			dd_menu.Switch = 2;
			TaskManager.TaskState = true;
		}
		if (collider.name == "GirlCollider" && TaskManager.MissionState == 8 && TaskManager.MRate == 1) {
			Score += 120;
			TaskManager.LastMission = 5;
			TaskManager.TaskState = true;
		}
	}
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.name == "Plane") {
			PauseGUI.windowSwitch = 2;
			PauseGUI.alpha = 0;
		}
	}


}
