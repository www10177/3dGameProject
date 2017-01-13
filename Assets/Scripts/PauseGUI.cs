using UnityEngine;
using System.Collections;

//按esc可以選擇是否離開遊戲
//應該是因為在編輯者模式，所以按quit後沒辦法離開
//輸出成可執行檔之後應該就可以正常quit遊戲
//從網路上幹來的codeㄏㄏ
//大家可以再討論要不要用
public class PauseGUI : MonoBehaviour
{
	// public
	public int windowWidth = 400;
	public int windowHight = 150;
	public static int windowSwitch = 0;
	public static float alpha = 0;
	// private
	Rect windowRect ;
	int MaxQQCount=15;
	int NowQQCount=0;


	void GUIAlphaColor_0_To_1 ()
	{
		if (alpha < 1) {
			alpha += Time.deltaTime;
			GUI.color = new Color (1, 1, 1, alpha);
		} 
	}

	// Init
	void Awake ()
	{
		windowRect = new Rect (
			(Screen.width - windowWidth) / 2,
			(Screen.height - windowHight) / 2,
			windowWidth,
			windowHight);
	}

	void Update ()
	{

	}

	void OnGUI ()
	{ 
		if (windowSwitch == 1) {
			GUIAlphaColor_0_To_1 ();
			windowRect = GUI.Window (0, windowRect, EscWindow, "Escape Window");
		}
		if (windowSwitch == 2) {
			GUIAlphaColor_0_To_1 ();
			windowRect = GUI.Window (0, windowRect, FailWindow, "Fail");
		}
	}

	void EscWindow (int windowID)
	{
        UnityEngine.Cursor.visible = true;
        GUI.Label (new Rect (100, 50, 300, 30), "Are you sure you want to quit game ?");

		if (GUI.Button (new Rect (80, 110, 100, 20), "Quit")) {
			Application.Quit ();
			//Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (220, 90, 100, 20), "Restart")) {
			ConditionController.Money = 0;
			windowSwitch = 0;
			UnityEngine.Cursor.visible = false;
			PhoneUIController.PhoneObtained = false;
			Application.LoadLevel ("MainScene");
			//Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (220, 130, 100, 20), "Cancel")) {
			UnityEngine.Cursor.visible = false;
			windowSwitch = 0; 
			//Time.timeScale = 1;
		} 

		GUI.DragWindow (); 
	}
	void FailWindow (int windowID)
	{
		UnityEngine.Cursor.visible = true;
		GUI.Label (new Rect (100, 40, 300, 30), "Oh! GGWP! Now to quit game.");
		for (int i = 0; i < NowQQCount; i++) {
			GUI.Label (new Rect (30 + i * 20, 100, 20, 20), "QQ");
		}
		if (GUI.Button (new Rect (80, 70, 100, 20), "Quit")) {
			Application.Quit ();
			//Time.timeScale = 1;
		}
		if (GUI.Button (new Rect (220, 70, 100, 20), "Restart")) {
			ConditionController.Money = 0;
			PhoneUIController.PhoneObtained = false;
			windowSwitch = 0;
			Application.LoadLevel ("MainScene");
			//Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (220, 90, 100, 20), "help QQ")) {
			//Time.timeScale = 1;
			if (NowQQCount < MaxQQCount) {
				NowQQCount++; 
			}
		}
		GUI.DragWindow (); 
	}
}