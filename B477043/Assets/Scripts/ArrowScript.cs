using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public DoorScript doorScript;
    public GameObject door;
	// Use this for initialization
	void Start () {
        door = GameObject.Find("Door");
        doorScript = door.GetComponent<DoorScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Deer")
        {
            doorScript.isOpen = true;
            //Destroy(gameObject);
        }
    }
}
