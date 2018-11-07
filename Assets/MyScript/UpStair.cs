using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpStair : MonoBehaviour {

    private GameObject ARportalObject; 

	// Use this for initialization
	void Start () {
        ARportalObject = GameObject.Find("ARPortalObject(Clone)");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stairTouch()
    {
        //_ShowAndroidToastMessage("Stair");
        ARportalObject.transform.position = ARportalObject.transform.position - new Vector3(0, 0, 0);
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
