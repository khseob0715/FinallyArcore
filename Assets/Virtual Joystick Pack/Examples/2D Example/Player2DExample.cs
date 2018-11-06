using UnityEngine;

public class Player2DExample : MonoBehaviour 
{
    public float moveSpeed = 1f;
    public Joystick joystick;

    private GameObject HousObject;


    private void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if(HousObject == null)
        {
            HousObject = GameObject.Find("ARPortalObject(Clone)");
        }
       
        if (moveVector != Vector3.zero && HousObject != null)
        {
            //  transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            //  transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            //  HousObject.transform.rotation = Quaternion.LookRotation(moveVector);
            HousObject.transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
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
