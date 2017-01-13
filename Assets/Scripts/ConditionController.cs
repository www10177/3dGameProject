using UnityEngine;
using System.Collections;
//using System.Collections.Generic;


public class ConditionController : MonoBehaviour {
	public static int Money = 0;
	public static int Score = 0;
	public static int[] ItemCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
			PauseGUI.alpha = 0;
			PauseGUI.windowSwitch = 2;
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
					PauseGUI.windowSwitch = 2;
				}
			}
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		print ("trigger on" + collider.name);
		if (collider.tag == "Coin") {
			if (TaskManager.MissionState == 3)
				TaskManager.MRate++;
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
		if (TaskManager.MRate==TaskManager.MCase && TaskManager.MissionState == 3) {
			Score += 30;
			TaskManager.LastMission = 3;
			TaskManager.TaskState = true;
		}
		if (collider.tag == "NPC" && TaskManager.MissionState == 4) {
			Score += 30;
			TaskManager.LastMission = 4;
			TaskManager.TaskState = true;
		}
	}
	void OnTriggerExit(Collider collider)
	{
	}
}
/*itemcount
 * 
 * 
 * 
 * 
 * 
 * */