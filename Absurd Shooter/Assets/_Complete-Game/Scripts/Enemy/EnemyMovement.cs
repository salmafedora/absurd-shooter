using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               
        PlayerHealth playerHealth;      
        EnemyHealth enemyHealth;        
        UnityEngine.AI.NavMeshAgent nav;               


        void Awake ()
        {
            // cari game object dgn tag player  
            player = GameObject.FindGameObjectWithTag ("Player").transform;

            //reference componenet
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        }


        void Update ()
        {
            // mindahin posisi layer
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
              
                nav.SetDestination (player.position);
            }
            // menghentikan moving
            else
            {
                
                nav.enabled = false;
            }
        }
    }
}