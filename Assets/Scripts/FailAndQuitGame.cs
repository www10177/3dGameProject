using UnityEngine;
using System.Collections;

//被撞到以後強迫結束遊戲
public class FailAndQuitGame : MonoBehaviour
{
	// public
	public int windowWidth = 400;
	public int windowHight = 150;
	int MaxQQCount=15;
	int NowQQCount=0;
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

	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Cars") {
			windowSwitch = 1;
			alpha = 0;
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
		GUI.Label (new Rect (100, 40, 300, 30), "Oh! GGWP! Now to quit game.");
		for (int i = 0; i < NowQQCount; i++) {
			GUI.Label (new Rect (30 + i * 20, 100, 20, 20), "QQ");
		}
		if (GUI.Button (new Rect (80, 70, 100, 20), "Quit")) {
			Application.Quit ();
			Time.timeScale = 1;
		}
		if (GUI.Button (new Rect (220, 70, 100, 20), "Restart")) {
			Application.LoadLevel ("MainScene");
			Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (220, 90, 100, 20), "help QQ")) {
			Time.timeScale = 1;
			if (NowQQCount < MaxQQCount) {
				NowQQCount++; 
			}
		}
		GUI.DragWindow (); 
	}

}