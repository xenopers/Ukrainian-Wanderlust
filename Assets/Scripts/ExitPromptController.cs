using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPromptController : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public GameObject exitPromptCanvas;
    public AudioClip buttonSound;

    private AudioSource audioSource;
    void Start()
    {
        btn1.onClick.AddListener(PlayButton1Sound); // Subscribe to the button click event
        btn2.onClick.AddListener(PlayButton2Sound); // Subscribe to the button click event
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
    }

    public void PlayButton1Sound()
    {
        audioSource.PlayOneShot(buttonSound); // Play the button sound
        StartCoroutine(OnYesButtonClick());
    }

    public void PlayButton2Sound()
    {
        audioSource.PlayOneShot(buttonSound); // Play the button sound
        StartCoroutine(OnNoButtonClick());
    }

    public System.Collections.IEnumerator OnYesButtonClick()
    {
        yield return new WaitForSeconds(buttonSound.length); // Wait for the sound to finish playing
        Application.Quit();
    }

    public System.Collections.IEnumerator OnNoButtonClick()
    {
        yield return new WaitForSeconds(buttonSound.length); // Wait for the sound to finish playing
        exitPromptCanvas.SetActive(false);
    }
}