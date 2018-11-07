using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpStair : MonoBehaviour {

    private GameObject ARportalObject;
    public int level = 0;

    private GameObject TempObject;
	// Use this for initialization
	void Start () {
        ARportalObject = GameObject.Find("ARPortalObject(Clone)");
        TempObject = GameObject.Find("Temp");
        // ARportalObject.transform.position -= TempObject.transform.position - ARportalObject.gameObject.transform.GetChild(0).transform.position;
       
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    public void stairTouch()
    {
        //_ShowAndroidToastMessage("Stair");
        // ARportalObject.gameObject.transform.GetChild(0).transform.position;  => movePoint
        // ar - (movePoint - camera position)
        if (level == 1)
        {
            ARportalObject.transform.position -= new Vector3(1.5f, 0.8f, 0);
        }
        else if(level == 2)
        {
            ARportalObject.transform.position -=
                new Vector3(TempObject.transform.position.x - ARportalObject.gameObject.transform.GetChild(1).transform.position.x, ARportalObject.transform.position.y, TempObject.transform.position.z + ARportalObject.gameObject.transform.GetChild(1).transform.position.z);
        }
        
    }


    /// <summary>
    /// Show an Android toast message.
    /// </summary>
    /// <param name="message">Message string to show in the toast.</param>
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                    message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
