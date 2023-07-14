using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutController : MonoBehaviour
{
    public RawImage transition;
    public RawImage bg;
    public Button btn;
    public GameObject text;
    public float transitionDuration = 1f;

    private void Start()
    {
        StartCoroutine(OpenUI());
    }

    private IEnumerator OpenUI()
    {
        CanvasGroup canvasGroup = bg.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup1 = btn.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup2 = text.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup1.alpha = 0;
        canvasGroup2.alpha = 0;
        transition.color = new Color(transition.color.r, transition.color.g, transition.color.b, 1f);

        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);
            transition.color = new Color(transition.color.r, transition.color.g, transition.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        for (float i = 0; i < 1.05; i += 0.05f)
        {
            canvasGroup.alpha = i;
            canvasGroup1.alpha = i;
            canvasGroup2.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        transition.gameObject.SetActive(false);
    }
}
