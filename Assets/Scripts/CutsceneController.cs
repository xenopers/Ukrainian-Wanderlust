using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName;

    public float skipSceneTime;
    float pressingBtn = 0;

    private void Start()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

        private void Update()
    {  
        if(Input.GetMouseButton(0)) {
            pressingBtn += Time.deltaTime;
            if(pressingBtn >= skipSceneTime)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else pressingBtn = 0;
        
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        SceneManager.LoadScene(sceneName);
    }
}
