using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Ball : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float health;
    [SerializeField] private Ball smallBall;

    public Rigidbody2D rd{get; private set;}
    private bool isLeftWall;
    
    private void Awake()
    {
        rd=GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BallAutoMove(other);
        BallBulletHit(other);
    }

    private void BallBulletHit(Collision2D other)
    {
        if (other.transform.CompareTag(GameTags.Bullet.ToString()))
        {
            rd.AddForce(new Vector2(other.transform.position.x,0.05f));

            if (other.transform.TryGetComponent<Bullet>(out Bullet bullet))
            {
                health-=bullet.GetHitDamage;
                bullet.Release();
            }

            if (health<=0)
            {
                //TODO generate small ball and destory big ball
                if (smallBall)
                {   
                    Ball smallBallTemp1 = Instantiate(smallBall,transform.position,Quaternion.identity);
                    Ball smallBallTemp2 = Instantiate(smallBall,transform.position,Quaternion.identity);
                    smallBallTemp1.rd.AddForce(new Vector2(2,5),ForceMode2D.Impulse);
                    smallBallTemp1.health=50;
                    smallBallTemp2.rd.AddForce(new Vector2(-2,5),ForceMode2D.Impulse);
                    smallBallTemp2.health=50;
                }
                Destroy(gameObject);
            }
        }
    }

    private void BallAutoMove(Collision2D other)
    {
        Vector2 forceDirection;
        if (other.transform.CompareTag(GameTags.WallLeft.ToString()))
        {
            forceDirection = new Vector2(0.1f, 0);
            rd.AddForce(forceDirection * jumpForce, ForceMode2D.Impulse);
            isLeftWall = true;
        }
        else if (other.transform.CompareTag(GameTags.WallRight.ToString()))
        {
            forceDirection = new Vector2(-0.1f, 0);
            rd.AddForce(forceDirection * jumpForce, ForceMode2D.Impulse);
            isLeftWall = false;
        }

        if (other.transform.CompareTag(GameTags.Ground.ToString()))
        {
            if (isLeftWall)
            {
                forceDirection = Vector2.up + new Vector2(0.1f, 0);
            }
            else
            {
                forceDirection = Vector2.up + new Vector2(-0.1f, 0);
            }
            rd.AddForce(forceDirection * jumpForce, ForceMode2D.Impulse);
        }
    }

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.transform.CompareTag(GameTags.Ground.ToString()))
    //     {
    //         rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //     }
    // }
}
