using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    BulletPooler bulletPooler;
    private ParticleSystem shoot_smoke;
    private bool recharge;
    private float recharge_time;
    private Dictionary<int, string> bullets = new Dictionary<int, string>();
    private int numOfBullet;
    private float maxDistance;
    private bool canFire;
    private Image aim;
    private AudioSource shootSound;
    private void Start()
    {
        bulletPooler = BulletPooler.Instance;
        shoot_smoke = GameObject.Find("ShootSmoke").GetComponent<ParticleSystem>();
        recharge_time = 3f;
        bullets.Add(1,"simple");
        bullets.Add(2,"incendiary");
        bullets.Add(3,"exploding");
        numOfBullet = 1;
        maxDistance = 100;
        canFire = true;
        aim = GameObject.Find("Aim").GetComponent<Image>();
        shootSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ChangeTypeOfBullet();
        }
        canFire = CanFire();
    }
    public void Shoot()
    {
        if(!recharge&&canFire)
        {
            numOfBullet = ChangeTypeOfBullet();
            tag = bullets[numOfBullet];
            BulletPooler.Instance.SpawnFromPool(tag, transform.position, Quaternion.identity);
            shoot_smoke.Play();
            recharge = true;
            shootSound.Play();
            StartCoroutine("Recharge");
        }
    }
    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(recharge_time);
        recharge = false;
    }
    public int ChangeTypeOfBullet()
    {
        if(numOfBullet<=bullets.Keys.Max())
        {
            return numOfBullet++;
        }
        else
        {
            return 1;
        }
    }
    public bool CanFire()
    {
        RaycastHit hit;
        Vector3 fwd = transform.forward;
        if (Physics.Raycast(transform.position, fwd, out hit, maxDistance))
        {

            if (hit.collider.tag=="level_collider")
            {
                aim.color = Color.red;
                return false;
            }
        }
        aim.color = Color.green;
        return true;
    }
}
