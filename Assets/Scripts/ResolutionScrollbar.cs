using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionScrollbar : MonoBehaviour
{
    public TextMeshProUGUI resolutionText;

    private Scrollbar resolutionScrollbar;

    private void Start()
    {
        resolutionScrollbar = GetComponent<Scrollbar>();
        resolutionScrollbar.onValueChanged.AddListener(OnResolutionValueChanged);
    }

    private void OnResolutionValueChanged(float value)
    {
        int resolutionIndex = Mathf.RoundToInt(value * (Screen.resolutions.Length - 1));
        Resolution resolution = Screen.resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        resolutionText.text = $"{resolution.width} x {resolution.height}";
    }
}
