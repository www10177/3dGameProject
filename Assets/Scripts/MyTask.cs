using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 任務class，用来被呼叫

public class MyTask
{
	//string TaskName;


	MyTaskManager.TaskState task;

	public delegate void FinishedHander(bool isFinished);
	public event FinishedHander Finished;

	public MyTask(IEnumerator c,bool autoStart = true)
	{
		//產生一個任務並自動開始執行
		task =  MyTaskManager.CreateTask(c);

		//將這個class中的TaskFinished加入到MyTaskManager中的TaskFinished，所以在myTaskManager中呼叫的時候，
		//會先呼叫myTaskManager的taskState中的，然後才呼叫這個class中的
		task.Finished += TaskFinished;

		if(autoStart)
		{
			//產生後開始執行
			task.Start();
		}

	}


	void TaskFinished(bool isFinished)
	{
		FinishedHander handler = Finished;
		if(handler!=null)
		{
			handler(isFinished);
		}
	}


	//任務有暫停、繼續、結束等function
	public void Pause()
	{
		task.Pause();
	}

	public void Resume()
	{
		task.Resume();
	}

	public void Finish()
	{
		task.Finish();
	}

}