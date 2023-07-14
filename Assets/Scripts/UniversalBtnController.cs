using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneButton : MonoBehaviour
{
    public string sceneName;
    public AudioClip buttonSound;

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
        yield return new WaitForSeconds(buttonSound.length);
        SceneManager.LoadScene(sceneName);
    }
}
