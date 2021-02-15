﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public Text warningText;
        public PlayerHealth playerHealth;

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
            }
        }

        public void ShowWarning(float enemyDistance)
        {
            warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
            anim.SetTrigger("Warning");
        }
    }
}