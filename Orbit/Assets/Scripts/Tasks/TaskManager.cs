using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using UnityEngine.Serialization;


[System.Serializable]
public class CustomArray
{
	public int[] connectedTask;
	public int this[int index]
	{
		get
		{
			return connectedTask[index];
		}
	}
	public CustomArray()
	{
		this.connectedTask= new int[4];
	}
	public CustomArray(int index)
	{
		this.connectedTask= new int[index];
	}
}
public class TaskManager : MonoBehaviour {
	public TaskBase[] taskList;
	[FormerlySerializedAs("task")]
	public CustomArray[] taskNode;
	// Use this for initialization
	public virtual void Start () {
		foreach (TaskBase aTask in taskList) {
			aTask.task += aTask.OnDone;
		}
			
	}
	
	// Update is called once per frame
	public virtual void Update () {
		TaskTree ();
	}
	public virtual void TaskTree()
	{
		if(taskList.Length!=0)
		OpenTask (0);
		for (int i = 0; i < taskList.Length-1; i++) {
			if (IsNextGoing (i)&&taskNode.Length!=0) {
				if(taskNode[i].connectedTask.Length!=0)
				for (int j = 0; j < taskNode [i].connectedTask.Length; j++) {
					OpenTask (taskNode[i].connectedTask[j]);
				}
			}
		}
	}
	public void OpenTask(int id)
	{
		if (taskList [id].taskstate == TaskBase.state.UnOpened && taskList [id].taskenabled == false) {
			taskList [id].taskenabled = true;
			//taskList [id].taskstate = TaskBase.state.OnGoing;
		}
	}
	public void CloseTask(int id)
	{
		if (taskList [id].taskstate == TaskBase.state.OnGoing && taskList [id].taskenabled == true) {
			taskList [id].taskenabled = false;
		}
	}
	public void ReSet(int id)
	{
		taskList [id].taskstate = TaskBase.state.UnOpened;
		taskList [id].taskenabled = false;
 
}
	public bool IsNextGoing(int id)
	{
		if (taskList [id].taskstate == TaskBase.state.Completed)
			return true;
		else
			return false;
	}
}
