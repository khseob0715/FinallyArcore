using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant_Move : MonoBehaviour {

    public GameObject RunObject;

    public GameObject user;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == user) { 
            RunObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
