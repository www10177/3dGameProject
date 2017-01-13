using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class dd_menu : MonoBehaviour {
	public Dropdown Maindropdown;
	//public Text         text;
	public static string Inputname;
	public static bool Switch=false;
	public Text Title;
	public static bool []IsTitleAdded;
	void Start () {
		// Fill ports array with COM's Name available
		//clear/remove all option item
		Maindropdown.options.Clear ();
		//fill the dropdown menu OptionData with all COM's Name in ports[]
		Maindropdown.options.Add (new Dropdown.OptionData() {text="魯蛇"});
		Maindropdown.options.Add (new Dropdown.OptionData() {text="一般工具人"});
		//this swith from 1 to 0 is only to refresh the visual DdMenu
	}
	void Update () {
		if (Switch) {
			AddOption (Inputname);
		}

	}
	public void AddOption(string _name){
		Maindropdown.options.Add (new Dropdown.OptionData(){text=_name});
		Maindropdown.value = 1;
		Maindropdown.value = 0;
		Switch = false;
	}
	public void ChangeTitleText()	
	{
		Title.text = Maindropdown.options [Maindropdown.value].text;
	}
}

/*
 * 0:魯蛇
 * 1:一般工具人
 * 2:資深工具人
 * 3:你不帥，但你有錢
 * 4:工具人傳奇
 * 
 * 
 * 
 * 
 * */