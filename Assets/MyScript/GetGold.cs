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
       
    }

    public void TouchGold(GameObject goldObject)
    {
        GoldNumText.SetActive(false);
        Destroy(goldObject);
        getGoldNum++;
        GoldNumText.GetComponent<Text>().text = "x " + getGoldNum;
    }
}
