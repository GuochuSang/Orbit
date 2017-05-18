using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : BasicUIMessage {

	public string sceneName;
	public override void CompleteDo ()
	{
		UIText.text=taskCompleteText;
		UIText.gameObject.SetActive (true);

		StartCoroutine (DelayToInvoke.DelayToInvokeDo (() => {
			SceneManager.LoadScene (sceneName);
		},completeExistTime));
	}
}
