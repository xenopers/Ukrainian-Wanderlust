using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayBtnController : MonoBehaviour
{
    public string sceneName;
    public AudioClip buttonSound;
    public RawImage Trans;

    private AudioSource audioSource;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayButtonSound);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
        StartCoroutine(LoadSceneAfterSound());
    }

    private System.Collections.IEnumerator LoadSceneAfterSound()
    {
        CanvasGroup canvasGroup = Trans.GetComponent<CanvasGroup>();
        yield return new WaitForSeconds(buttonSound.length);
        for (float i = 0; i < 1.05; i += 0.05f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
