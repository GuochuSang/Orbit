using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.NetworkInformation;

public abstract class TaskBase : MonoBehaviour {
	public bool taskenabled=false;
	public string taskName;
	public enum state
	{
		Completed=0,
		Failed=1,
		OnGoing=2,
		UnOpened=3,
	}
	public state taskstate;
	[Multiline]
	public string taskDescription;
	public delegate void Task();
	public event Task task;
	public virtual void Start()
	{
		//Initialize Here
	}
	public virtual void Update(){
		if (CompleteCheck ()==state.Failed||CompleteCheck ()==state.Completed) {
			if (task != null) {
				task ();
			}
		}	
	}
	public  virtual state CompleteCheck()
	{
		if (taskenabled) {
			if (Completed ())//complete check
				return state.Completed;
			else if (Failed ())//fail check
				return state.Failed;
			else
				return state.OnGoing;
		} else
			return state.UnOpened;
	}
	public virtual void OnDone()
	{
		if (CompleteCheck () == state.Completed) {
			CompleteDo ();
		}
		else if (CompleteCheck () == state.Failed) {
			FailDo ();
		}
		task -= OnDone;
		taskenabled = false;
		taskstate = state.Completed;
	}
	public virtual  bool Completed()
	{
		return true;
	}
	public virtual  bool Failed()
	{
		return false;
	}
	public virtual void CompleteDo()
	{
		
	}
	public virtual void FailDo()
	{

	}
}
