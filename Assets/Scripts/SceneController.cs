using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string sceneName;
    public bool playerIsClose;
    public Transform target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, target.position) <= 10f)
        {
            GotoScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    void GotoScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}