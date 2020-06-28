using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantAnimator : MonoBehaviour {

    Animator anim;
    Rigidbody rb;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = rb.velocity;
        Move(move.x, move.z);
	}

    public void Move(float x, float z)
    {
        anim.SetFloat("Forward", z);
        anim.SetFloat("Turn", x);
    }

}
