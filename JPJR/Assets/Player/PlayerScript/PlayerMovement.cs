using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 0.1f;
	public float jumpSpeed = 0.2f;
	public float jumpForce = 300.0f;
	bool moving;
	//bool onGround;
	
	public static float distanceTraveled;
	public static float minmaxZ;
	
	
	void Start () {
		minmaxZ = transform.position.z;
	}
	void Update () {
		this.rigidbody.velocity += transform.forward * 0.01f;
		this.rigidbody.freezeRotation = true;
		
		transform.position = new Vector3 (transform.position.x,  transform.position.y, Mathf.Clamp(transform.position.z, minmaxZ, minmaxZ));
		distanceTraveled = transform.localPosition.x;
		
		//transform.rigidbody.velocity = new Vector3(0,0,0);
		transform.rigidbody.velocity = new Vector3(Mathf.Clamp(transform.rigidbody.velocity.x, 2, 4), transform.rigidbody.velocity.y, transform.rigidbody.velocity.z);
		
		
	}
	
	void OnCollisionEnter(Collision theCollision){
		theCollision.collider.material.dynamicFriction = 0;
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
