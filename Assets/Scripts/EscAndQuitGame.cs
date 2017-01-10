using UnityEngine;
using System.Collections;

//按esc可以選擇是否離開遊戲
//應該是因為在編輯者模式，所以按quit後沒辦法離開
//輸出成可執行檔之後應該就可以正常quit遊戲
//從網路上幹來的codeㄏㄏ
//大家可以再討論要不要用
public class EscAndQuitGame : MonoBehaviour
{
	// public
	public int windowWidth = 400;
	public int windowHight = 150;

	// private
	Rect windowRect ;
	int windowSwitch = 0;
	float alpha = 0;

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
		if (Input.GetKeyDown ("escape")) {
			//Time.timeScale = 0;
			windowSwitch = 1;
			alpha = 0; // Init Window Alpha Color
		}
	}

	void OnGUI ()
	{ 
		if (windowSwitch == 1) {
			GUIAlphaColor_0_To_1 ();
			windowRect = GUI.Window (0, windowRect, QuitWindow, "Quit Window");
		}
	}

	void QuitWindow (int windowID)
	{
        UnityEngine.Cursor.visible = true;
        GUI.Label (new Rect (100, 50, 300, 30), "Are you sure you want to quit game ?");

		if (GUI.Button (new Rect (80, 110, 100, 20), "Quit")) {
			Application.Quit ();
			//Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (220, 90, 100, 20), "Restart")) {
			Application.LoadLevel ("MainScene");
			//Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (220, 130, 100, 20), "Cancel")) {
			windowSwitch = 0; 
			//Time.timeScale = 1;
		} 

		GUI.DragWindow (); 
	}

}