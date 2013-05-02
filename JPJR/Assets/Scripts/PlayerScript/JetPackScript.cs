using UnityEngine;
using System.Collections;

public class JetPackScript : MonoBehaviour {
	
	public AudioClip jumpSound;
	public float flyForce = 5.0f;
	public GameObject bullets;
	
	ParticleSystem bulletParticle;
	public float particleRotation;
	public float particlePosition;
	
	private PlayerMovement player;
	
	bool isOnTop;
	
	// Use this for initialization
	void Start () {
		//Player object
		GameObject playerObj = GameObject.Find("Player");
		player = playerObj.GetComponent<PlayerMovement>();
		
		Quaternion bulletRotation = Quaternion.Euler(new Vector3(particleRotation,0.0f,0.0f));
		Vector3 bulletPosition = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Clamp(this.transform.position.z,particlePosition,particlePosition));
		GameObject bulletInstance = (GameObject)Instantiate(bullets,bulletPosition ,bulletRotation);
		bulletParticle = bulletInstance.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		ApplyJump(flyForce);
	}
	
	
	void FlyJetpack(float force)
	{
		//player.transform.Translate(Vector3.up * Time.deltaTime* 20.0f, Space.World);
		//this.transform.Translate(Vector3.up * Time.deltaTime*20.0f);
		this.transform.rigidbody.AddForce(Vector3.up * force);
	}
	
	private void ApplyJump(float force){
		if(Input.GetKey(KeyCode.Space))
        {
			FlyJetpack(force);
			JumpAnimation();
        }
	}
	
	private void JumpAnimation(){
		bulletParticle.transform.position =this.transform.position;
		bulletParticle.enableEmission = true;
		AudioSource.PlayClipAtPoint(jumpSound, this.transform.position);
	}
	
}



