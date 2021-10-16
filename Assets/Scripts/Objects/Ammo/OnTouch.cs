using GameManagerRelated;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Weapon collide with objects behavior 
public class OnTouch : MonoBehaviour
{
    private GameManager myGM;
    private PoolClass pool;
   

    void Start()
    {
        myGM = GameObject.FindObjectOfType<GameManager>();
        pool = GameObject.FindObjectOfType<PoolClass>();
    }

    [Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Consts.Bullet)
        {
            pool.GrenadeInActive(collision.gameObject);
            DestroyAndDuplicate(gameObject);
        }
    }

    private void DestroyAndDuplicate(GameObject gameObject)
    {
        if (gameObject.transform.localScale.x < 0.8f)
        {
            Destroy(gameObject);
        }
        else
        {
            //Clone
            GameObject Obj = Instantiate(gameObject);
            //Rescale clone and move left
            Obj.transform.position = transform.position + Vector3.left + Vector3.up * (1 / transform.localScale.z);
            Obj.transform.localScale = Obj.transform.localScale * 0.8f;
            //Rescale original object and move right
            transform.localScale = transform.localScale * 0.8f;
            transform.Translate(Vector2.right+Vector2.up*(1/ transform.localScale.z));
        }
    }
}
