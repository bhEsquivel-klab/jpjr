using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {
	
	public GameObject targ;
	ArrayList platforms; 
	public int numberOfWalls;
	
	void Awake () {
		platforms = new ArrayList();
		
		float distanceOfWalls = 0.0f;
		for(int ctr = 0; ctr <  numberOfWalls; ctr++){
			GameObject newPlatform = (GameObject)Instantiate(targ,new Vector3(distanceOfWalls,0.0f, 0.0f), targ.transform.rotation);
			platforms.Add(newPlatform.gameObject); 
			distanceOfWalls += 10.0f;
		}
		
	}
	
	void Update () {
			GameObject currentPlatform = (GameObject)platforms[0];
			if( (currentPlatform.transform.position.x + 10)  < PlayerMovement.distanceTraveled)
			{
				GameObject platformForRemoval = currentPlatform;
				GameObject lastPlatform = (GameObject)platforms[numberOfWalls-1];
				float newPositionX = lastPlatform.transform.position.x + 10.0f;
				platformForRemoval.transform.position = new Vector3 (newPositionX, 0.0f, 0.0f);
				platforms.Remove(currentPlatform);
				platforms.Add(platformForRemoval.gameObject);
				
			}
		

	}
}
