using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneUIController : MonoBehaviour {
	public Canvas PhoneUI; 
	public Canvas DefaultUI;
    public GameObject cellphoneInUI;
	public static bool PhoneObtained=false;
	Transform PanelUI;
	public Text MoneyText;
	public Text ScoreText;
	public Text TaskText;
	float Counter_f=0f;
	int Counter_i=0;
	void Start () {
        PhoneUI.GetComponent<Canvas>().enabled = false;
        cellphoneInUI.SetActive(false);
    }

	void Update () {
		if (UseTask.MissionState == 2) {
			TaskText.text = "Task:\n找到鹹酥雞攤";
		} else if (UseTask.MissionState == 3) {
			TaskText.text = "Task:\n從地上撿到50元！";
		}
		if (UseTask.TaskState){
			TaskText.text = "任務完成！";
			Counter_f += Time.deltaTime;
			Counter_i = (int)Counter_f;
			if (Counter_i > 3) {
				Counter_f = 0f;
				Counter_i = 0;
				UseTask.TaskState = false;
				TaskText.text="";
			}
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
