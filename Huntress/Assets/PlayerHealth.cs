using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Image healthSlider;                                  // Reference to the UI's health bar.
    public Image gameOver;
    public AudioSource deathClip;                                 // The audio clip to play when the player dies.
    public AudioSource hurtClip;
    public Text gameOverText;
    public AudioSource bgm;
    public AudioSource gameOverAudio;

    Animator anim;                                              // Reference to the Animator component.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    float hpX;
    float hpY;
    float waitTime = 5f;
    float startProcess;

    void Start()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        
        // Set the initial health of the player.
        currentHealth = startingHealth;

        isDead = false;
        damaged = false;

        hpX = healthSlider.transform.position.x;
        hpY = healthSlider.transform.position.y;
        gameOver.canvasRenderer.SetAlpha(0f);               
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {            
            damaged = false;
        }
        if (isDead && startProcess < Time.time)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }


    public void TakeDamage(int amount)
    {
        
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        //Set the health bar's value to the current health.
        hpY = hpY - amount * 2;
        healthSlider.transform.position = new Vector2(hpX, hpY);

        // Play the hurt sound effect.

        hurtClip.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && isDead == false)
        {
            // ... it should die.
            Death();
        }
        
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;


        // Tell the animator that the player is dead.
        anim.SetTrigger("isDead");


        deathClip.Play();
        bgm.Stop();
        gameOverAudio.Play();
        gameOver.CrossFadeAlpha(1f, 1f, false);
        gameOverText.text = "Game Over...";
        startProcess = Time.time + waitTime;
    }
}
