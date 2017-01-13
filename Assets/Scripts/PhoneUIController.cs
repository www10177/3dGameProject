using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneUIController : MonoBehaviour {
	public Canvas PhoneUI; 
	public Canvas DefaultUI;
	public Canvas ItemUI;
    public GameObject cellphoneInUI;
	public static bool PhoneObtained=false;
	Transform PanelUI;
	public Text MoneyText;
	public Text ScoreText;
	public Text TaskText;
	public Text TaskCondition;
	float Counter_f=0f;
	int Counter_i=0;
	void Start () {
        PhoneUI.GetComponent<Canvas>().enabled = false;
        cellphoneInUI.SetActive(false);
    }
	void Update () {
		if (TaskManager.MissionState == 2) {
			TaskText.text = "Task:\n到鹹酥雞攤跟老闆打招呼吧！";
		} else if (TaskManager.MissionState == 3) {
			TaskText.text = "Task:\n撿起十個錢幣！";
			TaskCondition.text = "進度 " + TaskManager.MRate + " / " + TaskManager.MCase;
		} else if (TaskManager.MissionState == 4) {
			TaskText.text = "Task:\n認識漂亮妹子！";
			TaskCondition.text ="提示:\nNPC不會動";
		} else if (TaskManager.MissionState == 5) {
			TaskText.text = "LIOE:\n欸欸你幫我買雞排好不好，拜託你><";
		} else if (TaskManager.MissionState == 6) {
			TaskText.text = "Task:\n跟路人來十次激烈碰撞";
			TaskCondition.text = "碰撞 " + TaskManager.MRate + " / " + TaskManager.MCase;
		} 
		if (TaskManager.TaskState){
			TaskText.text = "任務完成！";
			TaskCondition.text = "";
			Counter_f += Time.deltaTime;
			Counter_i = (int)Counter_f;
			if (Counter_i > 3) {
				Counter_f = 0f;
				Counter_i = 0;
				TaskManager.TaskState = false;
				TaskManager.MissionState = 0;
				TaskText.text="";
			}
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			UnityEngine.Cursor.visible = (UnityEngine.Cursor.visible) ? false : true;
			ItemUI.GetComponent<Canvas> ().enabled = (ItemUI.GetComponent<Canvas> ().enabled)?false:true;
		}
		if (Input.GetKeyDown (KeyCode.C)&& PhoneObtained == true) {
			if (PhoneUI.GetComponent<Canvas> ().enabled == true) {
                PhoneUI.GetComponent<Canvas>().enabled = false;
                cellphoneInUI.SetActive(false);
            } else {
                PhoneUI.GetComponent<Canvas>().enabled = true;
                cellphoneInUI.SetActive(true);
            }
			DefaultUI.GetComponent<Canvas> ().enabled = false;
		}

		MoneyText.text = "Money: "+ ConditionController.Money.ToString();
		ScoreText.text = "Score: "+ ConditionController.Score.ToString();
	}
}
