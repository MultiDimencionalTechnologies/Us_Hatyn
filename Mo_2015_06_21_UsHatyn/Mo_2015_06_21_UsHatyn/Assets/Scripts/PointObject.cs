using UnityEngine;
using System.Collections;

public class PointObject{

	public int id;
	public float coordX;
	public float coordY;
	public string imagePath;
	public string name;
	public string text;
	public Transform po_transform;

	public PointObject(){
		id = 0;
		coordX = 0f;
		coordY=0f;
		imagePath=null;
		name=null;
		text=null;
		po_transform=null;
	}

	public PointObject(int _id){
		id = _id;
		coordX = 0f;
		coordY=0f;
		imagePath=null;
		name=null;
		text=null;
		po_transform=null;
	}
	public PointObject(int _id , float _coordX, float _coordY){
		id = _id;
		coordX = _coordX;
		coordY = _coordY;
		imagePath=null;
		name=null;
		text=null;
		po_transform=null;
	}
	
}
