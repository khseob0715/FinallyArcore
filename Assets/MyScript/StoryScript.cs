using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

    public GameObject TextGroup;
    private int cur_text_index = 0;

    private int TextGroup_Size;
    // Use this for initialization
    void Start()
    {
        TextGroup_Size = TextGroup.gameObject.transform.childCount - 1;
        //print(TextGroup_Size);
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void nextStory()
    {
        print(cur_text_index);
        if (cur_text_index == TextGroup_Size)
        {
            SceneManager.LoadScene("HelloAR");
        }

        TextGroup.gameObject.transform.GetChild(cur_text_index).gameObject.SetActive(false);
        TextGroup.gameObject.transform.GetChild(++cur_text_index).gameObject.SetActive(true);

       
    }
}
