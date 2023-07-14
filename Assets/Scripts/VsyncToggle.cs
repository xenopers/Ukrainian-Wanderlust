using UnityEngine;
using UnityEngine.UI;

public class VsyncToggle : MonoBehaviour
{
    private Toggle vsyncToggle;

    private void Start()
    {
        vsyncToggle = GetComponent<Toggle>();
        vsyncToggle.onValueChanged.AddListener(OnVsyncToggle);
    }

    private void OnVsyncToggle(bool value)
    {
        QualitySettings.vSyncCount = value ? 1 : 0;
    }
}
