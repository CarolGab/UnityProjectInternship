using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {
    
    public int attackDamage = 10;               // The amount of health taken away per attack.
    public AudioSource attackSound;

    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    bool damageOnce;

    void Start()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        damageOnce = false;
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.           
            playerInRange = true;
            damageOnce = true;
        }
        
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.

            playerInRange = false;           
            damageOnce = false;       
        }
    }


    void Update()
    {
        
        if (playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }
        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }


    public void Attack()
    {
        attackSound.Play();
        anim.SetTrigger("Attack");
        // If the player has health to lose...
        if (playerHealth.currentHealth > 0 && damageOnce)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
            damageOnce = false;
        }
    }

}
