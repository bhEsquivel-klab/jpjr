using UnityEngine;
using System.Collections;

public class PlayerManagerScript : MonoBehaviour {
	
	private GameObject playerObj;
	private PlayerMovement player;
	
	public string sceneName;
	// Use this for initialization
	void Start () {
		//Player object
		playerObj = GameObject.Find("Player");
		player = playerObj.GetComponent<PlayerMovement>();
	}
	
	void Update(){
		
		if(player.gameOver){
			if(playerObj){
				Destroy(player.gameObject);
				StartCoroutine(GameOver());
			}else{
				return;
			}
		}
	}
	
	private IEnumerator GameOver()
	{
		//GameScene.gameObject.SetActiveRecursively(false);
		//GameOverMenu.gameObject.SetActiveRecursively(true);
		//AutoFade.LoadLevel(sceneName ,1,1,Color.white);
		//sceneManager.ChangeScene(sceneName);
		yield return new WaitForSeconds(2);
		Application.LoadLevel(sceneName);
	}
}
