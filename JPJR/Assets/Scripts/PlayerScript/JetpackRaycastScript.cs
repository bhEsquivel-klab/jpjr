using UnityEngine;
using System.Collections;

public class JetpackRaycastScript : MonoBehaviour {
	
		private ObstacleManager obsMngr;
		public float RayCastHitDoor  = 5.0f;
 		Vector3 up;
    
	
	void Start(){
		//Player object
		GameObject obstObj = GameObject.Find("Obstacle Manager Vert");
		obsMngr = obstObj.GetComponent<ObstacleManager>();
		up = transform.TransformDirection(Vector3.up);
		
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			RaycastFire();
		} 
          
	}
	
	void RaycastFire(){
		 RaycastHit hit;
   	 	if(Physics.Raycast(transform.position, -up, out hit, 10))		       
		{
            Debug.DrawRay(this.transform.position,-up * 10 , Color.green);
            if(hit.collider.gameObject.name == "Floor"){
 				Debug.Log("floor");
            }else if(hit.collider.gameObject.name == "ObstacleVert(Clone)"){
				Debug.Log ("obstacle");
				obsMngr.Recycle();
			}else{
				Debug.Log("raycasting");
			}
			
 
        }
	}
	

}


