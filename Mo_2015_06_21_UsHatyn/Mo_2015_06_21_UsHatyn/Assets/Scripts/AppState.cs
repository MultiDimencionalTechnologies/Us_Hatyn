using UnityEngine;
using System.Collections;
using Mo_2015_06_21_UsHatyn;

public class AppState : MonoBehaviour {

    public MainController mController;

    public enum EAppState
    {
        None = 0,
        Main = 1,
        Menu = 2,
        Prog = 3,
        Hist = 4,
        About = 5,
        AEBMenu = 6,
        Search = 7,
        AEBSearch = 8,
        Object = 9,
        SearchObject = 10,
        MenuObject = 11
    }

    public static EAppState InAppState;
    public static EAppState PrevAppState;

    public void ChangeAppState(EAppState newState)
    {
        var oldState = InAppState;

        if (oldState == newState)
        {
            return;
        }
        if (newState == EAppState.None && oldState == EAppState.Main)
        {
            Application.Quit();
        }

        if (newState == EAppState.Object && oldState == EAppState.Main)
        {
            InAppState = EAppState.Object;
            PrevAppState = EAppState.Main;
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Main && oldState == EAppState.Object)
        {
            InAppState = EAppState.Main;
            PrevAppState = EAppState.None;
            CameraViewControl.Instance.isInfoPanelShow = false;
            if (CameraViewControl.Instance.isRightPanelShow)
            {
                (CameraViewControl.Instance.FindResource("SmallRightPanelHide") as Noesis.Storyboard).Begin();
                CameraViewControl.Instance.isRightPanelShow = false;                       
            }
            if (CameraViewControl.Instance.isLeftPanelShow)
            {
                (CameraViewControl.Instance.FindResource("SmallLeftPanelHide") as Noesis.Storyboard).Begin();
                CameraViewControl.Instance.isLeftPanelShow = false;
            }
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.Search && oldState == EAppState.Main)
        {
            InAppState = EAppState.Search;
            PrevAppState = EAppState.Main;
        }
        if (newState == EAppState.Main && oldState == EAppState.Search)
        {
            InAppState = EAppState.Main;
            PrevAppState = EAppState.None;
            (CameraViewControl.Instance.FindResource("CloseLeftPanelClick") as Noesis.Storyboard).Begin();
        }

        if (newState == EAppState.AEBSearch && oldState == EAppState.Search)
        {
            InAppState = EAppState.AEBSearch;
            PrevAppState = EAppState.Search;
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Search && oldState == EAppState.AEBSearch)
        {
            InAppState = EAppState.Search;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("AEBHide") as Noesis.Storyboard).Begin();
            (CameraViewControl.Instance.FindResource("CloseBRPClick") as Noesis.Storyboard).Begin();
            CameraViewControl.Instance.isInfoPanelShow = false;
            CameraViewControl.Instance.isRightPanelShow = false;
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.Menu && oldState == EAppState.Main)
        {
            InAppState = EAppState.Menu;
            PrevAppState = EAppState.Main;
        }
        if (newState == EAppState.Main && oldState == EAppState.Menu)
        {
            InAppState = EAppState.Main;
            PrevAppState = EAppState.None;
            (CameraViewControl.Instance.FindResource("CloseLeftPanelClick") as Noesis.Storyboard).Begin();
        }

        if (newState == EAppState.Prog && oldState == EAppState.Menu)
        {
            InAppState = EAppState.Prog;
            PrevAppState = EAppState.Menu;
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Menu && oldState == EAppState.Prog)
        {
            InAppState = EAppState.Menu;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("CloseBRPClick") as Noesis.Storyboard).Begin();
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.Hist && oldState == EAppState.Menu)
        {
            InAppState = EAppState.Prog;
            PrevAppState = EAppState.Menu;
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Menu && oldState == EAppState.Hist)
        {
            InAppState = EAppState.Menu;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("CloseBRPClick") as Noesis.Storyboard).Begin();
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.About && oldState == EAppState.Menu)
        {
            InAppState = EAppState.About;
            PrevAppState = EAppState.Menu;
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Menu && oldState == EAppState.About)
        {
            InAppState = EAppState.Menu;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("CloseBRPClick") as Noesis.Storyboard).Begin();
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.AEBMenu && oldState == EAppState.Menu)
        {
            InAppState = EAppState.AEBMenu;
            PrevAppState = EAppState.Menu;
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Menu && oldState == EAppState.AEBMenu)
        {
            InAppState = EAppState.Menu;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("AEBHide") as Noesis.Storyboard).Begin();
            (CameraViewControl.Instance.FindResource("CloseBRPClick") as Noesis.Storyboard).Begin();
            CameraViewControl.Instance.isRightPanelShow = false;
            CameraViewControl.Instance.isInfoPanelShow = false;
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.SearchObject && oldState == EAppState.Search)
        {
            InAppState = EAppState.SearchObject;
            PrevAppState = EAppState.Search;
            (CameraViewControl.Instance.FindResource("InfoPanelShow") as Noesis.Storyboard).Begin();
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Search && oldState == EAppState.SearchObject)
        {
            InAppState = EAppState.Search;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("SmallRightPanelHide") as Noesis.Storyboard).Begin();
            (CameraViewControl.Instance.FindResource("InfoPanelHide") as Noesis.Storyboard).Begin();
            CameraViewControl.Instance.isRightPanelShow = false;
            CameraViewControl.Instance.isInfoPanelShow = false;
            mController.SetTapDetecting(true);
        }

        if (newState == EAppState.MenuObject && oldState == EAppState.Menu)
        {
            InAppState = EAppState.MenuObject;
            PrevAppState = EAppState.Menu;
            (CameraViewControl.Instance.FindResource("InfoPanelShow") as Noesis.Storyboard).Begin();
            mController.SetTapDetecting(false);
        }
        if (newState == EAppState.Menu && oldState == EAppState.MenuObject)
        {
            InAppState = EAppState.Menu;
            PrevAppState = EAppState.Main;
            (CameraViewControl.Instance.FindResource("SmallRightPanelHide") as Noesis.Storyboard).Begin();
            (CameraViewControl.Instance.FindResource("InfoPanelHide") as Noesis.Storyboard).Begin();
            CameraViewControl.Instance.isRightPanelShow = false;
            CameraViewControl.Instance.isInfoPanelShow = false;
            mController.SetTapDetecting(true);
        }   
    }

    public void GoBack()
    {
        ChangeAppState(PrevAppState);
    }

	// Use this for initialization
	void Start () {
        InAppState = EAppState.Main;
        PrevAppState = EAppState.None;
        mController = Camera.main.GetComponent<MainController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
	}
}
