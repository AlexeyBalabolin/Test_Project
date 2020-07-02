using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject gun;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        RenderTrajectory(gun.transform.position, gun.transform.forward * speed);
    }
    public void RenderTrajectory(Vector3 origin,Vector3 speed)
    {
        Vector3[] points = new Vector3[50];
        lr.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }
        lr.SetPositions(points);
    }
    public float GetSpeed()
    {
        return speed;
    }
}
