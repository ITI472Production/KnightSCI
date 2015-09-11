using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class charaterController : MonoBehaviour {

	public Vector3 mousePosition;
	public float moveSpeed ;	

	private LineRenderer lineRend;

	public ScrollRect backGroundScrollRect;
	public RectTransform backGround;
	private Vector3[] worldCorners= new Vector3[4];
	// 1 top left 3 bottom right


	public star begin;
	public star over;

	// Use this for initialization
	void Start () {
		lineRend = (LineRenderer)GetComponent (typeof(LineRenderer));
		backGround.GetWorldCorners(worldCorners) ;
	}
	
	// Update is called once per frame
	void Update () {
		//player movement
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector3.Lerp( new Vector3 (transform.position.x , transform.position.y, 5), mousePosition, moveSpeed);


		//line movement
		if(begin==null){
			lineRend.enabled=false;
			backGroundScrollRect.horizontal=true;
			backGroundScrollRect.vertical=true;
		}
		else{

			backGroundScrollRect.horizontal=false;
			backGroundScrollRect.vertical=false;
			//makes scroll rect movable if player is next to the edge
			if(worldCorners[1].x- (worldCorners[1].x/10) > this.transform.position.x){
				backGroundScrollRect.horizontalNormalizedPosition = backGroundScrollRect.horizontalNormalizedPosition-(backGroundScrollRect.horizontalNormalizedPosition/1000);
			}
			if(worldCorners[3].x- (worldCorners[3].x/10) < this.transform.position.x){
				backGroundScrollRect.horizontalNormalizedPosition = backGroundScrollRect.horizontalNormalizedPosition+(backGroundScrollRect.horizontalNormalizedPosition/1000);
			}
			if(worldCorners[1].y- (worldCorners[1].y/10) > this.transform.position.y){
				backGroundScrollRect.verticalNormalizedPosition = backGroundScrollRect.verticalNormalizedPosition-(backGroundScrollRect.verticalNormalizedPosition/1000);
			}
			if(worldCorners[3].y- (worldCorners[3].y/10) < this.transform.position.y){
				backGroundScrollRect.verticalNormalizedPosition = backGroundScrollRect.verticalNormalizedPosition+(backGroundScrollRect.verticalNormalizedPosition/1000);
			}


			lineRend.enabled=true;
			lineRend.SetPosition(0,begin.transform.position);
			if(over==null){
				lineRend.SetPosition(1,new Vector3 (mousePosition.x , mousePosition.y, 90));
			}
			else{
				lineRend.SetPosition(1,over.transform.position);		
			}
		}

		//star logic
		if(Input.GetMouseButtonDown(0)==true){
			begin=over;
		}
		if(Input.GetMouseButtonUp(0)==true){
			if(begin!=null){
				if(over==null){
					begin=null;
				}
				else{
					over.checkMainConstalation(begin,over);
					begin=null;
				}
			}
		}

	}
}
