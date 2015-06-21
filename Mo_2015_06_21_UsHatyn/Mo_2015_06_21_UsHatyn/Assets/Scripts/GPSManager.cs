using UnityEngine;
using System.Collections;
using Mo_2015_06_21_UsHatyn;
public class GPSManager : MonoBehaviour {


    private bool isGPSInit = false;
    private bool isTooFar = true;
    private bool isFinding = false;
    private LocationInfo loc;
    private float leftBorder = 129.758975f;
    private float rightBorder = 129.810922f;
    private float topBorder = 62.203114f;
    private float bottomBorder = 62.186340f;
    private MainController mController;
    private Vector3 buff;

    private void checkGPS()
    {
        if (Input.location.isEnabledByUser)
        {
            (CameraViewControl.Instance.FindResource("GPSHide") as Noesis.Storyboard).Begin();
            (CameraViewControl.Instance.FindResource("CantFindHide") as Noesis.Storyboard).Begin();
            (CameraViewControl.Instance.FindResource("TooFarHide") as Noesis.Storyboard).Begin();
            isFinding = true;
            while (Input.location.status == LocationServiceStatus.Initializing)
            {
                if (isFinding)
                {
                    (CameraViewControl.Instance.FindResource("FindingShow") as Noesis.Storyboard).Begin();
                    isFinding = false;
                }
            }
            if (Input.location.status == LocationServiceStatus.Running)
            {
                (CameraViewControl.Instance.FindResource("FindingHide") as Noesis.Storyboard).Begin();
                isGPSInit = true;
                RetrieveGPSData();
            }
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                (CameraViewControl.Instance.FindResource("CantFindShow") as Noesis.Storyboard).Begin();
            }
        }
        else
        {
            (CameraViewControl.Instance.FindResource("GPSShow") as Noesis.Storyboard).Begin();
            isGPSInit = false;
        }
    }
    private void RetrieveGPSData()
    {
        loc = Input.location.lastData;
        if (loc.longitude > rightBorder || loc.longitude < leftBorder || loc.latitude > topBorder || loc.latitude < bottomBorder)
        {
            (CameraViewControl.Instance.FindResource("TooFarShow") as Noesis.Storyboard).Begin();
            isTooFar = true;
        }
        else
        {
            (CameraViewControl.Instance.FindResource("TooFarHide") as Noesis.Storyboard).Begin();
            isTooFar = false;
            CameraViewControl.Instance.MarkerObject.MarkerVisibility = true;
            buff.x = CoordinatesConverter.ConvertXFromRealToUnity(loc.longitude);
            buff.z = CoordinatesConverter.ConvertYFromRealToUnity(loc.latitude);
            buff.y = 0f;
            mController.user.transform.position = buff;
            if (mController.currentID != -1 && mController.user.tracking)
            {
                mController.user.Track(mController.objectList[mController.currentID].po_transform);
            }
        }
        //(CameraViewControl.Instance.FindName("DebugTextBlock") as Noesis.TextBlock).Text = "X: " + loc.longitude.ToString() + "//Y: " + loc.latitude.ToString();
    }
 	// Use this for initialization
	void Start () 
    {
        mController = Camera.main.GetComponent<MainController>();
#if !UNITY_STANDALONE
        Input.location.Start(3f, 3f);
        InvokeRepeating("checkGPS", 1f, 1f);
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
