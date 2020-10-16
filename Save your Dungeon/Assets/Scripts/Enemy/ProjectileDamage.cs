using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ProjectileDamage: MonoBehaviour
{
    public GameObject impactEffekt;
    [Range(0 ,100)]
    public int damage;
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        //check if target should get a impacteffekt
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            GameObject impact = Instantiate(impactEffekt, contact.point, Quaternion.LookRotation(contact.normal));
            Destroy(impact, 1);
        }
        
        //enemy loose health
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("enemy hit for " + damage);
            EnemyHealth target = collision.transform.gameObject.GetComponent<EnemyHealth>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }

        //Player loose health
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("player hit for " + damage);
            PlayerHealth player = collision.transform.gameObject.GetComponent<PlayerHealth>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Projectile") Destroy(gameObject, 3f);
        else Destroy(gameObject);
    }
}
