using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject startMenu;
	public GameObject optionMenu;
	public GameObject mainMenu;
	//public string text;
	
	void OnClick()
	{
		if(this.gameObject.name == "Start Game"){
			startMenu.gameObject.SetActiveRecursively(true);
			mainMenu.gameObject.SetActiveRecursively(false);
			Debug.Log("objectName: "+this.gameObject.name);
		}else if(this.gameObject.name == "Option"){
			Debug.Log("objectName: "+this.gameObject.name);
		}else if(this.gameObject.name == "BackButton"){
			startMenu.gameObject.SetActiveRecursively(false);
			mainMenu.gameObject.SetActiveRecursively(true);
			Debug.Log("objectName: "+this.gameObject.name);
		}
	}
	
}
