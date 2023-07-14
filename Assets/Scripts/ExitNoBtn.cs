using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitNoBtn : MonoBehaviour
{
    public GameObject exitPromptCanvas;
    public AudioClip buttonSound;

    private AudioSource audioSource;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayButton2Sound); // Subscribe to the button click event
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
    }

    public void PlayButton2Sound()
    {
        audioSource.PlayOneShot(buttonSound); // Play the button sound
        StartCoroutine(OnNoButtonClick());
    }

    public System.Collections.IEnumerator OnNoButtonClick()
    {
        yield return new WaitForSeconds(buttonSound.length); // Wait for the sound to finish playing
        CanvasGroup canvasGroup2 = exitPromptCanvas.GetComponent<CanvasGroup>();
        for (float i = 1; i > -0.1; i -= 0.10f)
        {
            canvasGroup2.alpha = i;
            yield return new WaitForSeconds(0.10f);
        }
        exitPromptCanvas.SetActive(false);
    }
}
