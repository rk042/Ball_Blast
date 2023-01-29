using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private void Awake()
    {
        instance=this;
    }

}

public enum GameTags
{
    Ground,
    TopBulletHit
}