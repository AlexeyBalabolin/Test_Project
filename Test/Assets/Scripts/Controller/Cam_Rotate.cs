using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Rotate : MonoBehaviour
{
    private float sensitivityVert, minimumVert, maximumVert, sensitivityHor;
    private float _rotationX, _rotationY;
    private float gunRotationSpeed,tankRotationSpeed;
    private GameObject gun,tank;
    private void Start()
    {
        gun = GameObject.Find("Barrel");
        tank = GameObject.Find("Body");
        sensitivityHor = 2;
        sensitivityVert = 2;
        minimumVert = -80;
        maximumVert = 0;
        gunRotationSpeed = 1f;
        tankRotationSpeed = 0.5f;
    }

    void Update()
    {
        CameraRotate();
        TankRotate(CountAngle(gun.transform.forward,tank.transform.forward,Vector3.up));
    }
    public void CameraRotate()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        _rotationY += Input.GetAxis("Mouse X") * sensitivityHor;
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, transform.rotation, Time.deltaTime);
    }
    public Vector3 CountAngle(Vector3 gunForward, Vector3 tankForward, Vector3 ost )
    {
        float single_angle = Vector3.SignedAngle(gunForward, tankForward, ost);
        if (single_angle > 20)
        {
            return new Vector3(0, -tankRotationSpeed, 0);
        }
        else if (single_angle < -20)
        {
            return new Vector3(0, tankRotationSpeed, 0);
        }
        return new Vector3(0,0,0); 
    }
    public void TankRotate(Vector3 angle)
    {
        tank.transform.Rotate(angle);
    }
}
