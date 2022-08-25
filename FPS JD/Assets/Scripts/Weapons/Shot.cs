using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                GameManager.Instance.gunAmmo --;
                shotRateTime = Time.time + shotRate;
                GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                Destroy(newBullet, 3);
            }
        }
        
    }
}
