using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {
	public static int LastMission = 0;
	public static int MissionState = 0;
	public static int Level=1;
	public static bool TaskState=false;
	public static int MRate;//任務數量
	public static int MCase;//任務數量
	public static int Ncoutner;//任務計數器
	public static int Dcounter;//任務計數器

	int MissionCase;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("TaskAllocation", 5f, 5f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void TaskAllocation(){
		//print ("TaskAllocating...");
		if (ConditionController.Score < 100)
			Level = 1;
		else if (ConditionController.Score >= 100 /*&& ConditionController.Score < 500*/)
			Level = 2;
		//else if (ConditionController.Score >= 500 && ConditionController.Score < 1000)
			//Level = 3;
		//print ("Last Task:" + LastMission);
		//print(!TaskState+ " "+MissionState);
		if (!TaskState && MissionState == 0) {
			do {
				switch (Level) {
				case 1:
					MissionCase = Random.Range (2, 5);
					break;
				case 2:
					MissionCase = Random.Range (2, 9);
					break;
				case 3:
					MissionCase = Random.Range (2, 13);
					break;
				}
				//print ("Task"+MissionCase);
			} while(MissionCase == LastMission);

			MissionState = MissionCase;
			if (MissionState == 3||MissionState == 6) {
				MRate = 0;
				MCase = 10;
			}
			if (MissionState == 5||MissionState==8) {
				MRate = 0;
				MCase = 2;
			}
			if (MissionState == 7) {
				MRate = 0;
				MCase = 5;
				Ncoutner = 60;
				Dcounter = 60;
			}
		}
	}
}

/*1:拿手機
 *2:鹹酥雞攤
 *3:十個金幣
 *4:認識正妹
 *5:雞排
 *6:撞十路人
 *7:一分鐘五金幣
*/