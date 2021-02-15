using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        public GameObject enemy;
        public float spawnTime = 3f;
        public Transform[] spawnPoints;

        [SerializeField]
        MonoBehaviour factory;
        IFactory Factory { get { return factory as IFactory; } }


        void Start ()
        {
   
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // Jika player mati
            if(playerHealth.currentHealth <= 0f)
            {
                // tidak ada enemy baru
                return;
            }

            // random spawn enemy
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            int spawnEnemy = Random.Range(0, 3);

            // duplikasi enemy
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            Factory.FactoryMethod(spawnEnemy);
        }
    }
}