using UnityEngine;
using System.Collections;

public class constalation : MonoBehaviour {
	private int completionCount;
	private int countToComplete;

	private SpriteRenderer endImage;

	public line[] lines;


	public string conName;
	public string info;
	public string hint ;


	public bool isComplete;

	void Start () {
		if (conName == "") {
			conName=this.name+" has not set its name yet";
				}
		if(info==""){
			info= this.name + " has not set its info yet";
		}
		if (hint == "") {
			hint= this.name + " has not set its hint yet";
				}
		int lineCount = 0;
		//adding all lines into refrence///////
		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(line)))!=null){
				lineCount++;
			}
			if(child.name=="endImage"){
				endImage=(SpriteRenderer)child.GetComponent(typeof(SpriteRenderer));
			}
		}
		if(endImage==null){
			Debug.LogError(this.name+"  HAS NO END IMAGE");
		}
		if(lineCount==0){
			Debug.LogError(this.name+"  HAS NO LINES CONNECTED TO IT");
		}
		lines = new line[lineCount];
		completionCount = lineCount;
		lineCount = 0;

		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(line)))!=null){
				lines[lineCount]=(line)child.GetComponent(typeof(line));
				lineCount++;
			}
		}
		///////////////////////////////////////
	
		if(isComplete==true){
			setComplete();
		}
		else{
			endImage.enabled=false;
			countToComplete=0;
		}
	}

	public void setComplete(){
		endImage.enabled=true;
		foreach(line check in lines){
			((LineRenderer)check.GetComponent(typeof(LineRenderer))).enabled=true;
			check.isActive=true;
		}
		//send Trigger to ConstailionController for a completed constilation
	}



	public void checkLines(star one, star two){
		foreach(line check in lines){
			if((check.one==one && check.two==two) || (check.one==two && check.two==one)){

				if(check.isActive==false){
					countToComplete++;
					//check if all are completed
					if(countToComplete==completionCount){
						isComplete=true;
						((constalationHolder)this.transform.parent.GetComponent(typeof(constalationHolder))).completedConstalation();
						endImage.enabled=true;
					}
					((LineRenderer)check.GetComponent(typeof(LineRenderer))).enabled=true;
					check.isActive=true;
				}
			}
		}

	}
	public void buttonPress(){
		((constalationHolder)this.transform.parent.GetComponent(typeof(constalationHolder))).setInfoPanel(conName,info,hint);
	}

}
