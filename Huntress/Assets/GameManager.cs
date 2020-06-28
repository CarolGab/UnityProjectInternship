using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject letter;
    public GameObject interactionText;
    public GameObject victory;
    public int scrollFragments;
    public AudioSource victoryAudio;
    public Text victoryText;
    public AudioSource bgm;
    public GameObject healthCanvas;
    public GameObject pauseMenu;
    public GameObject optionsScreen;
    public GameObject soundSettings;
    public GameObject qualitySettings;
    public Slider soundSlider;
    public GameObject loadingScreen;
    public GameObject cannotOpen;

    public bool pauseOn = false;
    bool victoryOnce = false;
    AsyncOperation currentLoading;
    float waitTime = 5f;
    float startProcess;


    // Use this for initialization
    void Start () {
        scrollFragments = 0;
        pauseMenu.SetActive(false);
        cannotOpen.SetActive(false);
        letter.SetActive(false);
        interactionText.SetActive(false);
        victory.SetActive(false);
        loadingScreen.SetActive(false);
        optionsScreen.SetActive(false);
        soundSettings.SetActive(false);
        qualitySettings.SetActive(false);
        PlayerPrefs.GetFloat("Sound Volume");
        currentLoading = null;
        Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update()
    {      
        if (scrollFragments == 5 && victoryOnce == false)
        {
            Victory();
            victoryOnce = true;
        }
        if (Input.GetButtonDown("Cancel") && !pauseOn)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseOn = true;
        }else if (Input.GetButtonDown("Cancel") && pauseOn)
        {
            optionsScreen.SetActive(false);
            soundSettings.SetActive(false);
            qualitySettings.SetActive(false);
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            pauseOn = false;
        }
        if (victoryOnce && startProcess < Time.time)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    void Victory()
    {
        bgm.Stop();
        victoryAudio.Play();
        victory.SetActive(true);
        healthCanvas.SetActive(false);
        victoryText.text = "Victory!";
        startProcess = Time.time + waitTime;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        optionsScreen.SetActive(false);
        soundSettings.SetActive(false);
        qualitySettings.SetActive(false);
    }

    public void BackToOptions()
    {
        optionsScreen.SetActive(true);
        soundSettings.SetActive(false);
        qualitySettings.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundMenu()
    {
        optionsScreen.SetActive(false);
        soundSettings.SetActive(true);
    }

    public void QualityMenu()
    {
        optionsScreen.SetActive(false);
        qualitySettings.SetActive(true);
    }

    public void OnValueChangedSound()
    {
        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("Sound Volume", AudioListener.volume);
    }

    public void HighQuality()
    {
        QualitySettings.SetQualityLevel(5);
    }

    public void AverageQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void MainMenu()
    {
        currentLoading = SceneManager.LoadSceneAsync("MainMenu");
        if (currentLoading.isDone)
        {
            SceneManager.UnloadSceneAsync("Main Menu");
            currentLoading = null;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            loadingScreen.SetActive(true);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
