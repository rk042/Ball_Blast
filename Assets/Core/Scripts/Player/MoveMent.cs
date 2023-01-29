using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : PlayerController
{
    void Update()
    {
        if (Input.GetMouseButton(0) && isGround)
        {
            Vector3 lastPosition=transform.position;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 viewPoint = Camera.main.WorldToViewportPoint(worldPoint);
            if (viewPoint.x>0 && viewPoint.x<1)
            {   worldPoint=new Vector3(worldPoint.x,yPosition,10);
                lastPosition=worldPoint;
            }
            transform.position=lastPosition;    
        }
    }
}
