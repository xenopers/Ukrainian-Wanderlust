using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBtnController : MonoBehaviour
{
    public AudioClip buttonSound;

    private AudioSource audioSource;
    public GameObject canvas;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayButtonSound);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;

        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
        StartCoroutine(LoadSceneAfterSound());
    }

    private IEnumerator LoadSceneAfterSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        canvas.SetActive(true);
        for (float i = 0; i <= 1.1; i += 0.10f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForSeconds(0.10f);
        }
    }
}
