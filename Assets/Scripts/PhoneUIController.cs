using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneUIController : MonoBehaviour {
	public Canvas CanvasObject;
	public static bool PhoneObtained=false;
	Transform PanelUI;
	Text MoneyText;
	Text ScoreText;
	void Start () {
		CanvasObject.GetComponent<Canvas> ().enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.C)&& PhoneObtained == true) {
			if (CanvasObject.GetComponent<Canvas> ().enabled == true) {
				CanvasObject.GetComponent<Canvas> ().enabled = false;
			} else {
				CanvasObject.GetComponent<Canvas> ().enabled = true;
			}
		}

		//MoneyText.text = ConditionController.Money.ToString();
//x		ScoreText.text = ConditionController.Score.ToString();
	}
}
