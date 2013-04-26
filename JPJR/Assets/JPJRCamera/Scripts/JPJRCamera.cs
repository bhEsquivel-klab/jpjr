using UnityEngine;
using System.Collections;

public class JPJRCamera : MonoBehaviour {
	
	public GameObject targ;
	public float movementSpeed = 0.2f;
	// Use this for initialization
	public float minmax;
	void Start () {
		minmax = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, minmax, minmax), transform.position.z);
	}
}
