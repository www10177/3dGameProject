using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 使用範例
public class UseTask : MonoBehaviour
{
	//public static bool isTask2Finished = false;
	//public static bool isTask2Start = false;
	public static int MissionState = 0;
	public static bool TaskState=false;
	IEnumerator TaskOne()
	{

		while (true) 
		{
			/*TaskOne要執行的內容*/
			Debug.Log ("Finding phone");
			if (CheckTaskOneFinished ()) 
			{
				Debug.Log ("TaskOne Finished");
				break;
			}
			yield return null;
		}

	}

	bool CheckTaskOneFinished()
	{
		if (PhoneUIController.PhoneObtained) {
			if (Input.GetKeyDown (KeyCode.C)) {
				//TaskState = true;
				return true;
			} else {
				return false;
			}
		} else
			return false;
	}

	IEnumerator TaskTwo()
	{

		while (true)
		{
			/*TaskTwo要執行的內容*/
			MissionState = 2;
			//PhoneUIController.TaskText.text = "Finding Fried Chicken Stall";
			Debug.Log ("Finding SaltyCrispChickenStall");
			if (CheckTaskTwoFinished ()) 
			{
				Debug.Log ("Finished task 2");
				TaskState= false;	//false:直接接task3 //true:顯示任務完成，但沒有task3觸發
				MissionState = 0;
				break;
			}
			yield return null;
		}

	}

	bool CheckTaskTwoFinished()
	{
		if(TaskState)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator TaskThree()
	{

		while (true)
		{
			/*TaskThree要執行的內容:獲得20塊*/
			MissionState = 3;
			Debug.Log ("start task3");
			//PhoneUIController.TaskText.text = "Finding Fried Chicken Stall";
			if (CheckTaskThreeFinished ()) 
			{
				TaskState= true;
				MissionState = 0;
				break;
			}
			yield return null;
		}

	}

	bool CheckTaskThreeFinished()
	{
		if(TaskState)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	/*MyTask task;
	MyTask NewTask;
	int MissionCase=0;*/
	void Start()
	{
		//task = new MyTask(TaskOne());
		InvokeRepeating("LaunchTask", 1.0f,1.0f);
		MyTask task = new MyTask(TaskOne());
		MyTask task2;
		MyTask task3;
		//用匿名的方式添加TaskOne finished後的處理
		task.Finished += delegate(bool value) {
			if (value && !TaskState) {
				//MissionCase=Random.Range(2,4);
				//print(MissionCase); 
				task2 = new MyTask (TaskTwo (), true);
				task2.Finished += delegate(bool value2) {
					if (value2 && !TaskState) {
						task3 = new MyTask (TaskThree(), true);
						task3.Finished += delegate(bool value3) {
							if (value3 && !TaskState) {
								Debug.Log ("all finished");
							}
						};
					}
				};
			}
		};
	}
	/*void LaunchTask(){
		print ("HI");
		task.Finished += delegate(bool value) {
			print("HIEEE");
			if (value && !TaskState) {
				MissionCase = Random.Range (2, 4);
				print (MissionCase);
				switch (MissionCase) {
				case 2: 
					NewTask = new MyTask (TaskTwo (), true);
					break;
				case 3:
					NewTask = new MyTask (TaskThree (), true);
					break;
				}
			}
		};
	}*/
}