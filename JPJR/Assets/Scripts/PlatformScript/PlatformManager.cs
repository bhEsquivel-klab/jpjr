using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {
	
	public GameObject targ;
	ArrayList platforms; 
	public int numberOfWalls;
	private Vector3 platformPos;
	private PlayerMovement player;
	
	void Awake () {
		platforms = new ArrayList();
		
		float distanceOfWalls = 0.0f;
		for(int ctr = 0; ctr <  numberOfWalls; ctr++){
			platformPos.x = distanceOfWalls;
			platformPos.y = 0.0f;
			platformPos.z = 0.0f;
			GameObject newPlatform = (GameObject)Instantiate(targ,platformPos, targ.transform.rotation);
			platforms.Add(newPlatform.gameObject); 
			distanceOfWalls += 10.0f;
		}
		
	}
	
	void Start(){
		//Player object
		GameObject playerObj = GameObject.Find("Player");
		player = playerObj.GetComponent<PlayerMovement>();
	}
	
	void Update () {
			GameObject currentPlatform = (GameObject)platforms[0];
			if( (currentPlatform.transform.position.x + 10)  < player.distanceTraveled)
			{
				GameObject platformForRemoval = currentPlatform;
				GameObject lastPlatform = (GameObject)platforms[numberOfWalls-1];
				float newPositionX = lastPlatform.transform.position.x + 10.0f;
				platformPos.x = newPositionX;
				platformPos.y = 0.0f;
				platformPos.z = 0.0f;
				platformForRemoval.transform.position = platformPos;
				platforms.Remove(currentPlatform);
				platforms.Add(platformForRemoval.gameObject);
				
			}
		

	}
}
