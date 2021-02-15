﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public Text warningText;
        public PlayerHealth playerHealth;
        public float restartDelay = 2f;
        PlayerMovement playerMovement;
        PlayerShooting playerShooting;


        Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (playerHealth.currentHealth <= 0)
            {
                

                anim.SetTrigger("GameOver");
                
                Restart();
            }
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

        public void ShowWarning(float enemyDistance)
        {
            warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
            anim.SetTrigger("Warning");
        }
    }
}