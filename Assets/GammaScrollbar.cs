using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GammaScrollbar : MonoBehaviour
{
    public TextMeshProUGUI gammaText;

    private Scrollbar gammaScrollbar;

    private void Start()
    {
        gammaScrollbar = GetComponent<Scrollbar>();
        gammaScrollbar.onValueChanged.AddListener(OnGammaValueChanged);
    }

    private void OnGammaValueChanged(float value)
    {
        float gamma = Mathf.Lerp(1f, 3f, value);

        ApplyGamma(gamma);

        gammaText.text = gamma.ToString("0.00");
    }

    private void ApplyGamma(float gamma)
    {
        QualitySettings.globalTextureMipmapLimit = Mathf.RoundToInt(gamma);
    }
}
