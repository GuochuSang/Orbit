using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUIMessage : TaskBase {
	[Multiline]
	public string taskCompleteText;
	public Text UIText;
	public float beforePlayedDelay;
	public float beforePlayedExist;
	public float completeExistTime;
	public float taskDelay;
	public bool delayReturn= false;
	public bool beforePlayed;

	public override void Update ()
	{
		base.Update ();
		if (CompleteCheck () == state.OnGoing && enabled && !beforePlayed)
			BeforePlay ();
	}
	public override bool Completed ()
	{
			StartCoroutine (DelayToInvoke.DelayToInvokeDo (() => {
				delayReturn = true;
			}, taskDelay + beforePlayedDelay + beforePlayedExist));
			if (delayReturn)
				return true;
			else
				return false;
	}
	public override void CompleteDo ()
	{
			UIText.text = taskCompleteText;
			UIText.gameObject.SetActive (true);

			StartCoroutine (DelayToInvoke.DelayToInvokeDo (() => {
				UIText.text = "";
				UIText.gameObject.SetActive (false);
			}, completeExistTime));
			base.CompleteDo ();
	}
	public virtual void BeforePlay()
	{
			if (!beforePlayed) {
				StartCoroutine (DelayToInvoke.DelayToInvokeDo (() => {
					UIText.gameObject.SetActive (true);
					UIText.text = UIText.text = taskName + "\n" + taskDescription;
				}, beforePlayedDelay));
				StartCoroutine (DelayToInvoke.DelayToInvokeDo (() => {
					UIText.text = "";
					UIText.gameObject.SetActive (false);
					taskstate = state.OnGoing;
				}, beforePlayedDelay + beforePlayedExist));
				beforePlayed = true;
			}
	}
}
