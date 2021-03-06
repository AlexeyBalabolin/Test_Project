﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 Класс реализует прототип пули
  */
public class BulletPrototype : MonoBehaviour,IBullet
{
    //Задаем поведение для пули при ее создании
    public void OnBulletSpawn()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject trajectoryObj = GameObject.Find("BulletPooler");
        Trajectory trajectory = trajectoryObj.GetComponent<Trajectory>();
        float speed = trajectory.GetSpeed();
        rb.velocity = new Vector3(0,0,0);
        rb.AddForce(trajectory.transform.forward * 50, ForceMode.VelocityChange);     
    }
    //Попадание в цель реализуется для разных типов снарядов по-разному
    public virtual void HitTheMark()
    {
        Debug.Log("Попадание");
    }
    private void OnTriggerEnter(Collider other)
    {
        HitTheMark();
    }
}
