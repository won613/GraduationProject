using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlankDrag : MonoBehaviour {

    float distance = 5;

	void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            distance -= 1;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            distance += 1;
    }
}
