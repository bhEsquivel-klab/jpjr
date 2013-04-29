using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	
	public GameObject GameScene;
	public GameObject GameOverMenu;
	
	public string sceneName;
	public float movementSpeed = 0.1f;
	public float jumpSpeed = 0.2f;
	public float jumpForce = 300.0f;
	bool moving;
	bool gameOver;
	
	public static float distanceTraveled;
	public static float minmaxZ;
	public static float currentHeight;
	
	public GameObject stars;
	ParticleSystem explosionParticle;
	
	private Vector3 playerPos;
	
	
	void Start () {
		minmaxZ = transform.position.z;
		GameObject starInstance = (GameObject)Instantiate(stars,this.transform.position ,this.transform.rotation);
		explosionParticle = starInstance.GetComponent<ParticleSystem>();
		explosionParticle.enableEmission = false;
	}
	
	void Update () {
		
		//run Mode
		if(!gameOver){
			this.rigidbody.velocity += transform.forward * 0.01f;
			this.rigidbody.freezeRotation = true;
		
		//Clamp position
	
	  	float targetClampZ =  Mathf.Clamp(transform.position.z, minmaxZ, minmaxZ);
		float targetClampY =  Mathf.Clamp(transform.position.y, -4.6f, 3.3f);
		playerPos.x =transform.position.x;
		playerPos.y = targetClampY;
		playerPos.z = targetClampZ;
        transform.position = playerPos;
		
		//update distancetraveled and height
		distanceTraveled = transform.localPosition.x;
		currentHeight = transform.localPosition.y;
		
		//
		playerPos.x = Mathf.Clamp(transform.rigidbody.velocity.x, 2, 4);
		playerPos.y =  transform.rigidbody.velocity.y;
		playerPos.z = transform.rigidbody.velocity.z;
		transform.rigidbody.velocity = playerPos;
		}else{
			this.gameObject.rigidbody.velocity = Vector3.zero;
			this.gameObject.rigidbody.angularVelocity = Vector3.zero;
		}
	}
	
	void OnCollisionEnter(Collision theCollision){
		theCollision.collider.material.dynamicFriction = 0;
		if(theCollision.gameObject.name == "ObstacleVert(Clone)"){
			explosionParticle.transform.position =this.transform.position;
			explosionParticle.enableEmission = true;
			Debug.Log("Hit Obstacles");
			gameOver = true;
			GameOver();
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
	
	void GameOver()
	{
		//GameScene.gameObject.SetActiveRecursively(false);
		//GameOverMenu.gameObject.SetActiveRecursively(true);
		AutoFade.LoadLevel(sceneName ,1,1,Color.white);
	}
	
	
}
