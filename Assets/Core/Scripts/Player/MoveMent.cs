using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : PlayerController
{
    [SerializeField] private float offsetRightLeft;
    [SerializeField] private float moveSpeed;
    
    void Update()
    {
        if (Input.GetMouseButton(0) && isGround)
        {
            Vector3 lastPosition=transform.position;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 viewPoint = Camera.main.WorldToViewportPoint(worldPoint);
            if (viewPoint.x>0 + offsetRightLeft && viewPoint.x<1 - offsetRightLeft)
            {   worldPoint=new Vector3(worldPoint.x,yPosition,10);
                lastPosition=worldPoint;
            }
            transform.position=Vector3.Lerp(transform.position,lastPosition,Time.deltaTime*moveSpeed);    
        }
    }
}
