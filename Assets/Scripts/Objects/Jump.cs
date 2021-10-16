using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float ForceLimit = 17;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            float scale = collision.transform.localScale.x;
            if (scale == 1)
            {
                scale = 0.8f;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up / ForceLimit * scale);
        }
    }
}
