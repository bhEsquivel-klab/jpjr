using UnityEngine;
using System.Collections;

public class SoundButton : MonoBehaviour {
	
	public GameObject targ;
	public string bgmOnName;
	public string bgmOffName;
	
	private AudioSource soundSource;
	
	void Start()
	{
		GameObject soundObject = GameObject.Find("SoundObject");
		soundSource = soundObject.GetComponent<AudioSource>();

		string currentName = targ.gameObject.GetComponent<UISlicedSprite>().spriteName;
		if(currentName == bgmOnName){
			soundSource.audio.Play();
		}else{
			soundSource.audio.Pause();
		}
		
	}
	void OnClick()
	{
		string currentName = targ.gameObject.GetComponent<UISlicedSprite>().spriteName;
		if(currentName == bgmOnName){
			targ.gameObject.GetComponent<UISlicedSprite>().spriteName = bgmOffName;
			soundSource.audio.Pause();
		}else{
			targ.gameObject.GetComponent<UISlicedSprite>().spriteName = bgmOnName;
					soundSource.audio.Play();
		}
	}
}

