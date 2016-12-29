using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 提供给MyTask class的辅助
public class MyTaskManager : MonoBehaviour 
{

	//单例
	static MyTaskManager singleton;
	public static TaskState CreateTask(IEnumerator c)
	{
		//要創造對象，那么創造完後就要return，所以必須有個用來return的class
		if(singleton == null)
		{
			GameObject go = new GameObject("MyTaskManager");
			singleton = go.AddComponent<MyTaskManager>();
		}
		return new TaskState(c);
	}




	public class TaskState
	{
		IEnumerator coroutine; //用来保存傳遞過來的函式
		public enum State
		{
			Running,//正在運行
			Paused, //暫停
			Stopped,//停止/放棄
			Finished,//完成
		}

		public State state;

		public delegate void FinishedHander(bool isFinished);
		public event FinishedHander Finished;

		public TaskState(IEnumerator c)
		{
			coroutine = c;
			state = State.Running;
		}


		public void Start()
		{
			//改變任務狀態，並且開啟一個listening coroutine
			state = State.Running;
			singleton.StartCoroutine(TaskStateMonitor());
		}

		//與task中的函式相對應
		public void Pause()
		{
			state = State.Paused;
		}
		public void Resume()
		{
			if (state == State.Paused)
			{
				state = State.Running;
			}
		}
		public void Finish()
		{
			state = State.Finished;
		}

		//主要是用来判斷是否完成任務
		IEnumerator TaskStateMonitor()
		{
			yield return null;
			IEnumerator e = coroutine;
			while(state == State.Running)
			{
				if (state == State.Paused)
					yield return null;
				else
				{
					//IEnumerator 有current ，movenext，reset
					//不停地執行new出来的任務，因为new出来的任務是Enumrator，直到不能movenext了
					if(e !=null && e.MoveNext())
					{
						yield return e.Current;
					}
					else
					{
						state = State.Finished;
					}
				}
			}
			FinishedHander handler = Finished;
			if (handler != null)
				handler(true); //true

		}

	}
}