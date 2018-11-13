using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Material doorClose;
    public Material doorOpen;
    public Material mat;
    public bool isOpen = false;
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpen)
        {
            Debug.Log("!231");
            mat.color = Color.white;
        }
            
	}
}
