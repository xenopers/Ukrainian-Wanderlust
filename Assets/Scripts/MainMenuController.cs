using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public RawImage logo;
    public GameObject text;
    public GameObject text2;
    public float logoDuration = 2f;
    public float fadeDuration = 1f;
    public string mainMenuSceneName = "SampleScene";

    private void Start()
    {
        StartCoroutine(ShowLogoCoroutine());
    }

    private IEnumerator ShowLogoCoroutine()
    {
        logo.gameObject.SetActive(true);
        CanvasGroup canvasGroup = logo.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup1 = text.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup2 = text2.GetComponent<CanvasGroup>();

        for (float i = 0; i < 1; i += 0.05f)
        {
            canvasGroup.alpha = i;
            canvasGroup1.alpha = i;
            canvasGroup2.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(logoDuration);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            canvasGroup1.alpha = alpha;
            canvasGroup2.alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }
}
