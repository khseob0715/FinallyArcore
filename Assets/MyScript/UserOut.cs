using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserOut : MonoBehaviour {

    private GameObject Panel;

    
    // Use this for initialization
    void Start () {
        Panel = GameObject.Find("Panel");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ARCore Device")
        {
            Panel.GetComponent<CanvasGroup>().alpha = 1;
            Destroy(GameObject.Find("MoveBarbarian")); 
            Panel.transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Fixed Joystick").SetActive(false);
            GameObject.Find("GoldUI").SetActive(false);
            GameObject.Find("SnackBar").SetActive(false);
        }
    }
}
