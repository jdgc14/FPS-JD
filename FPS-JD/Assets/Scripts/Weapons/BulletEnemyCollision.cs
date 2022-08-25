using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
