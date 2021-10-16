using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [NonSerialized]
    public List<GameObject> objects;
    [NonSerialized]
    public List<GameObject> Ammo;
    [NonSerialized]
    public int FoodToWin;
    [NonSerialized]
    public int FoodLostToloose;

    [SerializeField]
    private LevelScriptableObject[] Level;

    private void Awake()
    {
        int index = PlayerPrefs.GetInt(Consts.Level) - 1;
        if (index >= 3 || index < 0)
        {
            PlayerPrefs.SetInt(Consts.Level, 0);
            index = PlayerPrefs.GetInt(Consts.Level);
        }

        objects = new List<GameObject>(Level[index].AutoSpawnList);
        Ammo = new List<GameObject>(Level[index].AmmoList);
        FoodToWin = Level[index].NumOfFoodToWin;
        FoodLostToloose = Level[index].NumOfFoodLostToLoose;
    }
}
