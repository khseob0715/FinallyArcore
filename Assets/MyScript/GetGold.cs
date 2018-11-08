using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGold : MonoBehaviour
{
    private GameObject GoldNumText;

    private int getGoldNum = 0;

    // Use this for initialization
    void Start()
    {
        GoldNumText = GameObject.Find("GoldText");
        GoldNumText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Gold")
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    TouchGold(touchedObject);
                }
            }
        }
    }

    public void TouchGold(GameObject goldObject)
    {
        GoldNumText.SetActive(false);
        Destroy(goldObject);
        getGoldNum++;
        GoldNumText.GetComponent<Text>().text = "x " + getGoldNum;
    }
}
