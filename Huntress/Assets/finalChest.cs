using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalChest : MonoBehaviour
{

    public GameObject interactionText;
    public GameObject gameManager;
    public Text scrollCountText;
    public GameObject cannotOpen;

    Animation anim;
    bool open;
    bool inRange;
    GameManager code;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animation>();
        code = gameManager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inRange == true && open == false && code.scrollFragments == 4)
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
        if (other.gameObject.CompareTag("Player") && !open && code.scrollFragments == 4)
        {
            interactionText.SetActive(true);
            inRange = true;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            cannotOpen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !open && code.scrollFragments == 4)
        {
            interactionText.SetActive(false);
            inRange = false;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            cannotOpen.SetActive(false);
        }
    }
}
