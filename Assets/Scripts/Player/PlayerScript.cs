using UnityEngine;
using System.Collections;
using GameManagerRelated;

//Player collide with objects behavior
public class PlayerScript : MonoBehaviour
{
	private GameManager myGM;
	private string Food, Apple, Finish, MainMenu;
    private void Start()
    {
		myGM = GameObject.FindObjectOfType<GameManagerRelated.GameManager>();
		Food = "Food";
		Apple = "Apple";
		Finish = "Finish";
		MainMenu = "MainMenu";
	}

    void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider == null)
				Move(curPosition.x);
		}
	}

	void Move(float posX)
	{
		if (transform.position.x > posX)
		{
			transform.position = new Vector3(transform.position.x - 0.4f, -3, 0);
		}
		else if (transform.position.x < posX)
		{
			transform.position = new Vector3(transform.position.x + 0.4f, -3, 0);
		}
	}

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == Food)
		{
			myGM.Score++;
			GetComponent<AudioSource>().Play();
			Destroy(col.gameObject);
		}
		else if (col.tag == Apple)
		{
			myGM.Score+=2;
			GetComponent<AudioSource>().Play();
			Destroy(col.gameObject);
		}
		else if (col.tag == Finish)
		{
			myGM.UpdateGameState(CurrentState.EndGameUI);
		}
	}
}
