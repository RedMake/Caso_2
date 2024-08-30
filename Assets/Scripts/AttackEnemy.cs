using Enemy_Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{

    public bool attacking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthController enemyHealth = other.GetComponent<HealthController>();
            if (enemyHealth != null)
            {
                attacking = true;              
            }
        }
    }
}
