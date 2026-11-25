using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Narrativa2 : MonoBehaviour
{

    public string pantallaConversaciones;
    private VideoPlayer videoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        GameData.Load();
       
    }
    void Awake()
    {

        PlayerPrefs.SetInt("currentChat", 0);
        videoPlayer = GetComponent<VideoPlayer>();
        
        videoPlayer.loopPointReached += AlTerminarVideo;
    }

    void AlTerminarVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene(pantallaConversaciones);
    }



    public void ContinuarNarrativa()
    {
        
        PlayerPrefs.SetInt("currentChat", 0);

        
        SceneManager.LoadScene("PantallaConversaciones");
    }


    


  



}