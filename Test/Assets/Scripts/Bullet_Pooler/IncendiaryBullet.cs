using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncendiaryBullet : BulletPrototype
{
    public GameObject prefab_effect;
    public override void HitTheMark()
    {
        Debug.Log("Поджигающая пуля");
        Instantiate(prefab_effect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
