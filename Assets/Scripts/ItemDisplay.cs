using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDisplay : MonoBehaviour {

	public Text[] text=new Text[5];
	int Index=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Index = 0;
		if(ConditionController.ItemCount[0]>0)
			text[Index++].text="我有 "+ ConditionController.ItemCount[0]+" 份香酥雞排嗚嗚";
		if(ConditionController.ItemCount[1]>0)
			text[Index++].text="我有 "+ ConditionController.ItemCount[1]+" 份薯條嗚嗚";
		if(ConditionController.ItemCount[2]>0)
			text[Index++].text="我有 "+ ConditionController.ItemCount[2]+" 份鹹酥雞嗚嗚";
		if(ConditionController.ItemCount[3]>0)
			text[Index++].text="我有 "+ ConditionController.ItemCount[3]+" 份甜不辣嗚嗚";
		while (Index < 5) {
			text [Index++].text = "";
		}
	}
}
