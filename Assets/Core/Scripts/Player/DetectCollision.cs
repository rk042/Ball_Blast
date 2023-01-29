using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectCollision : PlayerController
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag(GameTags.Ground.ToString()))
        {  
            isGround=true;
            yPosition=transform.position.y;
        }
    }
}
