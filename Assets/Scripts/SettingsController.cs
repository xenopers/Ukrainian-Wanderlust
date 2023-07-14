using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Button btn;
    public Button btn2;
    public Button btn3;
    public RawImage transition;
    public RawImage bg;
    public GameObject toggle;
    public GameObject scroll;
    public GameObject scroll2;
    public float transitionDuration = 1f;

    public void Start()
    {
        StartCoroutine(TransitionF());
    }

    public IEnumerator TransitionF()
    {
        CanvasGroup canvasGroup = bg.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup1 = btn.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup2 = toggle.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup3 = btn2.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup4 = btn3.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup5 = toggle.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup6 = scroll.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup7 = scroll2.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup1.alpha = 0;
        canvasGroup2.alpha = 0;
        canvasGroup3.alpha = 0;
        canvasGroup4.alpha = 0;
        canvasGroup5.alpha = 0;
        canvasGroup6.alpha = 0;
        canvasGroup7.alpha = 0;

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
            canvasGroup3.alpha = i;
            canvasGroup4.alpha = i;
            canvasGroup5.alpha = i;
            canvasGroup6.alpha = i;
            canvasGroup7.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        transition.gameObject.SetActive(false);
    }
}
