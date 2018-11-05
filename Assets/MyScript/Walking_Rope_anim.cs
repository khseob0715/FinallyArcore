using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking_Rope_anim : MonoBehaviour {

    private Animator animator;
    private GameObject any;
    public static bool enable_check = true;

    private bool Single_Call = true;
	// Use this for initialization
	void Start () {
        //animator = this.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (Single_Call != true) { 
        
            animator.enabled = enable_check;
        }
    }

    public void enable_anim()
    {
        _ShowAndroidToastMessage("Input Button");

        if (Single_Call)
        {
            any = GameObject.Find("Set(Clone)");
            if(any == null)
            {
                _ShowAndroidToastMessage("not find");
            }
            else
            {
                _ShowAndroidToastMessage(any.gameObject.name);
            }
            
            animator = any.gameObject.transform.GetChild(0).GetComponent<Animator>();
            
            Single_Call = false;
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
