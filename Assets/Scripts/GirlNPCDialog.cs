using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlNPCDialog : MonoBehaviour {
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
			if (TaskManager.MissionState == 4) {
				msg.text = "你好！你看起來就像是個好人，當我朋友吧><";
			} else if (TaskManager.MissionState == 5) {
				if (TaskManager.MRate == 0)
					msg.text = "怎麼了？快點去買鹹酥雞阿";
				else if (TaskManager.MRate == 1) {
					ConditionController.ItemCount [2]--;
					msg.text = "太好了！謝謝你你最棒了><我要去找男碰有惹哦\n掰掰~";
				}
			} else if (TaskManager.MissionState == 8) { 
				if (TaskManager.MRate == 0)
					msg.text = "怎麼了？快點去買香酥雞排阿";
				else if (TaskManager.MRate == 1) {
					ConditionController.ItemCount [0]--;
					msg.text = "太好了！謝謝你你最棒了，我待會跟男朋友有約哦\n掰掰~";
				}
			}else {
				msg.text = "不要靠近我！魯味都飄過來了><";
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag=="Player")
			msgUI.GetComponent<Canvas> ().enabled = false;
	}
}
