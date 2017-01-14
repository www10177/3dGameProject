using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClerkNPCDialog : MonoBehaviour {
	public Canvas msgUI;
	public GameObject MenuPanel;
	//public GameObject buyMsgWindow;
	public Text buyMsgText;
	public Button[] item = new Button[4];
	int[] ItemPrice = new int[4] ;
	// Use this for initialization
	void Start () {
		ItemPrice [0] = 65;
		ItemPrice [1] = 30;
		ItemPrice [2] = 50;
		ItemPrice [3] = 30;
		item [0].onClick.AddListener (ItemOnClick0);
		item [1].onClick.AddListener (ItemOnClick1);
		item [2].onClick.AddListener (ItemOnClick2);
		item [3].onClick.AddListener (ItemOnClick3);
	}
	
	// Update is called once per frame
	void Update () {
		if(msgUI.GetComponent<Canvas> ().enabled) UnityEngine.Cursor.visible= true ;
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			UnityEngine.Cursor.visible = true;
			msgUI.GetComponent<Canvas> ().enabled = true;
			if (TaskManager.MissionState == 2) {
				MenuPanel.SetActive (false);
				buyMsgText.text = "年輕人歹謝捏，現在沒賣喔，你待會再來。";
			} else {
				MenuPanel.SetActive (true);
				buyMsgText.text = "想買什麼？";
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			UnityEngine.Cursor.visible = false;
			msgUI.GetComponent<Canvas> ().enabled = false;
		}
	}

	void ItemOnClick0(){
		if (ConditionController.Money >= ItemPrice[0]) {
			ConditionController.Money -= ItemPrice[0];
			Debug.Log ("money:" + ConditionController.Money);
			buyMsgText.text = "買了一份香酥雞排。";
			ConditionController.ItemCount [0]++;
		} else {
			Debug.Log ("not enough");
			buyMsgText.text="沒錢別鬧啦！";
		}
	}
	void ItemOnClick1(){
		if (ConditionController.Money >= ItemPrice[1]) {
			ConditionController.Money -= ItemPrice[1];
			Debug.Log ("money:" + ConditionController.Money);
			buyMsgText.text ="買了一份薯條。";
			ConditionController.ItemCount [1]++;
		} else {
			Debug.Log ("not enough");
			buyMsgText.text = "沒錢別鬧啦！";
		}


	}
	void ItemOnClick2(){
		if (ConditionController.Money >= ItemPrice[2]) {
			ConditionController.Money -= ItemPrice[2];
			Debug.Log ("money:" + ConditionController.Money);
			buyMsgText.text = "買了一份鹹酥雞。";
			ConditionController.ItemCount [2]++;
		} else {
			Debug.Log ("not enough");
			buyMsgText.text = "沒錢別鬧啦！";

		}
	}
	void ItemOnClick3(){
		if (ConditionController.Money >= ItemPrice[3]) {
			ConditionController.Money -= ItemPrice[3];
			Debug.Log ("money:" +ConditionController.Money);
			buyMsgText.text = "買了一份甜不辣。";
			ConditionController.ItemCount [3]++;
		} else {
			Debug.Log ("not enough");
			buyMsgText.text = "沒錢別鬧啦！";
		}
			
	}
}


/*
 * 0:香酥雞排
 * 1:薯條
 * 2:鹹酥雞
 * 3:甜不辣
 * 
 * */