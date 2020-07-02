using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Класс реализует object pool*/
public class BulletPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton
    public static BulletPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Выделение памяти под объекты при старте и деактивирование
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i=0;i<pool.size; i++)
            {
                GameObject obj= Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //Спавн объекта из пула 

    public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn= poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        IBullet bullet= objectToSpawn.GetComponent<IBullet>();
        if(bullet!=null)
        {
            bullet.OnBulletSpawn();
        }
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
