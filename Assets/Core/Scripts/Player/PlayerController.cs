using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PlayerController : MonoBehaviour
{
    protected static bool isGround;
    protected static float yPosition;

    public static bool IsGround=>isGround;
}
