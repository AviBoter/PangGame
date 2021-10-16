using UnityEngine;
using System.Collections;
using System;

//Apple's slow movement
public class ObjectMove : MonoBehaviour 
{
    [Obsolete]
    void FixedUpdate () 
	{
		transform.position = new Vector3(transform.position.x , transform.position.y - 0.05f, 0);
		if (transform.position.y <= -4.5f)
		{
				GameObject.FindObjectOfType<GameManagerRelated.GameManager>().LostFood++;
				Destroy(gameObject);
		}
	}
}
