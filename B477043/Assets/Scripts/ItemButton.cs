﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IDragHandler, IEndDragHandler {
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    
}
