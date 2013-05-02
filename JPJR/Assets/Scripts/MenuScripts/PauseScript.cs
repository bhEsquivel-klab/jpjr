using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	
	public GameObject PauseLayer;
	public GameObject GameLayer;
	void OnClick()
	{
		if(this.gameObject.name == "PauseToggle"){
			PauseLayer.gameObject.SetActiveRecursively(true);
			iTween.MoveBy(GameObject.Find("PausePanel"), iTween.Hash("x", -1, "easeType", "easeOutBounce", "loopType", "none", "delay", 0.1f));
			GameLayer.gameObject.SetActiveRecursively(false);
		}else if(this.gameObject.name == "CloseButton"){
			iTween.MoveBy(GameObject.Find("PausePanel"), iTween.Hash("x", 1, "easeType", "easeOutBounce", "loopType", "none", "delay", 0.1f));
			StartCoroutine(waitASecond());
		}
	}
	
	private IEnumerator waitASecond()
	{
		yield return new WaitForSeconds(1);
		if(this.gameObject.name == "CloseButton"){
			PauseLayer.gameObject.SetActiveRecursively(false);
			GameLayer.gameObject.SetActiveRecursively(true);
		}
	}
}
