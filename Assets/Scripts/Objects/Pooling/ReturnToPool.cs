using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{

    private PoolClass Pool;
    private void Start()
    {
        Pool = GameObject.FindObjectOfType<PoolClass>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Consts.Bullet)
        {
            Pool.GrenadeInActive(collision.gameObject);
        }
    }
}
