using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 使用範例
public class UseTask : MonoBehaviour
{
	public static bool isTask2Finished = false;
	public static bool isTask2Start = false;
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
			isTask2Start = true;
			Debug.Log ("Finding SaltyCrispChickenStall");
			if (CheckTaskTwoFinished ()) 
			{
				Debug.Log ("Finished task 2");
				isTask2Finished = true;
				break;
			}
			yield return null;
		}

	}

	bool CheckTaskTwoFinished()
	{
		if(isTask2Finished)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
/*	IEnumerator TaskOne()
	{
		while(true)
		{
			Debug.Log("TaskOne running");
			if(CheckTaskOneFinished())
			{
				Debug.Log("TaskOne Finished");
				DealWithTaskOneFinished();
				break; //跳出後執行e.moveNext()，接著狀態變成finished
			}
			yield return null;
		}
	}

	/// 用来檢測任務是否完成
	bool CheckTaskOneFinished()
	{
		if(Time.time >3)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void DealWithTaskOneFinished()
	{
		///
	}
*/

	void Start()
	{
		MyTask task = new MyTask(TaskOne());
		MyTask task2;

		//用匿名的方式添加TaskOne finished後的處理
		task.Finished += delegate(bool value)
		{
			if(value)
			{
				task2 =  new MyTask (TaskTwo (), true);
			}
		};

	}

}