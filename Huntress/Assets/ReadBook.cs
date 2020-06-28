using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBook : MonoBehaviour {

    public GameObject letter;
    public GameObject interactionText;

    bool inRange;
    bool letterIsRead;

	// Use this for initialization
	void Start () {
        inRange = false;
        letterIsRead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact") && inRange == true && letterIsRead == false)
        {
            interactionText.SetActive(false);
            letter.SetActive(true);
            letterIsRead = true;
            Time.timeScale = 0;
        }else if (Input.GetButtonDown("Interact") && letterIsRead == true)
        {
            Time.timeScale = 1;
            letter.SetActive(false);
            letterIsRead = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
