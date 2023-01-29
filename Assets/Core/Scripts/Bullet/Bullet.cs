using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    [SerializeField] float hitDamage;
    public float GetHitDamage=>hitDamage;
    private Rigidbody2D rd;
    public IObjectPool<Bullet> objectPool;

    private void Awake()
    {
        rd=GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        rd.AddForce(Vector2.up*shootSpeed,ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag(GameTags.TopBulletHit.ToString()))
        {
            Release();
        }
    }

    public void Release()
    {
        if (gameObject.activeInHierarchy)
        {   
            objectPool.Release(this);
        }
    }
}
