using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mo_2015_06_21_UsHatyn;
using System.IO;
using System.Text;


public class MainController : MonoBehaviour {

	private bool detecttap = true;
    public bool flag = false;

	public Tracker user;
	//public int currentObjectID;

	bool move=false;
	public Vector2 prevPosition;
	private float softborderX;
	private float softborderY;
	private float zoomSpeed=1f;
	public float tapTimer;
	private Vector3 destination;	
	public RaycastHit rh = new RaycastHit();
	public int currentID = -1;
    public Touch touch;
	//private bool miniPannelShowed=false;

	public PointObject[] objectList = new PointObject[23];
	private float orthographicSize;

    private Vector3 buffX;

    public TextAsset[] Texts;
/*-----------------------------------START BLOCK----------------------------------------------------*/
    private void copyFilesFromResourcesToPersistentDataPath()
    {
        string buffer = (Resources.Load<TextAsset>("file") as TextAsset).text;
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + "Objects.txt", buffer, System.Text.Encoding.Unicode);
	
        buffer = (Resources.Load<TextAsset>("ru") as TextAsset).text;
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + "ru.txt", buffer, System.Text.Encoding.Unicode); 
    }
/*--------------------------------------END BLOCK-----------------------------------------------------------------*/
	private void Awake()
	{
		GetComponent<Camera>().orthographic = true;
		SetUniform();
        SetOrthoSize(1000f);
		//задание первоначального масштаба 1 пиксель - 1 юнит
	} 

	private void SetUniform()
	{
		orthographicSize = Screen.height / 2f;
		if (orthographicSize != GetComponent<Camera> ().orthographicSize)
			SetOrthoSize (orthographicSize);
		softborderY = orthographicSize+50;
		softborderX = Screen.width * orthographicSize / Screen.height + 50;
	}
	private void SetOrthoSize(float newsize){
		GetComponent<Camera>().orthographicSize = newsize;
        checkBorders();
	}

	private void Start()
	{
/*---------------------------------START BLOCK----------------------------------------------------*/
        copyFilesFromResourcesToPersistentDataPath();   
		//Создание массива объектов из текстовых файлов
        string fileName = Application.persistentDataPath + "/" + "Objects.txt";
		StreamReader theReader = new StreamReader(fileName, Encoding.Default);
/*-----------------------------END BLOCK----------------------------------------------------*/
		string line;
		using (theReader) {
			do
			{
				line = theReader.ReadLine();
				if (line != null)
				{	string[] entries = line.Split(';');
					int id = int.Parse(entries[0]);
					float X = float.Parse(entries[1]);
					float Y = float.Parse(entries[2]);
					PointObject npo = new PointObject(id,X,Y);
					objectList[id - 1] = npo;
					objectList[id-1].imagePath = "Objects/"+(id).ToString();
					if (GameObject.Find(id.ToString())){
						objectList[id-1].po_transform=GameObject.Find(id.ToString()).transform;
					}
				}
			}
			while (line != null);			   
			theReader.Close();
		}
		
/*---------------------------START BLOCK----------------------------------------------------*/
        fileName = Application.persistentDataPath + "/" + "ru.txt";
		theReader = new StreamReader(fileName, Encoding.Default);
/*------------------------------END BLOCK----------------------------------------------------*/
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
                    objectList[id - 1].nameWithNumber = id.ToString() + "." + objectList[id - 1].name;
                    entries = theReader.ReadLine().Split(';');
                    objectList[id - 1].text = "";
                    foreach (var item in entries)
                    {
                        objectList[id - 1].text += item + "\n\n";
                    }
				}
			}
			while (line != null);			   
			theReader.Close();
		}

		//user.Track(user.target1);
        CameraViewControl.Instance.CreateTextBlockInSearch(FindByName(""));
	}

	private void Update()
	{
		if (detecttap) {
			//обработчик нажатий
			if (Input.touchCount > 0) {
				if (Input.touchCount == 1) {
					touch = Input.touches [0];
					switch (touch.phase) {
					/*case TouchPhase.Stationary:
                        tapTimer += Time.deltaTime;
						if (tapTimer >= 1) {
							Ray ray = Camera.main.ScreenPointToRay (touch.position);
							user.transform.position = ray.GetPoint(10);
						}
						break;*/
					case TouchPhase.Moved:
						if (!move) 
                        {
                            if (Vector2.Distance(touch.position, prevPosition) >= Screen.height / 100f * 5f) 
                            {
								move = true;
								prevPosition = touch.position;				
							}
						} 
                        else 
                        {
							gameObject.transform.Translate (-touch.deltaPosition * 3);
							checkBorders ();
						}
						break;
					case TouchPhase.Ended:
                        if (tapTimer < 1 && Vector2.Distance(touch.position, prevPosition) < Screen.height / 100f * 5f && flag)
                        {
                            if (!CameraViewControl.Instance.MiniPanelObject.isMiniPanelVisible)
                            {
                                Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out rh, 15f);
                                currentID = int.Parse(rh.transform.parent.name) - 1;
                                if (currentID != -1)
                                {
                                    Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(objectList[currentID].po_transform.position);
                                    CameraViewControl.Instance.MiniPanelObject.ShowMiniPanel(100f * objectScreenPosition.x / Screen.width, 100f * objectScreenPosition.y / Screen.height, objectList[currentID].name, objectList[currentID].imagePath, objectList[currentID].text);
                                    TranslatetoObject(currentID);
                                }
                            }
                            else
                            {
                                CameraViewControl.Instance.MiniPanelObject.HideMiniPanel();
                                //user.StopTracking();
                            }
						}
                        tapTimer = 0f;
						break;
					default:
						move = false;
						break;
					}
				}
				if (Input.touchCount == 2) {
					Touch touch1 = Input.touches [0];
					Touch touch2 = Input.touches [1];
					float prevdiffMagnitude = ((touch1.position - touch1.deltaPosition) - (touch2.position - touch2.deltaPosition)).magnitude;
					float diffMagnitude = (touch1.position - touch2.position).magnitude;
					float deltaMagDiff = prevdiffMagnitude - diffMagnitude;

					zoomSpeed=1+GetComponent<Camera> ().orthographicSize/Screen.height/2f;
					GetComponent<Camera> ().orthographicSize = GetComponent<Camera> ().orthographicSize + deltaMagDiff * zoomSpeed * GetComponent<Camera> ().orthographicSize/Screen.height*2f ;

					if (GetComponent<Camera> ().orthographicSize < Screen.height / 2f) {
						GetComponent<Camera> ().orthographicSize = Screen.height / 2f;
					}
					if (GetComponent<Camera> ().orthographicSize > 4500f / 2f) {
						GetComponent<Camera> ().orthographicSize = 4500f / 2f;
					}
				 
				}

                
			}	 
		}
        checkBorders();
        /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            TranslatetoObject(spaceobj);
            spaceobj++;
        }
         * */
	}

	private void LateUpdate()
	{
		Vector3 userScreenPosition = Camera.main.WorldToScreenPoint(user.transform.position);
		CameraViewControl.Instance.MarkerObject.SetMarkerPosition(100f*userScreenPosition.x/Screen.width,100f*userScreenPosition.y/Screen.height);
		if (currentID != -1) {
			Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(objectList[currentID].po_transform.position);

			CameraViewControl.Instance.MiniPanelObject.ChangeMiniPanelPosition(100f*objectScreenPosition.x/Screen.width,100f*objectScreenPosition.y/Screen.height);
		}
	}


	private void checkBorders(){

		softborderY = GetComponent<Camera>().orthographicSize+50;
		softborderX = Screen.width * GetComponent<Camera>().orthographicSize / Screen.height + 50;

		if (Mathf.Abs(transform.position.x)>(9580f/2f-softborderX))
        {
            if (transform.position.x > 0)
            {
                buffX.x = 9580f / 2f - softborderX;
                buffX.y = transform.position.y;
                buffX.z = transform.position.z;
                transform.position = buffX;
            }
            else
            {
                buffX.x = -9580f / 2f + softborderX;
                buffX.y = transform.position.y;
                buffX.z = transform.position.z;
                transform.position = buffX;
            }
			
		}
		if (Mathf.Abs(transform.position.z)>(5121/2f-softborderY))
        {
            if (transform.position.z > 0)
            {
                buffX.x = transform.position.x;
                buffX.y = transform.position.y;
                buffX.z = 5121 / 2f - softborderY;
                transform.position = buffX;
            }
            else
            {
                buffX.x = transform.position.x;
                buffX.y = transform.position.y;
                buffX.z = -5121 / 2f + softborderY;
                transform.position = buffX;
            }
		}
	}
	public string[] FindByName(string namepart)
    {
		namepart = namepart.ToLower ();
		List<string> search = new List<string>();
		bool like = false;
		for (int i=0; i < objectList.Length; i++) 
        {
			string name = objectList[i].nameWithNumber.ToLower();
			for (int pos = 0; pos <= name.Length-namepart.Length;pos++)
            {
				for (int j=0; j < namepart.Length; j++)
                {
					if (namepart[j] == name[pos + j])
                    {
						like = true;
					}
					else 
                    {
						like = false;
						break;
					}
				}
				if (like)
                {
                    search.Add(objectList[i].nameWithNumber);
					like = false;
					break;
				}
			}
		}
		if (search.Count > 0) {
			return search.ToArray ();
		} 
        else
        {
            foreach (var item in objectList)
            {
                search.Add(item.nameWithNumber);
            }
        }
		return search.ToArray ();
	}

	private void sortByName() 
    {
		string[] names = new string[objectList.Length];
		for (int i=0;i<objectList.Length;i++)
        {
			names[i]=objectList[i].name;
		}
	}
	public void SetTapDetecting(bool detect){
		if (detect) {
			detecttap = true;
			Debug.Log( "Now taps detecting");
		}
		else {
			detecttap = false;
			Debug.Log( "Now taps not detecting");
		}
	}
	public void TranslatetoObject(string objectName){
		for (int i=0; i<objectList.Length; i++) {
            if (objectList[i].nameWithNumber.ToLower() == objectName.ToLower())
            {
				TranslatetoObject(i);
				break;
			}
		}
	}

    public void GoToUserPosition()
    {
        Hashtable ht = new Hashtable();
        ht.Add("x", user.gameObject.transform.position.x);
        ht.Add("z", user.gameObject.transform.position.z);
        //ht.Add ("looktarget",objectList[objectID].po_transform);
        ht.Add("time", 2f);
        ht.Add("easetype", iTween.EaseType.easeOutCubic);
        //ht.Add("onstart", "SetTapDetecting");
        //ht.Add("onstartparams", false);
        //ht.Add("oncomplete", "SetTapDetecting");
        //ht.Add("oncompleteparams", true);
        iTween.MoveTo(gameObject, ht);
    }

	public void TranslatetoObject(int objectID){
        user.Track(objectList[objectID].po_transform);
		Hashtable ht = new Hashtable ();
		ht.Add ("x", objectList [objectID].po_transform.position.x);
		ht.Add ("z", objectList [objectID].po_transform.position.z);
		//ht.Add ("looktarget",objectList[objectID].po_transform);
		ht.Add ("time",1.25f);		
        ht.Add ("easetype", iTween.EaseType.easeOutCubic);
		//Debug.Log (objectList [objectID].po_transform.name);
		//ht.Add ("onstart","SetTapDetecting");
		//ht.Add ("onstartparams", false);
		//ht.Add ("oncomplete","SetTapDetecting");
		//ht.Add ("oncompleteparams", true);
		iTween.MoveTo (gameObject,ht);

		if (GetComponent<Camera> ().orthographicSize != Screen.height / 2f) {
			Hashtable par = new Hashtable();
			par.Add("from",GetComponent<Camera> ().orthographicSize);
			par.Add("to",Screen.height / 2f * 2f);
            par.Add("time", 1.25f);
			//ht.Add ("easetype", iTween.EaseType.easeOutCubic);
			par.Add("onupdate","SetOrthoSize");
			iTween.ValueTo(gameObject,par);
		}
	}

    public void ZoomIn()
    {
        if (GetComponent<Camera>().orthographicSize >= Screen.height / 2f)
        {
            Hashtable par = new Hashtable();
            par.Add("from", GetComponent<Camera>().orthographicSize);
            par.Add("to", GetComponent<Camera>().orthographicSize * 0.6f < Screen.height / 2f ? Screen.height / 2f : GetComponent<Camera>().orthographicSize * 0.6f);
            par.Add("time", 0.5f);
            //ht.Add ("easetype", iTween.EaseType.easeOutCubic);
            par.Add("onupdate", "SetOrthoSize");
            iTween.ValueTo(gameObject, par);
        }
    }

    public void ZoomOut()
    {
        if (GetComponent<Camera>().orthographicSize <= 2500f)
        {
            Hashtable par = new Hashtable();
            par.Add("from", GetComponent<Camera>().orthographicSize);
            par.Add("to", GetComponent<Camera>().orthographicSize * 1.6f > 2500f ? 2500f : GetComponent<Camera>().orthographicSize * 1.6f);
            par.Add("time", 0.5f);
            //ht.Add ("easetype", iTween.EaseType.easeOutCubic);
            par.Add("onupdate", "SetOrthoSize");
            iTween.ValueTo(gameObject, par);
        }
    }
}
