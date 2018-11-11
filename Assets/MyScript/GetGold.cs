using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.HelloAR;

public class GetGold : MonoBehaviour
{
    
    public int getGoldNum = 0;
    public LayerMask goldMask;
    private GameObject Controller;
    public GameObject StairJumpIcon;
    public GameObject Barbarian;
    public GameObject Barbarian2;

    // Use this for initialization
    void Start()
    {
    
        Controller = GameObject.Find("Example Controller");
        StairJumpIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, goldMask))
            {

                //_ShowAndroidToastMessage(hit.transform.name);
                TouchGold(hit.transform.gameObject);
            }
        }
    }

    public void TouchGold(GameObject goldObject)
    {
        Controller.GetComponent<HelloARController>().GoldUI.SetActive(true);
        Destroy(goldObject);
        getGoldNum++;
        Controller.GetComponent<HelloARController>().GoldUI.transform.GetChild(0).GetComponent<Text>().text = "x " + getGoldNum;
        if(getGoldNum == 14)
        {
            StairJumpIcon.SetActive(true);
            Controller.GetComponent<HelloARController>().NextButton();
            Barbarian.SetActive(false);
            Barbarian2.SetActive(true);
        }
    }

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
