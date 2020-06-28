using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    public int damage = 50;
    public AudioSource attackingSound;
    public GameObject gameManager;

    GameManager code;
    Animator anim;
    bool isAttacking = false;

    // Use this for initialization
    void Start()
    {
        code = gameManager.GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && code.pauseOn == false)
        {
            isAttacking = true;
            attackingSound.Play();
            anim.SetBool("Attacking", true);
            anim.SetTrigger("Hit");
            Invoke("StoppedCombo", 0.2f);
        }
        else if (isAttacking == true)
        {
            isAttacking = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && isAttacking)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void StoppedCombo()
    {
        anim.SetBool("Attacking", false);
    }
}
