using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour {

	bool difficulty=false;
	float soundLevel=1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnLevelWasLoaded(int level) {

		//find all sound 
		foreach ( AudioSource check in ((AudioSource[])FindObjectsOfType(typeof(AudioSource)))){
			check.volume=soundLevel;
		}

		//find constalation holder set difficulty
		foreach ( constalation check in ((constalation[])FindObjectsOfType(typeof(constalation)))){
			check.isHardMode=difficulty;
		}


		Debug.Log ("meow");
		
	}
	
	
	public bool getDifficulty(){
		return difficulty;

	}

	public void setDifficulty(bool dif){
		difficulty = dif;
	}

	public void setSound(float soundIn){
		soundLevel = soundIn;
	}


}
