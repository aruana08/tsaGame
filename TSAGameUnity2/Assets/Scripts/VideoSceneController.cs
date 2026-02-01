using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoSceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button skipButton;
    public string nextSceneName = "03_MainMap";

    void Start()
    {
        // Play video
        videoPlayer.Play();

        // When video ends → load scene
        videoPlayer.loopPointReached += OnVideoEnd;

        // Skip button click → load scene
        skipButton.onClick.AddListener(SkipVideo);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void SkipVideo()
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
