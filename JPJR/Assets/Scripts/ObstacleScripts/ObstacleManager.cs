using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {
	
	public GameObject prefab;
	public int numberOfObjects;
	public float recycleOffset;
	ArrayList obstacles; 
	public Vector3 minSize, maxSize;
	
	private Vector3 obsPos;
	
	void Start () {
		obstacles = new ArrayList();	
		for(int ctr = 0; ctr <  numberOfObjects; ctr++){
			Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x) ,
			Random.Range(minSize.y, maxSize.y),
				PlayerMovement.minmaxZ);
			
			GameObject newObstacle = (GameObject)Instantiate(prefab,scale, transform.rotation);
			obstacles.Add(newObstacle.gameObject); 
		}
	}

	void Update () {
		
		foreach(GameObject obs in obstacles){
			obsPos.x = obs.transform.position.x;
			obsPos.y = obs.transform.position.y;
			obsPos.z = Mathf.Clamp(obs.transform.position.z, PlayerMovement.minmaxZ, PlayerMovement.minmaxZ);
			obs.transform.position = obsPos;
		}
		
		Recycle();
	}
	
	private void Recycle () {
		GameObject currentObs = (GameObject)obstacles[0];
		if((currentObs.transform.localPosition.x + 10) < PlayerMovement.distanceTraveled){
				GameObject obsRemove = currentObs;
				float newPositionX =  PlayerMovement.distanceTraveled + recycleOffset;
				obsPos.x = 	Random.Range(newPositionX, newPositionX + maxSize.x);
				obsPos.y =  Random.Range(minSize.y, maxSize.y);
				obsPos.z = 0.0f;
				obsRemove.transform.position = obsPos;
				obstacles.Remove(currentObs);
				obstacles.Add(obsRemove.gameObject);
				
		}
		
	}
}
