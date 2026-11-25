using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    void Start()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();

        vp.url = Application.streamingAssetsPath + "/Dolencias.mp4";
        vp.Play();
    }
}