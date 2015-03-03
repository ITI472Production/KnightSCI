using UnityEngine;
using System.Collections;

public class UIManagerMainMenu : MonoBehaviour {

	public Animator titlePanel;
	public Animator mainButtonsPanel;
	public Animator settingsPanel;
	public Animator deleteConformationPanel;
	public Animator levelSelectPanel;




	public void levelSpring(){
		Application.LoadLevel("temp");
	}


	
	public void setDifficulty(bool dif){

		((settings)FindObjectOfType (typeof(settings))).setDifficulty (dif);
	}
	
	public void setSound(float soundIn){
		((settings)FindObjectOfType (typeof(settings))).setSound (soundIn);
	}

	public void toggleDeletePanel(){
			deleteConformationPanel.SetBool ("isHidden",!deleteConformationPanel.GetBool("isHidden"));
		}

	public void toggleSettings(){
		if(deleteConformationPanel.GetBool("isHidden")==false){
			toggleDeletePanel();
		}
		settingsPanel.SetBool ("isHidden",!settingsPanel.GetBool("isHidden"));
		mainButtonsPanel.SetBool ("isHidden",!mainButtonsPanel.GetBool("isHidden"));
		titlePanel.SetBool ("isHidden",!titlePanel.GetBool("isHidden"));
	}

	public void toggleLevelPanel(){
		levelSelectPanel.SetBool ("isHidden",!levelSelectPanel.GetBool("isHidden"));
		mainButtonsPanel.SetBool ("isHidden",!mainButtonsPanel.GetBool("isHidden"));
		titlePanel.SetBool ("isHidden",!titlePanel.GetBool("isHidden"));
		settingsPanel.SetBool ("isHidden",true);

	}


}
