using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemRange : MonoBehaviour {

    public PlayerController player;
    public GameObject playerObj;
	// Use this for initialization
	void Start () {
        player = playerObj.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "bow")
            if (Input.GetKey(KeyCode.F))
            {
                player.haveBow = true;
                Destroy(col.gameObject);
            }
    }
}
