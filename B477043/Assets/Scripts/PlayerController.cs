﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    public Transform relativeTransform;
    public GameObject itemWindow;
    private bool isWindowOpened = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += relativeTransform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += -relativeTransform.forward;
        if (Input.GetKey(KeyCode.A)) moveDirection += -relativeTransform.right;
        if (Input.GetKey(KeyCode.D)) moveDirection += relativeTransform.right;

        moveDirection.y = 0f;

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        if(moveDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(moveDirection);

                
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isWindowOpened == false)
            {
                itemWindow.SetActive(true);
                isWindowOpened = true;
            }
            else
            {
                itemWindow.SetActive(false);
                isWindowOpened = false;
            }
                
        }
        

    }


}
