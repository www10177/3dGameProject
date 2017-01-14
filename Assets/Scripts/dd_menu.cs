using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class dd_menu : MonoBehaviour {
	public Dropdown Maindropdown;
	//public Text         text;
	public static string Inputname;
	public static int Switch=0;
	public Text Title;
	public static bool []IsTitleAdded;
	void Start () {
		IsTitleAdded = new bool[6];
		// Fill ports array with COM's Name available
		//clear/remove all option item
		Maindropdown.options.Clear ();

		//fill the dropdown menu OptionData with all COM's Name in ports[]
		IsTitleAdded[0]=true;
		AddOption ("   ");
		AddOption ("魯蛇");
		//this swith from 1 to 0 is only to refresh the visual DdMenu
	}
	void Update () {
		if (ConditionController.Money >= 1000)
			Switch = 3;
		if (ConditionController.Score >= 1000)
			Switch = 4;
		if (Switch!=0) {
			if (IsTitleAdded [Switch] == false) {
				switch (Switch) {
				case 1:
					AddOption ("一般工具人");
					IsTitleAdded [1] = true;
					break;
				case 2:
					AddOption ("資深工具人");
					IsTitleAdded [2] = true;
					break;
				case 3:
					AddOption ("你不帥，但你有錢");
					IsTitleAdded [3] = true;
					break;
				case 4:
					AddOption ("工具人傳奇");
					IsTitleAdded [4] = true;
					break;
				case 5:
					AddOption ("玩命撿錢");
					IsTitleAdded [5] = true;
					break;
				}
			} else
				Switch = 0;
		}

	}
	public void AddOption(string _name){
		Maindropdown.options.Add (new Dropdown.OptionData(){text=_name});
		Maindropdown.value = 1;
		Maindropdown.value = 0;
		Switch = 0;
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
 * 5:玩命撿錢
 * 
 * 
 * 
 * */