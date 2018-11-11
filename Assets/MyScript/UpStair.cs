using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpStair : MonoBehaviour {

    private GameObject ARportalObject;
    private GameObject UserObject;
    private GameObject movePoint1;
    private GameObject movePoint2;
    private GameObject movePoint3;

    private int level = 1;

    private Vector3 Difference_1;
    private Vector3 Difference_2;
    private Vector3 Difference_3;

    // Use this for initialization
    void Start () {
        ARportalObject = GameObject.Find("ARPortalObject(Clone)");
        UserObject = Camera.main.gameObject;
        movePoint1 = ARportalObject.gameObject.transform.GetChild(0).gameObject;
        movePoint2 = ARportalObject.gameObject.transform.GetChild(1).gameObject;
        movePoint3 = ARportalObject.gameObject.transform.GetChild(2).gameObject;

    }
	
	// Update is called once per frame
	void Update () {

        
    }

    public void stairTouch()
    {
        if (level == 1)
        {
            Difference_1 = movePoint1.transform.position - UserObject.transform.position;
            ARportalObject.transform.position -= Difference_1;

            level++;
        }
        else if (level == 2)
        {
            Difference_2 = movePoint2.transform.position - UserObject.transform.position;
            ARportalObject.transform.position -= Difference_2;

            level++;
        }
        else
        {
            Difference_3 = movePoint3.transform.position - UserObject.transform.position;
            ARportalObject.transform.position -= Difference_3;
            level = 1;
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
