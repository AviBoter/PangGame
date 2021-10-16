using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int speed = 2;
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.zero,Vector3.up);
        transform.Translate((transform.up * speed * Time.deltaTime));
    }

}
