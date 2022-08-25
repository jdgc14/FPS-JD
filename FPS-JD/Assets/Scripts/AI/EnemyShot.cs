using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject enemyBullet;

    public Transform spawnBulletPoint;

    private Transform playerPosition;

    public float bulletVelocity = 80f;

    public float shotRate = 1.5f;

    private float shotRateTime = 0f;

    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        if (Time.time > shotRateTime && Vector3.Distance(transform.position, playerPosition.position) < 15f)
        {
            if(tag=="Enemy")
            {
                ShootPlayer();
            } else if(tag=="Boss")
            {
                // Invoke("ShootPlayer", 1.5f);
                ShootPlayer();
            }
        }
    }

    void ShootPlayer()
    {
        shotRateTime = Time.time + shotRate;

        Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity);

        Destroy(newBullet, 3);
    }
}
