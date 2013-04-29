using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public string sceneName;
	public float movementSpeed = 0.1f;
	public float jumpSpeed = 0.2f;
	public float jumpForce = 300.0f;
	bool moving;
	//bool onGround;
	
	public static float distanceTraveled;
	public static float minmaxZ;
	public static float currentHeight;
	
	void Start () {
		minmaxZ = transform.position.z;
	}
	
	void Update () {
		
		//run Mode
		this.rigidbody.velocity += transform.forward * 0.01f;
		this.rigidbody.freezeRotation = true;
		
		//Clamp position
	  	float targetClampZ =  Mathf.Clamp(transform.position.z, minmaxZ, minmaxZ);
		float targetClampY =  Mathf.Clamp(transform.position.y, -4.6f, 3.3f);
        transform.position = new Vector3(transform.position.x, targetClampY, targetClampZ);
		
		//update distancetraveled and height
		distanceTraveled = transform.localPosition.x;
		currentHeight = transform.localPosition.y;
		
		//
		transform.rigidbody.velocity = new Vector3(Mathf.Clamp(transform.rigidbody.velocity.x, 2, 4), transform.rigidbody.velocity.y, transform.rigidbody.velocity.z);
		
	}
	
	void OnCollisionEnter(Collision theCollision){
		theCollision.collider.material.dynamicFriction = 0;
		if(theCollision.gameObject.name == "ObstacleVert(Clone)"){
			AutoFade.LoadLevel(sceneName ,2,1,Color.gray);
			Debug.Log("Hit Obstacles");
		}	
		
	}
	void OnCollisionStay(Collision theCollision)
	{
		if(theCollision.gameObject.name == "Floor"){
			//onGround = true;
		}
		
	}
	void OnCollisionExit(Collision theCollision)
    {
       if(theCollision.gameObject.name == "Floor"){
			//onGround = false;
		}
		
    }
	
}
