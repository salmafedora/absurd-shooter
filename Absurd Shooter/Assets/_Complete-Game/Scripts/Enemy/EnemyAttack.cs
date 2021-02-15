using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;
        public int attackDamage = 10;

        Animator anim;
        GameObject player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        bool playerInRange;
        float timer;


        void Awake ()
        {
            
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
            
            if(other.gameObject == player && other.isTrigger == false)
            {
                playerInRange = true;
            }
        }


        void OnTriggerExit (Collider other)
        {
            if(other.gameObject == player)
            {
                playerInRange = false;
            }
        }


        void Update ()
        {
            
            timer += Time.deltaTime;

      
            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                // ... attack.
                Attack ();
            }

            if(playerHealth.currentHealth <= 0)
            {//mainkan animasi kalau player dead
                anim.SetTrigger ("PlayerDead");
            }
        }


        void Attack ()
        {
            // Reset  timer.
            timer = 0f;

            // menerima damage
            if(playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage (attackDamage);
            }
        }
    }
}