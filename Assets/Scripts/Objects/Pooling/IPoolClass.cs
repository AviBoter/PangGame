using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolClass 
{
    //Init All Pools and Objects
    void init();
    //Active weapons
    void GrenadeLunch(Transform Parent);
    //InActive weapons
    void GrenadeInActive(GameObject Grenade);
    //Active Objects
    void ObjectLunch();
    //InActive Objects
    void ObjectInActive(GameObject obj);
    //Reset All Pools and Objects of any kind
    void ResetToEditorDefaultsRequest();
}
