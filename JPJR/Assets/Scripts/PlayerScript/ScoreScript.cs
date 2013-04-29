using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	public int counter;
	// Use this for initialization
	void Start () {
		counter = 0;
		InvokeRepeating("UpdateScore",0f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void UpdateScore(){
		counter++;
		UILabel score = this.gameObject.GetComponent<UILabel>();
		score.text = ""+counter;
	}
}
