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
	void Start () {
        PhoneUI.GetComponent<Canvas>().enabled = false;
        cellphoneInUI.SetActive(false);
    }

	void Update () {
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
