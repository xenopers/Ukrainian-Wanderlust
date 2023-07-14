using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuUI, OptionUI, AboutLocationUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            menuOpening();
        else if (Input.GetKeyDown(KeyCode.O))
            optionOpening();
        else if(Input.GetKeyDown(KeyCode.I))
            locationInfoOpening(); 
    }
    public void menuOpening()
    {
        MenuUI.SetActive(!MenuUI.activeSelf);
        OptionUI.SetActive(false);
        AboutLocationUI.SetActive(false);
    }
    public void optionOpening()
    {
        MenuUI.SetActive(false);
        OptionUI.SetActive(!OptionUI.activeSelf);
        AboutLocationUI.SetActive(false);
    }
    public void locationInfoOpening()
    {
        MenuUI.SetActive(false);
        OptionUI.SetActive(false);
        AboutLocationUI.SetActive(!AboutLocationUI.activeSelf);
    }
}
