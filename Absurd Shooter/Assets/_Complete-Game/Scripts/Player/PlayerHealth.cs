using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public int startingHealth = 100;
        public int currentHealth;
        public Slider healthSlider;
        public Image damageImage;
        public AudioClip deathClip;
        public float flashSpeed = 5f;
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
  


        Animator anim;
        AudioSource playerAudio;
        PlayerMovement playerMovement;
        PlayerShooting playerShooting;
        bool isDead;
        bool damaged;
        public float restartDelay = 2f;


        void Awake ()
        {
            // reference komponen.
            anim = GetComponent <Animator> ();
            playerAudio = GetComponent <AudioSource> ();
            playerMovement = GetComponent <PlayerMovement> ();
            playerShooting = GetComponentInChildren<PlayerShooting>();

            // initial health
            currentHealth = startingHealth;
        }


        void Update ()
        {
            // jika terkena damage
            if(damaged)
            {
                // mengubah warna jadi flashcolor
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                // clear lagi
                damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset damage flag
            damaged = false;
        }


        public void TakeDamage (int amount)
        {
            
            damaged = true;

            // mengurangi health 
            currentHealth -= amount;

            // mengatur healthbar
            healthSlider.value = currentHealth;

            // Play hurt sound effect.
            playerAudio.Play ();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)
            {
                // MATI
                Death ();
                Restart();
            }
        }


        void Death ()
        {
            
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects();

            // trigger animasi die
            anim.SetTrigger ("Die");

            // memainkan suara ketika mati
            playerAudio.clip = deathClip;
            playerAudio.Play ();

            // mematikan script pergerakan
            playerMovement.enabled = false;
            playerShooting.enabled = false;

            
        }


        public void RestartLevel ()
        {
            // restard scene
            SceneManager.LoadScene (0);
        }

        void Restart()
        {
            StartCoroutine("Restart2");
        }

        IEnumerator Restart2()
        {
            yield return new WaitForSeconds(restartDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void PlusHP(int healthBonus)
        {
            currentHealth += healthBonus;
            if (currentHealth > startingHealth)
            {
                currentHealth = startingHealth;
            }
            healthSlider.value = currentHealth;
        }

      
    }
}