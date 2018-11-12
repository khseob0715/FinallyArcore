using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabarianMoveToMe : MonoBehaviour {

    private GameObject UserObject;

    public float smooth = 0.2f;
    private bool once = false;
    private float delayTime = 5.0f;
    private float time = 0.0f;
    

    private GameObject Panel;
    // Use this for initialization
    void Start () {
        UserObject = Camera.main.gameObject;
        Panel = GameObject.Find("Panel");
	}
	
	// Update is called once per frame
	void Update () {


        time += Time.deltaTime;
        if(time > delayTime)
        {
            once = true;
        }
        Vector3 tagetPosition = new Vector3(UserObject.transform.position.x, 0.16f, UserObject.transform.position.z);
        
        if (once) { 
            transform.position = Vector3.Lerp(transform.position, tagetPosition, smooth * Time.deltaTime);            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ARCore Device")
        {
            Panel.GetComponent<CanvasGroup>().alpha = 1;
            Panel.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(GameObject.Find("MoveBarbarian"));
            GameObject.Find("Fixed Joystick").SetActive(false);
            GameObject.Find("GoldUI").SetActive(false);
            
            GameObject.Find("SnackBar").SetActive(false);
            
        }
    }
}
