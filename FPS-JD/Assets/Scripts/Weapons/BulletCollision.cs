using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject firstAidKit;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")) {
            GameObject newFirstAidKit = Instantiate(firstAidKit, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.score += 10;
        } else if(collision.gameObject.CompareTag("Boss")) {
            GameManager.Instance.BossDamaged(10);
        }
    }
}
