using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy_Controller
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField]
        private EnemyController enemyVariableController;

        public bool attacking = false;

        private void Start()
        {
            if (enemyVariableController == null)
            {
                enemyVariableController = GetComponent<EnemyController>();
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                HealthController playerHealth = other.GetComponent<HealthController>();
                if (playerHealth != null)
                {
                    if (enemyVariableController != null)
                    {
                        attacking=true;
                    }
                } 
            }
        }

    }
}
