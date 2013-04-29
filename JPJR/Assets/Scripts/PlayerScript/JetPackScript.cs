using UnityEngine;
using System.Collections;

public class JetPackScript : MonoBehaviour {
	
	public AudioClip jumpSound;
	public float jumpForce = 300.0f;
	public float flyForce = 100.0f;
	public GameObject bullets;
	
	ParticleSystem bulletParticle;
	public float particleRotation;
	public float particlePosition;
	
	
	bool isOnTop;
	// Use this for initialization
	void Start () {
		Quaternion bulletRotation = Quaternion.Euler(new Vector3(particleRotation,0.0f,0.0f));
		Vector3 bulletPosition = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Clamp(this.transform.position.z,particlePosition,particlePosition));
		GameObject bulletInstance = (GameObject)Instantiate(bullets,bulletPosition ,bulletRotation);
		bulletParticle = bulletInstance.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerMovement.currentHeight > 3.0f){
			isOnTop = true;
		}else{
			isOnTop = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Space)){
			if(!isOnTop){
				FlyJetpack(jumpForce);
			}
		}	
		if(Input.GetKey(KeyCode.Space)){
			if(!isOnTop){
				FlyJetpack(flyForce);
			}
			bulletParticle.transform.position =this.transform.position;
			bulletParticle.enableEmission = true;
			
			//play sound
			
			AudioSource.PlayClipAtPoint(jumpSound, this.transform.position);
		}
		
		
	}
	
	
	void FlyJetpack(float a)
	{
		this.transform.rigidbody.AddForce(transform.up * a);
	}
	
}

