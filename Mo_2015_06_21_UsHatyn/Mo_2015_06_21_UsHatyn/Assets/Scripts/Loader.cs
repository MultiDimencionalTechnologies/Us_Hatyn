using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Loader : MonoBehaviour {
	//public List<PointObject> objectList;
	public PointObject[] objectList = new PointObject[23];
	// Use this for initialization
	void Start () {	

		string fileName ="Assets/Resources/Objects/Objects.txt";
		StreamReader theReader = new StreamReader(fileName, Encoding.Default);
		string line;
		using (theReader) {
			do
			{
				line = theReader.ReadLine();
				if (line != null)
				{	string[] entries = line.Split(';');
					int id =int.Parse(entries[0]);
					float X = float.Parse(entries[1]);
					float Y = float.Parse(entries[2]);
					PointObject npo = new PointObject(id,X,Y);
					objectList[id-1]=npo;
				}
			}
			while (line != null);			   
			theReader.Close();
		}

		fileName ="Assets/Resources/Objects/ru.txt";
		theReader = new StreamReader(fileName, Encoding.Default);
		using (theReader)
		{
			// While there's lines left in the text file, do this:
			do
			{
				line = theReader.ReadLine();
				if (line != null)
				{	string[] entries = line.Split(';');
					int id =int.Parse(entries[0]);
					objectList[id-1].id=id;
					string name = entries[1];
					objectList[id-1].name=name;
					objectList[id-1].text = theReader.ReadLine();
				}
			}
			while (line != null);			   
			theReader.Close();
		}
		for (int i=0; i<objectList.Length; i++) {
			Debug.Log(objectList[i].name);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
