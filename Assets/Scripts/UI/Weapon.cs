using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	public Transform PlayerPos;

	private PoolClass Pool;
	private void Start()
	{
		Pool = GameObject.FindObjectOfType<PoolClass>();
	}
	
	
	void OnMouseDown()
	{
		transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
	}

	void OnMouseUp()
	{
		Pool.GrenadeLunch(PlayerPos);
		transform.localScale = new Vector3(2.4f, 2.4f, 2.4f);
	}

}
