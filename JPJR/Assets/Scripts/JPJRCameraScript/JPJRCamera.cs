using UnityEngine;
using System.Collections;

public class JPJRCamera : MonoBehaviour {
	
	public GameObject targ;
	public float minmaxY;
	public float minmaxZ;
	private Vector3 pos;
	void Start () {
		minmaxY = transform.position.y;
		minmaxZ = transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		pos.x = targ.transform.position.x + 5.0f;
		pos.y = Mathf.Clamp(transform.position.y, minmaxY, minmaxY);
		pos.z = Mathf.Clamp(transform.position.z, minmaxZ, minmaxZ);
		transform.position = pos;
	}
}
