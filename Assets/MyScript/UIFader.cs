using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public CanvasGroup uiElement;

    string toastString;

    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
        showToast();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLefping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLefping;

        float percentageComplete = timeSinceStarted / lerpTime;


        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLefping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;


            yield return new WaitForEndOfFrame();
        }
        print("done");
    }

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        }
    }

    public void showToastOnUiThread(string toastString)
    {
        this.toastString = toastString;
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        Debug.Log(this + ": Running on UI thread");

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }

}
