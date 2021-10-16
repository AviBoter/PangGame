using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels")]
public class LevelScriptableObject : ScriptableObject
{
    [Header("InitLevelData")]
    [SerializeField]
    public int LevelIndex;
    [SerializeField]
    public int SceneIndex;

    [Header("Auto Spawn")]

    [SerializeField]
    public List<GameObject> AutoSpawnList;
  
    [Header("AmmoTypes")]
    public List<GameObject> AmmoList;

    [Header("Win\\Lose Condition")]
    [SerializeField]
    public int NumOfFoodToWin;
    [SerializeField]
    public int NumOfFoodLostToLoose;

}
