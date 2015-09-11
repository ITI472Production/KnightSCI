using UnityEngine;
using System.Collections;

public class star : MonoBehaviour {


	private charaterController player;
	private constalation mainConstalation;

	// Use this for initialization
	void Start () {
				player = (charaterController)(GameObject.FindGameObjectWithTag ("player").GetComponent (typeof(charaterController)));
				if (gameObject.transform.parent != null) {
						mainConstalation = (constalation)gameObject.transform.parent.GetComponent (typeof(constalation));
				}
	
		}

	void OnMouseEnter(){

		player.over= this;
	}
	void OnMouseExit(){

		player.over = null;

	}
	public void checkMainConstalation(star begin,star over){
				mainConstalation.checkLines (begin, over);
		}
				
				

		
}
