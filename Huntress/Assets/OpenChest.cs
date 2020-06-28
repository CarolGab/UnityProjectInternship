using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {

    public GameObject interactionText;
    public GameObject gameManager;
    public Text scrollCountText;


    Animation anim;
    bool open;
    bool inRange;
    GameManager code;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animation>();
        code = gameManager.GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact") && inRange == true && open == false)
        {
            code.scrollFragments++;
            interactionText.SetActive(false);
            scrollCountText.text = "Scroll Fragments: " + code.scrollFragments.ToString() + "/5";
            open = true;
            anim.Play();
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !open)
        {
            interactionText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactionText.SetActive(false);
            inRange = false;
        }
    }
}
