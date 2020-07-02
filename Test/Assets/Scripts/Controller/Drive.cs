using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Скрипт на движение танка и поворот вокруг оси
 */
public class Drive : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tankBody;
    private Transform centerOfMass;
    private float TurnSpeed;
    private float force,magnitude;
    // Start is called before the first frame update
    void Start()
    {
        TurnSpeed = 5;
        force = 800f;
        rb = GetComponent<Rigidbody>();
        tankBody = GameObject.Find("Body").transform;
        centerOfMass = GameObject.Find("CenterOfMass").transform;
        magnitude = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    public void Moving()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(rb.velocity.magnitude<magnitude)
        {
            rb.AddRelativeForce(tankBody.forward * vertical * force);
        }
        rb.centerOfMass = centerOfMass.localPosition;
        tankBody.transform.Rotate(Vector3.up, TurnSpeed * horizontal * Time.deltaTime);
    }
}
