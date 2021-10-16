using GameManagerRelated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        if (PlayerPrefs.GetInt("Level") >= 1 && PlayerPrefs.GetInt("Win")==1)
          GetComponent<TextMesh>().text = "Good Job! \n Continue To Level " + PlayerPrefs.GetInt("Level").ToString();
        else if(PlayerPrefs.GetInt("Level") >= 1 && PlayerPrefs.GetInt("Win") == 2)
            GetComponent<TextMesh>().text = "Try Again ):";
        else
            GetComponent<TextMesh>().text = "Collect all Food.\n Destroy everything else";

    }


}
