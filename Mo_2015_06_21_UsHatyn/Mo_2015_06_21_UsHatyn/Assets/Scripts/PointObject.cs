using UnityEngine;
using System.Collections;

public class PointObject{

	public int id;
	public string imagePath;
	public string name;
    public string nameWithNumber;
	public string text;
	public Transform po_transform;

	public PointObject(){
		id = 0;
		imagePath=null;
		name=null;
		text=null;
		po_transform=null;
	}

	public PointObject(int _id){
		id = _id;
		imagePath=null;
		name=null;
		text=null;
		po_transform=null;
	}
	public PointObject(int _id , float _coordX, float _coordY){
		id = _id;
		imagePath=null;
		name=null;
		text=null;
		po_transform=null;
	}
	
}
