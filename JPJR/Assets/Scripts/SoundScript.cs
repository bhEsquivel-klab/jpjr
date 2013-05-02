using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	private static SoundScript instance = null;
    public static SoundScript Instance {
        get { return instance; }
    }
	
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

	