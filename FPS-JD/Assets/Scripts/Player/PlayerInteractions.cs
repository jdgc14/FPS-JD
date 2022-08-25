using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AmmoBox")
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "FirstAidKit")
        {
            GameManager.Instance.health += other.gameObject.GetComponent<FirstAidKit>().health;
            Destroy(other.gameObject);
        }
    }
}
