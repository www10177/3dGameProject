using UnityEngine;
using System.Collections;

//抵達終點以後玩一下><
public class CompleteAndQuitGame : MonoBehaviour
{
	// public
	public int windowWidth = 400;
	public int windowHight = 150;
	public Animator Anim;
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
	void OnTriggerEnter(Collider other) 
	{
		print ("trigger on "+other.gameObject.name);
		if (other.gameObject.name == "Goal") {	
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
		GUI.Label (new Rect (100, 50, 300, 30), "Congrats! You finish this game!");

		if (GUI.Button (new Rect (80, 90, 100, 20), "Quit")) {
			Application.Quit ();
		} 
		if (GUI.Button (new Rect (220, 90, 100, 20), "Dance")) {
			Anim.SetBool ("DanceFlag", true);
		} 
		if (GUI.Button (new Rect (220, 110, 100, 20), "Stop")) {
			Anim.SetBool ("DanceFlag", false);
		}
		GUI.DragWindow (); 
	}

}