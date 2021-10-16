using GameManagerRelated;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager child (Composition) 
public class PoolClass : MonoBehaviour, IPoolClass
{
    private GameManager myGM;
    //sort of Singleton
    public static PoolClass Instante;
    public List<GameObject> BulletsPool;
    [NonSerialized]
    public List<GameObject> ObjectsPool;

    [NonSerialized]
    public List<Queue<GameObject>> MyQs;

    void Awake()
        {
        //sort of Singleton
        Instante = this;
        //init
        MyQs = new List<Queue<GameObject>>();
        MyQs.Add(new Queue<GameObject>(BulletsPool));
    }

    // Start is called before the first frame update
     void Start()
        {
         myGM = FindObjectOfType<GameManager>();
         ObjectsPool = GetComponent<LevelLoader>().objects;
         MyQs.Add(new Queue<GameObject>(ObjectsPool));
         init();
         StartCoroutine(nameof(DropObject));
        }

    [Obsolete]
    private IEnumerator DropObject()
    {
        while (true)
        {
            ObjectLunch();
            yield return new WaitForSeconds(3);
        }
    }

    public void init()
    {
        foreach(Queue<GameObject> q in MyQs)
        {
            for (int i = 0; i < q.Count; i++)
            {
                GameObject obj = Instantiate(q.Dequeue());
                obj.SetActive(false);
                q.Enqueue(obj);
            }
        }
    }
    //Shoot and pool out from queue
    public void GrenadeLunch(Transform Parent)
    {
        GameObject obj = MyQs[0].Dequeue();
        if (obj!=null)
        {
            obj.transform.position = Parent.position;
            obj.SetActive(true);
        }
    }
    //push back to queue queue
    public void GrenadeInActive(GameObject Grenade)
    {
        Grenade.SetActive(false);
        MyQs[0].Enqueue(Grenade);
        Grenade.GetComponent<AudioSource>().Play();
    }

    [Obsolete]
    public void ObjectLunch()
    {
        GameObject obj = MyQs[1].Dequeue();
        if (obj != null)
        {
            obj.transform.position = new Vector3(UnityEngine.Random.Range(-5.5f, 5.6f), 5.5f, 0);
            obj.SetActive(true);
            MyQs[1].Enqueue(obj);
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(nameof(Victoty));
        }
    }

    //In case player coolect all food and destroy all obstecles - He wins. 
    [Obsolete]
    private IEnumerator Victoty()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            if(GameObject.FindGameObjectsWithTag(Consts.Food).Length == 0 && GameObject.FindGameObjectsWithTag(Consts.Finish).Length==0)
            myGM.UpdateGameState(CurrentState.Celebrate);
        }
    }

    public void ObjectInActive(GameObject obj)
    {
        obj.SetActive(false);
        MyQs[1].Enqueue(obj);
    }

    //reset all pool's data
    public void ResetToEditorDefaultsRequest()
    {
        ObjectsPool = GetComponent<LevelLoader>().objects;
        MyQs = new List<Queue<GameObject>>();
        MyQs.Add(new Queue<GameObject>(BulletsPool));

        MyQs.Add(new Queue<GameObject>(ObjectsPool));

        init();
        StartCoroutine(nameof(DropObject));
    }
}
