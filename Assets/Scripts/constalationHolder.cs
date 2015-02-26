using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class constalationHolder : MonoBehaviour {

	public int completionCount;
	public int countToComplete=0;

	public Button endGameButton;

	public Text infoPanelName;
	public Text infoPanelInfo;
	public Text infoPanelHint;

	public constalation[] cons;

	// Use this for initialization
	void Start () {

		int c=0;
		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(constalation)))!=null){
				c++;
			}
		}
		cons = new constalation[c];
		completionCount = c;
		c = 0;

		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(constalation)))!=null){
				cons[c]=(constalation)child.GetComponent(typeof(constalation));
				c++;
			}
		}

	}

	public void completedConstalation(){
		countToComplete++;
		if (countToComplete == completionCount) {

			endGameButton.interactable =true;
				}
	}


	public void setInfoPanel(string name,string info,string hint){
		infoPanelName.text = name;
		infoPanelInfo.text = info;
		infoPanelHint.text= hint;
	
	}

}
