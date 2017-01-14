using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneUIController : MonoBehaviour {

	public Canvas PhoneUI; 
	public Canvas DefaultUI;
	public Canvas OuterUI;
    public GameObject cellphoneInUI;
	public static bool PhoneObtained=false;
	Transform PanelUI;
	public Text MoneyText;
	public Text ScoreText;
	public Text TaskText;
	public Text TaskCondition;
	public Canvas ItemUI;
	public Canvas TitleUI;
	float Counter_f=0f;
	int Counter_i=0;
	float MissionCounter_f=0f;
	int MissionCounter_i=0;
	void Start () {
        PhoneUI.GetComponent<Canvas>().enabled = false;
        cellphoneInUI.SetActive(false);
    }
	void Update () {
		if(OuterUI.GetComponent<Canvas>().enabled) UnityEngine.Cursor.visible=true;
		if (TaskManager.TaskState){
			TaskText.text = "任務完成！";
			TaskCondition.text = "";
			Counter_f += Time.deltaTime;
			Counter_i = (int)Counter_f;
			if (Counter_i > 3) {
				Counter_f = 0f;
				Counter_i = 0;
				MissionCounter_i = 0;
				MissionCounter_f = 0f;
				TaskManager.TaskState = false;
				TaskManager.MissionState = 0;
				TaskText.text="";
			}
		}else{
			if (TaskManager.MissionState == 2) {
				TaskText.text = "Task:\n到鹹酥雞攤跟老闆打招呼吧";
			} else if (TaskManager.MissionState == 3) {
				TaskText.text = "Task:\n撿起十個錢幣";
				TaskCondition.text = "進度 " + TaskManager.MRate + " / " + TaskManager.MCase;
			} else if (TaskManager.MissionState == 4) {
				TaskText.text = "Task:\n去跟漂亮妹子打招呼！";
				TaskCondition.text = "提示:\nNPC不會動";
			} else if (TaskManager.MissionState == 5) {
				TaskText.text = "L1NE:\n欸欸你幫我買一份鹹酥雞好不好，拜託你";
				TaskCondition.text = "進度 " + TaskManager.MRate + " / " + TaskManager.MCase; 
			} else if (TaskManager.MissionState == 6) {
				TaskText.text = "Task:\n跟路人來十次激烈碰撞";
				TaskCondition.text = "碰撞 " + TaskManager.MRate + " / " + TaskManager.MCase;
			} else if (TaskManager.MissionState == 7) {
				MissionCounter_f += Time.deltaTime;
				MissionCounter_i = (int)MissionCounter_f;
				TaskManager.Ncoutner = TaskManager.Dcounter - MissionCounter_i;
				if (TaskManager.Ncoutner != 0) {
					TaskText.text = "來挑戰個一分鐘撿五個金幣吧";
					TaskCondition.text = "進度 " + TaskManager.MRate + " / " + TaskManager.MCase +
					"\n時間 " + TaskManager.Ncoutner + " / " + TaskManager.Dcounter;
				} else {
					TaskText.text = "挑戰失敗";
					TaskCondition.text = "連自己的挑戰都達不到...";
					TaskManager.LastMission = 7;
					TaskManager.MissionState = 0;
				}
			} else if (TaskManager.MissionState == 8) {
				TaskText.text = "L1NE:\n欸你幫我買一份香酥雞排好不好，拜託~";
				TaskCondition.text = "進度 " + TaskManager.MRate + " / " + TaskManager.MCase; 
			}
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			ItemUI.GetComponent<Canvas> ().enabled = (OuterUI.GetComponent<Canvas> ().enabled)?false:true;
			OuterUI.GetComponent<Canvas> ().enabled = (OuterUI.GetComponent<Canvas> ().enabled)?false:true;

			if (OuterUI.GetComponent<Canvas> ().enabled == true)
				TitleUI.GetComponent<Canvas> ().enabled = false;
			UnityEngine.Cursor.visible = (ItemUI.GetComponent<Canvas> ().enabled) ? true : false;
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
