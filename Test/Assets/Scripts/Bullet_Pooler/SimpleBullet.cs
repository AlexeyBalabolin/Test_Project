using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BulletPrototype
{
    public override void HitTheMark()
    {
        Debug.Log("Простая пуля");
        gameObject.SetActive(false);
    }
}
