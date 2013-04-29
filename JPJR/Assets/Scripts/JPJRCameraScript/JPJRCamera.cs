using UnityEngine;
using System.Collections;

public class JPJRCamera : MonoBehaviour {
	
	public GameObject targ;
	public float minmaxY;
	public float minmaxZ;
	void Start () {
		minmaxY = transform.position.y;
		minmaxZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(targ.transform.position.x + 5.0f,
								Mathf.Clamp(transform.position.y, minmaxY, minmaxY),
								Mathf.Clamp(transform.position.z, minmaxZ, minmaxZ));
	}
}
