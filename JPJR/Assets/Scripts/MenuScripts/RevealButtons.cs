using UnityEngine;
using System.Collections;

public class RevealButtons : MonoBehaviour {
	
	public float delay;
	public string easeType;
	public string loopType;
	
	public string axis;
	public int position;
	// Use this for initialization
	void Start () {
		iTween.MoveBy(gameObject, iTween.Hash(axis, position, "easeType", easeType, "loopType", loopType, "delay", delay));
	}
}
