using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitYesBtn : MonoBehaviour
{
    public AudioClip buttonSound;

    private AudioSource audioSource;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayButtonSound); // Subscribe to the button click event
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound); // Play the button sound
        StartCoroutine(OnYButtonClick());
    }

    public IEnumerator OnYButtonClick()
    {
        yield return new WaitForSeconds(buttonSound.length); // Wait for the sound to finish playing
        Application.Quit();
    }
}
