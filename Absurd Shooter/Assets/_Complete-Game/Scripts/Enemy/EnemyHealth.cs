using UnityEngine;

namespace CompleteProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 100;
        public int currentHealth;
        public float sinkSpeed = 2.5f;
        public int scoreValue = 10;
        public AudioClip deathClip;


        Animator anim;
        AudioSource enemyAudio;
        ParticleSystem hitParticles;
        CapsuleCollider capsuleCollider;
        bool isDead;
        bool isSinking;                          

        void Awake ()
        {
            //set reference komponen
            anim = GetComponent<Animator>();
            enemyAudio = GetComponent<AudioSource>();
            hitParticles = GetComponentInChildren<ParticleSystem>();
            capsuleCollider = GetComponent<CapsuleCollider>();

            //Set current health
            currentHealth = startingHealth;
        }


        void Update ()
        {
            // Jika sinking
            if(isSinking)
            {
                // pindah objek ke bawah
                transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }


        public void TakeDamage (int amount, Vector3 hitPoint)
        {
            // jika enemy dead
            if (isDead)
                return;

            //play audio
            enemyAudio.Play();

            //kurangi health
            currentHealth -= amount;

            //ganti posisi particle
            hitParticles.transform.position = hitPoint;

            //play particle system
            hitParticles.Play();

            //dead jika health <= 0
            if (currentHealth <= 0)
            {
                Death();
            }
        }


        void Death ()
        {
            // mati
            isDead = true;

            // setcapcollider ke trigger
            capsuleCollider.isTrigger = true;

            // trigger animasi mati
            anim.SetTrigger ("Dead");

            // mainkan suara sakaratul maut
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();
        }


        public void StartSinking ()
        {
            //disable Navmesh Component
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            //Set rigisbody ke kimematic
            GetComponent<Rigidbody>().isKinematic = true;
            isSinking = true;
            ScoreManager.score += scoreValue;
            Destroy(gameObject, 2f);
        }
    }
}